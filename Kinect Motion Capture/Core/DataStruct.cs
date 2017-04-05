namespace AnimationTest
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Microsoft.Xna.Framework;

    #pragma warning disable 169,0649

    public struct KVertexDeclaration
    {
        public Vector3 Position;
        public Vector2 TextCord;
        public Vector3 Normals;
        public float[] BoneWeight;
        public int[] BoneIndices;
    };

    // Kopia JointType od Microsoft'u uzupelniona o pole None
    public enum KJointType
    {
        None = -1,
        HipCenter = 0,
        Spine,
        ShoulderCenter,
        Head,
        ShoulderLeft,
        ElbowLeft,
        WristLeft,
        HandLeft,
        ShoulderRight,
        ElbowRight,
        WristRight,
        HandRight,
        HipLeft,
        KneeLeft,
        AnkleLeft,
        FootLeft,
        HipRight,
        KneeRight,
        AnkleRight,
        FootRight
    };

    struct KAnimInfo
    {
        public string     Name;
        public float      AnimRate;
        public int        BoneCount;
        public List<KeyFrame> Frames;
    };

    public struct KeyFrame
    {
        public float Time;
        public VBone[] Bones;
    };

    struct VVertex
    {
        public short PointIndex;
        public Vector2 TextCord;
        public byte MatIndex;
        public byte Reserved;
    };
    [StructLayout(LayoutKind.Explicit)]
    struct VTriangle
    {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I2)]
        public short[] WedgeIndex; //3
        [FieldOffset(6)]
        public byte MatIndex;
        [FieldOffset(7)]
        public byte AuxMatIndex;
        [FieldOffset(8)]
        public int SmoothingGroups;
    };
    [StructLayout(LayoutKind.Explicit)]
    struct VMaterial
    {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string MaterialName;
        [FieldOffset(64)]
        public int TextureIndex;
        [FieldOffset(68)]
        public int PolyFlags;
        [FieldOffset(72)]
        public int AuxMaterial;
        [FieldOffset(76)]
        public int AuxFlags;
        [FieldOffset(80)]
        public int LodBias;
        [FieldOffset(84)]
        public int LodStyle;
    };
    [StructLayout(LayoutKind.Explicit)] // 32 bajty
    struct VChunkHeader
    {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string ChunkID;
        [FieldOffset(20)]
        public int TypeFlag;
        [FieldOffset(24)]
        public int DataSize;
        [FieldOffset(28)]
        public int DataCount;
    };
    public struct VJointPos
    {
        public Quaternion Orientation;
        public Vector3 Position;
        public float Length;
        public float XSize;
        public float YSize;
        public float ZSize;
    };
    [StructLayout(LayoutKind.Explicit)]
    public struct VBone
    {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string Name; //64
        [FieldOffset(64)]
        public int Flags;
        [FieldOffset(68)]
        public int NumChildren;
        [FieldOffset(72)]
        public int ParentIndex;
        [FieldOffset(76)]
        public VJointPos BonePos;
    };
    struct VRawBoneInfluence
    {
        public float Weight;
        public int PointIndex;
        public int BoneIndex;
    };
    [StructLayout(LayoutKind.Explicit)]
    struct AnimInfoBinary
    {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string Name;            // Animation's name
        [FieldOffset(64)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string Group;           // Animation's group name	
        [FieldOffset(128)]
        public int TotalBones;         // TotalBones * NumRawFrames is number of animation keys to digest.
        [FieldOffset(132)]
        public int RootInclude;        // 0 none 1 included 	(unused)
        [FieldOffset(136)]
        public int KeyCompressionStyle;// Reserved: variants in tradeoffs for compression.
        [FieldOffset(140)]
        public int KeyQuotum;          // Max key quotum for compression	
        [FieldOffset(144)]
        public float KeyReduction;     // desired 
        [FieldOffset(148)]
        public float TrackTime;        // explicit - can be overridden by the animation rate
        [FieldOffset(152)]
        public float AnimRate;         // frames per second.
        [FieldOffset(156)]
        public int StartBone;          // - Reserved: for partial animations (unused)
        [FieldOffset(160)]
        public int FirstRawFrame;      //
        [FieldOffset(164)]
        public int NumRawFrames;       // NumRawFrames and AnimRate dictate tracktime...
    };
    struct VQuatAnimKey
    {
        public Vector3 Position;       // Relative to parent.
        public Quaternion Orientation; // Relative to parent.
        public float Time;				// The duration until the next key (end key wraps to first...)
    };
    struct VScaleAnimKey
    {
        Vector3 ScaleVector;    // If uniform scaling is required, just use the X component..
        float Time;             // disregarded	
    };

    #pragma warning restore 169,0649

}
