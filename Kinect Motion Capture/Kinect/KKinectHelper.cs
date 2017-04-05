namespace AnimationTest
{
    using Microsoft.Kinect;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using Microsoft.Xna.Framework;

    class KKinectHelper
    {
    
        public static string GetDeviceStatusDesc(KinectStatus status)
        {
            string s = "";
            switch (status)
            {
                case KinectStatus.Connected:
                    s = "Device Connected";
                    break;
                case KinectStatus.DeviceNotGenuine:
                    s = "Device not genuise";
                    break;
                case KinectStatus.DeviceNotSupported:
                    s = "Device not supported";
                    break;
                case KinectStatus.Disconnected:
                    s = "Device disconnected";
                    break;
                case KinectStatus.Error:
                    s = "Error!";
                    break;
                case KinectStatus.Initializing:
                    s = "Initializing...";
                    break;
                case KinectStatus.InsufficientBandwidth:
                    s = "Bandwidth problem!";
                    break;
                case KinectStatus.NotPowered:
                    s = "Device not powered!";
                    break;
                case KinectStatus.NotReady:
                    s = "Device not ready!";
                    break;
                case KinectStatus.Undefined:
                    s = "Unknown error";
                    break;
            }
            return s;
        }
        public static Bitmap GetColorFrame(ColorImageFrame frame)
        {
            byte[] pixeldata = new byte[frame.PixelDataLength];
            frame.CopyPixelDataTo(pixeldata);
            Bitmap bmap = new Bitmap(frame.Width, frame.Height, PixelFormat.Format32bppRgb);
            BitmapData bmapdata = bmap.LockBits(new System.Drawing.Rectangle(0, 0, frame.Width, frame.Height), ImageLockMode.WriteOnly, bmap.PixelFormat);
            IntPtr ptr = bmapdata.Scan0;
            Marshal.Copy(pixeldata, 0, ptr, frame.PixelDataLength);
            bmap.UnlockBits(bmapdata);
            return bmap;
        }
        public static Bitmap GetDepthFrame(DepthImageFrame frame)
        {
            short[] pixelData = new short[frame.PixelDataLength];
            DepthImagePixel[] depthData = new DepthImagePixel[frame.PixelDataLength];

            frame.CopyDepthImagePixelDataTo(depthData);
            for (int i = 0; i < frame.PixelDataLength; i++)
                pixelData[i] = depthData[i].Depth;

            Bitmap bmap = new Bitmap(frame.Width, frame.Height, PixelFormat.Format16bppRgb555);//Format32bppRgb Format16bppRgb555
            BitmapData bmapdata = bmap.LockBits(new System.Drawing.Rectangle(0, 0, frame.Width, frame.Height), ImageLockMode.WriteOnly, bmap.PixelFormat);
            IntPtr ptr = bmapdata.Scan0;
            Marshal.Copy(pixelData, 0, ptr, frame.Width * frame.Height);
            bmap.UnlockBits(bmapdata);
            return bmap;
        }

        private static Vector3 GetDirection(JointType t1, JointType t2, Skeleton skeleton)
        {
            Vector3 p1 = KMath.KINECTVectorToXNA(skeleton.Joints[t1].Position);
            Vector3 p2 = KMath.KINECTVectorToXNA(skeleton.Joints[t2].Position);
            return p2 - p1;
        }
        private static Quaternion MakeQuaternion(Vector3 xAxis, Vector3 yAxis, Vector3 zAxis)
        {
            Matrix mat = new Matrix(xAxis.X, -yAxis.X, zAxis.X, 0,
                                    -xAxis.Y, yAxis.Y, -zAxis.Y, 0,
                                     xAxis.Z, -yAxis.Z, zAxis.Z, 0,
                                     0, 0, 0, 1);
            return Quaternion.CreateFromRotationMatrix(mat);
        }
        private static Quaternion makeOrientationFromX(Vector3 v)
        {
            Vector3 vx = Vector3.Zero;
            Vector3 vy = Vector3.Zero;
            Vector3 vz = Vector3.Zero;

            v.Normalize();
            vx = v;

            vy.X = 0.0f;
            vy.Y = vx.Z;
            vy.Z = -vx.Y;
            vy.Normalize();

            vz = Vector3.Cross(vx, vy);

            return MakeQuaternion(vx, vy, vz);
        }
        private static Quaternion makeOrientationFromY(Vector3 v)
        {
            Vector3 vx = Vector3.Zero;
            Vector3 vy = Vector3.Zero;
            Vector3 vz = Vector3.Zero;

            v.Normalize();
            vy = v;

            vx.X = vy.Y;
            vx.Y = -vy.X;
            vx.Z = 0.0f;
            vx.Normalize();

            vz = Vector3.Cross(vx, vy);

            return MakeQuaternion(vx, vy, vz);
        }
        private static Quaternion makeOrientationFromZ(Vector3 v)
        {
            Vector3 vx = Vector3.Zero;
            Vector3 vy = Vector3.Zero;
            Vector3 vz = Vector3.Zero;

            v.Normalize();
            vz = v;

            vx.X = vz.Y;
            vx.Y = -vz.X;
            vx.Z = 0.0f;
            vx.Normalize();

            vy = Vector3.Cross(vz, vx);

            return MakeQuaternion(vx, vy, vz);
        }
        private static Quaternion makeOrientationFromXY(Vector3 v_x, Vector3 v_y)
        {
            Vector3 vx = Vector3.Zero;
            Vector3 vy = Vector3.Zero;
            Vector3 vz = Vector3.Zero;

            v_x.Normalize();
            v_y.Normalize();

            vx = v_x;
            vz = Vector3.Cross(vx, v_y);
            vy = Vector3.Cross(vz, vx);

            return MakeQuaternion(vx, vy, vz);
        }
        private static Quaternion makeOrientationFromYX(Vector3 v_x, Vector3 v_y)
        {
            Vector3 vx = Vector3.Zero;
            Vector3 vy = Vector3.Zero;
            Vector3 vz = Vector3.Zero;
            v_x.Normalize();
            v_y.Normalize();

            vy = v_y;
            vz = Vector3.Cross(v_x, vy);
            vx = Vector3.Cross(vy, vz);

            return MakeQuaternion(vx, vy, vz);
        }
        private static Quaternion makeOrientationFromYZ(Vector3 v_y, Vector3 v_z)
        {
            Vector3 vx = Vector3.Zero;
            Vector3 vy = Vector3.Zero;
            Vector3 vz = Vector3.Zero;

            v_y.Normalize();
            v_z.Normalize();

            vy = v_y;
            vx = Vector3.Cross(vy, v_z);
            vz = Vector3.Cross(vx, vy);

            return MakeQuaternion(vx, vy, vz);
        }
        public static Quaternion RecalculateKinectJointOrientation(JointType type, Skeleton skeleton)
        {
            Quaternion orientation = Quaternion.Identity;
            Quaternion o = Quaternion.Identity;
            Matrix rotation;

            Vector3 vx = Vector3.UnitX;
            Vector3 vy = Vector3.UnitY;
            Vector3 vz = Vector3.UnitZ;

            switch (type)
            {
                // KARK
                case JointType.ShoulderCenter:
                    vy = GetDirection(JointType.ShoulderLeft, JointType.ShoulderRight, skeleton);
                    vx = GetDirection(JointType.Head, JointType.ShoulderCenter, skeleton);
                    o = makeOrientationFromYX(vx, vy);
                    o = new Quaternion(o.X, -o.Z, o.Y, o.W);
                    rotation = Matrix.CreateFromQuaternion(o) * Matrix.CreateRotationY(MathHelper.ToRadians(-90)); // Potrzebne czy tylko przy SeatedMode ?
                    orientation = Quaternion.CreateFromRotationMatrix(rotation);
                    break;
                // RAMIONA
                case JointType.ShoulderLeft: // OK
                    vy = GetDirection(JointType.ShoulderLeft, JointType.ElbowLeft, skeleton);
                    o = makeOrientationFromY(vy);
                    o = new Quaternion(o.X, -o.Z, o.Y, o.W);
                    rotation = Matrix.CreateFromQuaternion(o) * Matrix.CreateRotationY(MathHelper.ToRadians(90));
                    orientation = Quaternion.CreateFromRotationMatrix(rotation);
                    break;
                case JointType.ShoulderRight: // OK
                    vy = GetDirection(JointType.ShoulderRight, JointType.ElbowRight, skeleton);
                    o = makeOrientationFromY(vy);
                    o = new Quaternion(o.X, -o.Z, o.Y, o.W);
                    rotation = Matrix.CreateFromQuaternion(o) * Matrix.CreateRotationY(MathHelper.ToRadians(-90));
                    orientation = Quaternion.CreateFromRotationMatrix(rotation);
                    break;
                // ŁOKCIE
                case JointType.ElbowLeft:   // OK
                    vy = GetDirection(JointType.WristLeft, JointType.ElbowLeft, skeleton);
                    o = makeOrientationFromYZ(vy, vz);
                    o = new Quaternion(0, 0, -o.Z, -o.W);
                    rotation = Matrix.CreateFromQuaternion(o) * Matrix.CreateRotationZ(MathHelper.ToRadians(90));
                    orientation = Quaternion.CreateFromRotationMatrix(rotation);
                    break;
                case JointType.ElbowRight: // OK
                    vy = GetDirection(JointType.WristRight, JointType.ElbowRight, skeleton);
                    o = makeOrientationFromYZ(vy, vz);
                    o = new Quaternion(0, 0, -o.Z, -o.W);
                    rotation = Matrix.CreateFromQuaternion(o) * Matrix.CreateRotationZ(MathHelper.ToRadians(-90));
                    orientation = Quaternion.CreateFromRotationMatrix(rotation);
                    break;
                // NADGARSTEKI/ DLONIE
                case JointType.WristLeft: // OK
                    vy = GetDirection(JointType.WristLeft, JointType.HandLeft, skeleton);
                    o = makeOrientationFromYZ(vy, vz);
                    o = new Quaternion(o.X, -o.Z, o.Y, o.W);
                    rotation = Matrix.CreateFromQuaternion(o) * Matrix.CreateRotationY(MathHelper.ToRadians(90));
                    orientation = Quaternion.CreateFromRotationMatrix(rotation);
                    break;
                case JointType.WristRight: // OK
                    vy = GetDirection(JointType.WristRight, JointType.HandRight, skeleton);
                    o = makeOrientationFromYZ(vy, vz);
                    o = new Quaternion(o.X, -o.Z, o.Y, o.W);
                    rotation = Matrix.CreateFromQuaternion(o) * Matrix.CreateRotationY(MathHelper.ToRadians(-90));
                    orientation = Quaternion.CreateFromRotationMatrix(rotation);
                    break;
                // DLONIE - pomijane
                case JointType.HandLeft:  // Identity
                    break;
                case JointType.HandRight: // Identity
                    break;
                // KREGOSLUP
                case JointType.Spine:   // OK
                    vx = GetDirection(JointType.ShoulderLeft, JointType.ShoulderRight, skeleton);
                    vy = GetDirection(JointType.Spine, JointType.ShoulderCenter, skeleton);
                    o = makeOrientationFromYX(vx, vy);
                    orientation = new Quaternion(o.X, -o.Z, o.Y, o.W);
                    break;
                // ROOT
                case JointType.HipCenter:
                    vx = GetDirection(JointType.HipLeft, JointType.HipRight, skeleton);
                    o = makeOrientationFromXY(vx, vy);
                    orientation = new Quaternion(o.X, -o.Z, o.Y, o.W);
                    break;
                // NOGI
                case JointType.HipLeft:  // OK
                    vy = GetDirection(JointType.KneeLeft, JointType.HipLeft, skeleton);
                    vx = GetDirection(JointType.HipLeft, JointType.HipRight, skeleton);
                    o = makeOrientationFromYX(vx, vy);
                    orientation = new Quaternion(o.X, -o.Z, o.Y, o.W);
                    break;
                case JointType.HipRight: // OK
                    vy = GetDirection(JointType.KneeRight, JointType.HipRight, skeleton);
                    vx = GetDirection(JointType.HipLeft, JointType.HipRight, skeleton);
                    o = makeOrientationFromYX(vx, vy);
                    orientation = new Quaternion(o.X, -o.Z, o.Y, o.W);
                    break;
                // KOLANA
                case JointType.KneeLeft:  // OK
                    vy = GetDirection(JointType.AnkleLeft, JointType.KneeLeft, skeleton);
                    o = makeOrientationFromY(vy);
                    orientation = new Quaternion(o.X, -o.Z, o.Y, o.W) * Quaternion.Inverse(KKinectHelper.RecalculateKinectJointOrientation(JointType.HipLeft, skeleton));
                    break;
                case JointType.KneeRight: // OK
                    vy = GetDirection(JointType.AnkleRight, JointType.KneeRight, skeleton);
                    o = makeOrientationFromY(vy);
                    orientation = new Quaternion(o.X, -o.Z, o.Y, o.W) * Quaternion.Inverse(KKinectHelper.RecalculateKinectJointOrientation(JointType.HipRight, skeleton));
                    break;
                // PIETY/STOPY
                case JointType.AnkleLeft:  // OK
                    vy = GetDirection(JointType.AnkleLeft, JointType.KneeLeft, skeleton);
                    vz = GetDirection(JointType.FootLeft, JointType.AnkleLeft, skeleton);
                    o = makeOrientationFromYZ(vy, vz);
                    orientation = new Quaternion(o.X, 0, o.Y, o.W);
                    break;
                case JointType.AnkleRight: // OK
                    vy = GetDirection(JointType.AnkleRight, JointType.KneeRight, skeleton);
                    vz = GetDirection(JointType.FootRight, JointType.AnkleRight, skeleton);
                    o = makeOrientationFromYZ(vy, vz);
                    orientation = new Quaternion(o.X, 0, o.Y, o.W);
                    break;
                // STOPY - pomijane
                case JointType.FootLeft:   // Identity
                    break;
                case JointType.FootRight:  // Identity
                    break;
            }

            return orientation;
        }
    }
}
