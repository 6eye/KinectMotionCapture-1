namespace AnimationTest
{
    using Microsoft.Xna.Framework;

    public class KCamera
    {
        private Vector3 StartPosition;
        private Vector3 CameraPosition;
        private Vector3 CameraTarget;
        private float CameraRotation;
        private float CameraDistance;

        public Matrix View;

        public KCamera(float Distance = 200)
        {
            CameraTarget = Vector3.Zero;
            CameraDistance = Distance;
            StartPosition = new Vector3(CameraDistance, 0, CameraDistance);
            RecalculateCamera();
        }
        public void Zoom(float Zoom)
        {
            CameraDistance += Zoom;
            StartPosition = new Vector3(CameraDistance, 0, CameraDistance);
            RecalculateCamera();
        }
        public void Move(Vector3 Move)
        {
            StartPosition += Move;
            CameraTarget += Move;
            RecalculateCamera();
        }
        public void Rotate(float Rotate)
        {
            CameraRotation += Rotate;
            RecalculateCamera();
        }
        private void RecalculateCamera()
        {
            CameraPosition = Vector3.Transform(StartPosition, Quaternion.CreateFromAxisAngle(Vector3.UnitZ, CameraRotation));
            View = Matrix.CreateLookAt(CameraPosition, CameraTarget, Vector3.UnitZ);
        }
    }
}
