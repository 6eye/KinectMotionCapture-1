namespace AnimationTest
{
    using System;
    using Microsoft.Xna.Framework;

    class KMath
    {
        public static Vector3 GetAngleFromQuaternion(Quaternion q)
        {
            float sp = -2.0f * (q.Y * q.Z - q.W * q.X);
            float Yaw, Pitch, Roll;

            if (Math.Abs(sp) == 1.0f)
            {
                Pitch = (float)Math.PI * 2 * sp;
                Yaw = (float)Math.Atan2(-q.X * q.Z + q.W * q.Y, 0.5f - q.Y * q.Y - q.Z * q.Z);
                Roll = 0.0f;
            }
            else
            {
                Pitch = (float)Math.Asin(sp);
                Yaw = (float)Math.Atan2(q.X * q.Z + q.W * q.Y, 0.5f - q.X * q.X - q.Y * q.Y);
                Roll = (float)Math.Atan2(q.X * q.Y + q.W * q.Z, 0.5f - q.X * q.X - q.Z * q.Z);
            }


            Pitch = MathHelper.ToDegrees(Pitch);
            Yaw = MathHelper.ToDegrees(Yaw);
            Roll = MathHelper.ToDegrees(Roll);
            return new Vector3(Yaw, Pitch, Roll);
        }
        public static Vector3 KINECTVectorToXNA(Microsoft.Kinect.SkeletonPoint point)
        {
            return new Vector3(point.X, point.Y, point.Z);
        }
        public static Quaternion KINECTQuatToXNA(Microsoft.Kinect.Vector4 r)
        {
            return new Quaternion(r.X, r.Y, r.Z, r.W);
        }
        public static Matrix KINECTMatToXNA(Microsoft.Kinect.Matrix4 m)
        {
            return new Matrix(m.M11, m.M12, m.M13, m.M14, m.M21, m.M22, m.M23, m.M24, m.M31, m.M32, m.M33, m.M34, m.M41, m.M42, m.M43, m.M44);
        }
    }
}
