namespace AnimationTest
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    class KMeshHelper
    {
        public static void CalculateInvertBindPose(int BoneIndex, Matrix ParentTransform,ref VBone[] bones, ref Matrix[] IBindPose)
        {
            Quaternion rotation = bones[BoneIndex].BonePos.Orientation;
            if (bones[BoneIndex].ParentIndex != -1) rotation.W = -rotation.W;

            Matrix LocalTransform = Matrix.CreateFromQuaternion(rotation) * Matrix.CreateTranslation(bones[BoneIndex].BonePos.Position);
            IBindPose[BoneIndex] = ParentTransform * Matrix.Invert(LocalTransform);

            for (int i = 0; i < bones.Length; i++)
                if (bones[i].ParentIndex == BoneIndex) CalculateInvertBindPose(i, IBindPose[BoneIndex],ref bones,ref IBindPose);
        }
        public static void CalculateBoneMatrix(int BoneIndex, Matrix ParentTransform, ref VBone[] f, ref Matrix[] IBindPose, ref Matrix[] BoneTransform)
        {
            Quaternion rotation = f[BoneIndex].BonePos.Orientation;
            if (f[BoneIndex].ParentIndex != -1) rotation.W = -rotation.W;

            Matrix LocalTransform = Matrix.CreateFromQuaternion(rotation) * Matrix.CreateTranslation(f[BoneIndex].BonePos.Position);
            Matrix GlobalTransform = LocalTransform * ParentTransform;
            BoneTransform[BoneIndex] = IBindPose[BoneIndex] * GlobalTransform;

            for (int i = 0; i < f.Length; i++)
                if (f[i].ParentIndex == BoneIndex) CalculateBoneMatrix(i, GlobalTransform, ref f, ref IBindPose, ref BoneTransform);
        }
        public static VBone[] CopyBones(VBone[] Bones)
        {
            List<VBone> b = new List<VBone>();
            foreach (VBone bone in Bones)
                b.Add(bone);
            return b.ToArray();
        }
    }
}
