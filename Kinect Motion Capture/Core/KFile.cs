namespace AnimationTest
{
    using System.IO;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class KFile
    {
    
        public static KAnimInfo LoadPSA(string filename)
        {
            KAnimInfo Info = new KAnimInfo();
            if (File.Exists(filename))
            {
                FileStream file = File.Open(filename, FileMode.Open);
                VChunkHeader main = KFileHelper.GetChunk(file);

                VBone[] Bones = KFileHelper.GetData<VBone>(file);
                AnimInfoBinary[] Animinfo = KFileHelper.GetData<AnimInfoBinary>(file);
                VQuatAnimKey[] AnimKeys = KFileHelper.GetData<VQuatAnimKey>(file);

                for (int i = 0; i < Bones.Length; i++)
                    if (i == Bones[i].ParentIndex) Bones[i].ParentIndex = -1;

                if (Animinfo.Length > 0)
                {

                    Info.AnimRate = Animinfo[0].AnimRate;
                    Info.BoneCount = Bones.Length;
                    Info.Name = Animinfo[0].Name;
                    Info.Frames = new List<KeyFrame>();

                    float StepTime = 1.0f / Animinfo[0].AnimRate;

                    for (int i = 0; i < Animinfo[0].NumRawFrames; i++)
                    {
                        KeyFrame frame = new KeyFrame();
                        frame.Bones = new VBone[Animinfo[0].TotalBones];
                        int x = 0;
                        for (int j = (i * Animinfo[0].TotalBones); j < (i * Animinfo[0].TotalBones) + Animinfo[0].TotalBones; j++)
                        {
                            frame.Bones[x].BonePos.Position = AnimKeys[j].Position;
                            frame.Bones[x].BonePos.Orientation = AnimKeys[j].Orientation;
                            frame.Bones[x].ParentIndex = Bones[x].ParentIndex;
                            frame.Bones[x].Name = Bones[x].Name;
                            frame.Time = StepTime * i;
                            x++;
                        }
                        Info.Frames.Add(frame);
                    }
                }
                file.Close();
            }
            return Info;
        }
        public static void SavePSA(string filename, string animName, VBone[] bones, KeyFrame[] frames)
        {
            // Naglowek - Glowny
            VChunkHeader MainChunk = new VChunkHeader();
            MainChunk.ChunkID  = "ANIMHEAD";
            MainChunk.TypeFlag = 2003321;

            // Naglowek - Kosci
            VChunkHeader BoneChunk = new VChunkHeader();
            BoneChunk.ChunkID   = "BONENAMES";
            BoneChunk.DataCount = bones.Length;
            BoneChunk.DataSize  = 120;

            // Naglowek - Informacje o animacji
            VChunkHeader AnimInfoChunk = new VChunkHeader();
            AnimInfoChunk.ChunkID   = "ANIMINFO";
            AnimInfoChunk.DataCount = 1;
            AnimInfoChunk.DataSize  = 168;

            // Naglowek - Skalowanie
            VChunkHeader ScaleChunk = new VChunkHeader();
            ScaleChunk.ChunkID = "SCALEKEYS";
            ScaleChunk.DataCount = 0;
            ScaleChunk.DataSize = 16;

            // Naglowek - informacje o ilosci klatek
            VChunkHeader AnimKeyChunk = new VChunkHeader();
            AnimKeyChunk.ChunkID = "ANIMKEYS";
            AnimKeyChunk.DataCount = bones.Length * frames.Length;
            AnimKeyChunk.DataSize = 32;

            // Informacje o animacji
            AnimInfoBinary AnimInfo = new AnimInfoBinary();
            AnimInfo.AnimRate = 30.0f;
            AnimInfo.FirstRawFrame = 0;
            AnimInfo.Group = "None";
            AnimInfo.KeyCompressionStyle = 0;
            AnimInfo.KeyQuotum = frames.Length * bones.Length; //Ilosc wszystkich klatek * kosci
            AnimInfo.KeyReduction = 1.0f;
            AnimInfo.Name = animName;
            AnimInfo.NumRawFrames = frames.Length;
            AnimInfo.RootInclude = 0;
            AnimInfo.StartBone = 0;
            AnimInfo.TotalBones = bones.Length;
            AnimInfo.TrackTime = frames.Length;

            FileStream file = File.Create(filename);

            file.Write(KFileHelper.StructToByte(MainChunk), 0, 32);
            file.Write(KFileHelper.StructToByte(BoneChunk), 0, 32);

            // Przerobić kości na poprawne i zapisac do pliku

            VQuatAnimKey[] keys = new VQuatAnimKey[bones.Length * frames.Length];

            // Bones
            for (int i = 0; i < bones.Length; i++)
            {
                if (bones[i].ParentIndex == -1) bones[i].ParentIndex = i;
                file.Write(KFileHelper.StructToByte(bones[i]), 0, 120);
            }

            // AnimInfo
            file.Write(KFileHelper.StructToByte(AnimInfoChunk), 0, 32);
            file.Write(KFileHelper.StructToByte(AnimInfo), 0, 168);

            // AnimKeys
            file.Write(KFileHelper.StructToByte(AnimKeyChunk), 0, 32);
            for (int i = 0; i < frames.Length; i++)
            {
                for (int j = 0; j < bones.Length; j++)
                {
                    int pos = i * bones.Length;
                    keys[pos].Orientation = frames[i].Bones[j].BonePos.Orientation;
                    keys[pos].Position = frames[i].Bones[j].BonePos.Position;
                    keys[pos].Time = 1.0f;
                    file.Write(KFileHelper.StructToByte(keys[pos]), 0, 32);
                }
            }

            // Scale
            file.Write(KFileHelper.StructToByte(ScaleChunk), 0, 32);


            file.Close();
        }
        public static KModel LoadPSK(GraphicsDevice device, string filename)
        {
            if (device == null) return null;
            if (File.Exists(filename))
            {
                KVertexDeclaration[] vt, v;

                // ============================== FILE ============================== \\

                FileStream file = File.Open(filename, FileMode.Open);

                VChunkHeader        Chunk     = KFileHelper.GetChunk(file);
                Vector3[]           points    = KFileHelper.GetData<Vector3>(file);
                VVertex[]           vertex    = KFileHelper.GetData<VVertex>(file);
                VTriangle[]         faces     = KFileHelper.GetData<VTriangle>(file);
                VMaterial[]         mats      = KFileHelper.GetData<VMaterial>(file);
                VBone[]             bones     = KFileHelper.GetData<VBone>(file);
                VRawBoneInfluence[] influence = KFileHelper.GetData<VRawBoneInfluence>(file);

                file.Close();

                // ============================== MESH ============================== \\

                vt = new KVertexDeclaration[points.Length];

                // Position
                for (int i = 0; i < points.Length; i++)
                {
                    vt[i].Position = points[i];
                    vt[i].BoneIndices = new int[4];
                    vt[i].BoneWeight = new float[4];
                }

                // Normals
                int i0, i1, i2;
                Vector3 vNormal;
                for (int i = 0; i < faces.Length; i++)
                {
                    i0 = vertex[faces[i].WedgeIndex[0]].PointIndex;
                    i1 = vertex[faces[i].WedgeIndex[1]].PointIndex;
                    i2 = vertex[faces[i].WedgeIndex[2]].PointIndex;
                    vNormal = Vector3.Cross((points[i1] - points[i0]), (points[i0] - points[i2]));
                    vNormal.Normalize();
                    vt[i0].Normals += vNormal;
                    vt[i1].Normals += vNormal;
                    vt[i2].Normals += vNormal;
                }

                // Normalizacja
                for (int i = 0; i < points.Length; i++)
                    vt[i].Normals.Normalize();

                // BoneIndices | BoneWeight
                for (int i = 0; i < influence.Length; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (vt[influence[i].PointIndex].BoneWeight[j] == 0)
                        {
                            vt[influence[i].PointIndex].BoneWeight[j] = influence[i].Weight;
                            vt[influence[i].PointIndex].BoneIndices[j] = influence[i].BoneIndex;
                            break;
                        }
                    }
                }

                v = new KVertexDeclaration[vertex.Length];

                for (int i = 0; i < v.Length; i++)
                {
                    v[i].Position = vt[vertex[i].PointIndex].Position;
                    v[i].Normals = vt[vertex[i].PointIndex].Normals;
                    v[i].TextCord = vertex[i].TextCord;
                    v[i].BoneIndices = vt[vertex[i].PointIndex].BoneIndices;
                    v[i].BoneWeight = vt[vertex[i].PointIndex].BoneWeight;
                }

                short[] ind = new short[faces.Length * 3];
                for (int i = 0; i < faces.Length; i++)
                {
                    int pos = i * 3;
                    ind[pos + 0] = faces[i].WedgeIndex[0];
                    ind[pos + 1] = faces[i].WedgeIndex[1];
                    ind[pos + 2] = faces[i].WedgeIndex[2];
                }

                for (int i = 0; i < bones.Length; i++)
                {
                    if (bones[i].ParentIndex == i)
                        bones[i].ParentIndex = -1;
                }

                return new KModel(device, v, ind, bones);
            }
            else return null;
        }
        public static Texture2D LoadTexture(GraphicsDevice device, string filename)
        {
            if (File.Exists(filename))
            {
                Image img = Image.FromFile(filename);
                if (img != null)
                {
                    // Zmiana rozmiaru tekstury na 512x512
                    Bitmap b = new Bitmap(512, 512);
                    Graphics g = Graphics.FromImage((Image)b);
                    g.InterpolationMode = InterpolationMode.Bicubic;
                    g.DrawImage(img, 0, 0, 512, 512);
                    g.Dispose();

                    img = (Image)b;

                    Size size = img.Size;

                    int PixelSize = Image.GetPixelFormatSize(img.PixelFormat); // Zwraca w bitach
                    PixelSize /= 8;
                    int bufferSize = size.Height * size.Width * PixelSize;
                    System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(bufferSize);
                    img.Save(memoryStream, ImageFormat.Png);
                    return Texture2D.FromStream(device, memoryStream);
                }
            }
            return null;
        }
    }
}
