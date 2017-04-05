namespace AnimationTest
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Diagnostics;
    public class KModel : KMesh
    {
        private  VBone[] Bones;
        private Matrix[] InvBindPose;
        private Matrix[] BoneTransform;

        private BasicEffect BoneShader;

        // ============= Bones ============= \\
        public bool DrawBones;
        private VertexPositionColor[] boneBindVertices;
        private VertexPositionColor[] boneVertices;
        private DynamicVertexBuffer   vBoneBuffer;
        private IndexBuffer           iBoneBuffer;
        private int NumBoneVertex;
        private int NumBoneIndicies;

        // ============== Mesh ============= \\
        public bool DrawMesh;
        private KVertexDeclaration[]            meshVertices;
        private VertexPositionNormalTexture[]   vertices;
        private DynamicVertexBuffer vMeshBuffer;
        private IndexBuffer         iMeshBuffer;

        public KModel(GraphicsDevice d, KVertexDeclaration[] v, short[] ind , VBone[] b)
        {
            device = d;
            meshVertices = v;
            Bones = b;

            // ============= IndexBuffer =============
            NumIndicies = ind.Length;
            iMeshBuffer = new IndexBuffer(device, IndexElementSize.SixteenBits, sizeof(short) * (NumIndicies * 3), BufferUsage.None);
            iMeshBuffer.SetData(ind);

            // ============= VertexBuffer =============
            NumVertex = v.Length;
            vMeshBuffer = new DynamicVertexBuffer(device, typeof(VertexPositionNormalTexture), NumVertex, BufferUsage.WriteOnly);

            vertices = new VertexPositionNormalTexture[NumVertex];
            for (int i = 0; i < NumVertex; i++)
            {
                vertices[i].Position          = meshVertices[i].Position;
                vertices[i].Normal            = meshVertices[i].Normals;
                vertices[i].TextureCoordinate = meshVertices[i].TextCord;
            }
            vMeshBuffer.SetData(vertices);

            // ============= Kosci =============
            InvBindPose = new Matrix[Bones.Length];
            BoneTransform = new Matrix[Bones.Length];

            for (int i = 0; i < Bones.Length; i++)
                if (Bones[i].ParentIndex == -1) KMeshHelper.CalculateInvertBindPose(i, Matrix.Identity, ref Bones, ref InvBindPose);

            boneBindVertices = new VertexPositionColor[Bones.Length];
            boneVertices = new VertexPositionColor[Bones.Length];

            for (int i = 0; i < Bones.Length; i++)
            {
                boneBindVertices[i].Color = Color.Gold;
                boneBindVertices[i].Position = Vector3.Transform(Vector3.Zero, Matrix.Invert(InvBindPose[i]));
                boneVertices[i] = boneBindVertices[i];
            }

            NumBoneVertex = boneVertices.Length;
            vBoneBuffer = new DynamicVertexBuffer(device, typeof(VertexPositionColor), NumBoneVertex, BufferUsage.WriteOnly);
            vBoneBuffer.SetData(boneVertices);

            short[] bind = new short[Bones.Length*2];
            short p = 0;
            for (int i = 0; i < Bones.Length * 2; i += 2)
            {
                bind[i + 0] = p;
                if (Bones[p].ParentIndex > -1)
                    bind[i + 1] = (short)Bones[p].ParentIndex;
                else
                    bind[i + 1] = p;
                p++;
            }
            NumBoneIndicies = bind.Length;

            iBoneBuffer = new IndexBuffer(device, IndexElementSize.SixteenBits, sizeof(short) * (NumBoneIndicies), BufferUsage.None);
            iBoneBuffer.SetData(bind);

            Matrix Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), device.Viewport.AspectRatio, 0.01f, 1000f);

            // ============= Shader'y =============
            MeshShader = new BasicEffect(device);
            MeshShader.EnableDefaultLighting();
            MeshShader.World = Matrix.Identity;
            MeshShader.Projection = Projection;

            BoneShader = new BasicEffect(device);
            BoneShader.VertexColorEnabled = true;
            BoneShader.World = Matrix.Identity;
            BoneShader.Projection = Projection;

            DrawBones = true;
            DrawMesh = true;
        }
    
        public VBone[] GetBones()
        {
            return Bones;
        }
        public void SetMaterial(Texture2D M)
        {
            if (M != null)
            {
                MeshShader.TextureEnabled = true;
                MeshShader.Texture = M;
            }
            else
            {
                MeshShader.TextureEnabled = false;
                MeshShader.Texture = null;
            }
        }
        public void UpdateTransform(VBone[] frame)
        {
            Vector3 pos;
            Vector3 normal;

            // Przygotowujemy macierze transformacji
            for (int i = 0; i < frame.Length; i++)
                if (frame[i].ParentIndex == -1) KMeshHelper.CalculateBoneMatrix(i, Matrix.Identity, ref frame, ref InvBindPose, ref BoneTransform);

            // Kosci
            for (int i = 0; i < NumBoneVertex; i++)
                boneVertices[i].Position = Vector3.Transform(boneBindVertices[i].Position, BoneTransform[i]);

            vBoneBuffer.SetData(boneVertices, 0, NumBoneVertex, SetDataOptions.Discard);

            // Mesh
            for (int i = 0; i < NumVertex; i++)
            {
                pos = Vector3.Zero;
                normal = Vector3.Zero;
                for (int j = 0; j < 4; j++)
                {
                    pos += Vector3.Transform(meshVertices[i].Position, Matrix.Multiply(BoneTransform[meshVertices[i].BoneIndices[j]], meshVertices[i].BoneWeight[j]));
                    normal += Vector3.TransformNormal(meshVertices[i].Normals, Matrix.Multiply(BoneTransform[meshVertices[i].BoneIndices[j]], meshVertices[i].BoneWeight[j]));
                }
                vertices[i].Position = pos;
                vertices[i].Normal = normal;
            }
            vMeshBuffer.SetData(vertices, 0, NumVertex, SetDataOptions.Discard);
        }
        public override void SetViewMatrix(Matrix View)
        {
            base.SetViewMatrix(View);
            BoneShader.View = View;
        }
        public override void Draw()
        {
            if (DrawMesh)
            { 
                MeshShader.CurrentTechnique.Passes[0].Apply();
                device.Indices = iMeshBuffer;
                device.SetVertexBuffer(vMeshBuffer);
                device.RasterizerState = RasterizerState.CullCounterClockwise;
                device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, NumVertex, 0, NumIndicies);
            }
            if (DrawBones)
            {
                BoneShader.CurrentTechnique.Passes[0].Apply();
                device.Indices = iBoneBuffer;
                device.SetVertexBuffer(vBoneBuffer);
                device.RasterizerState = RasterizerState.CullNone;
                device.DrawIndexedPrimitives(PrimitiveType.LineList, 0, 0, NumBoneVertex, 0, NumBoneIndicies);
            }
        }
    }
}
