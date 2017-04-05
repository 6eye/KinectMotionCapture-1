namespace AnimationTest
{
    using System;
    using System.Linq;
    using System.Drawing;
    using Microsoft.Kinect;
    using System.Diagnostics;
 
    public class KKinect
    {
        public KinectSensor Device;
        public KinectStatus Status;
        public bool IsTracking;

        private bool SensorInitialized;
        private Skeleton[] SkeletonData;

        public int KinectAngle
        {
            set
            {
                if (Device != null)
                {
                    try
                    {
                        Device.ElevationAngle = value;
                    }
                    catch {}
                }
            }
            get
            {
                if (Device != null)
                    return Device.ElevationAngle;
                return 0;
            }
        }
        public bool SeatedMode
        {
            set
            {
                if (Device != null)
                {
                    Device.SkeletonStream.TrackingMode = (value) ? SkeletonTrackingMode.Seated : SkeletonTrackingMode.Default;
                }
            }
        }
        public bool NearMode
        {
            set
            {
                if (Device != null)
                {
                    Device.SkeletonStream.EnableTrackingInNearRange = value;
                }
            }
        }

        public KKinect()
        {
            Status = KinectStatus.Disconnected;
            Device = KinectSensor.KinectSensors.FirstOrDefault();
            if (Device != null)
            {
                Status = Device.Status;
                KinectSensor.KinectSensors.StatusChanged += new EventHandler<StatusChangedEventArgs>(OnStatusChange);
            }
        }

        private void InitializeSensor()
        {
            if (!SensorInitialized)
            {
                Device.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
                Device.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                SkeletonData = new Skeleton[Device.SkeletonStream.FrameSkeletonArrayLength];
                Device.SkeletonStream.EnableTrackingInNearRange = true;
                Device.SkeletonStream.Enable();
                SeatedMode = false;
                NearMode = false;
                SensorInitialized = true;
            }
        }

        public Skeleton GetSkeletonFrame()
        {
            if (Device != null)
            {
                using (SkeletonFrame skeletonFrame = Device.SkeletonStream.OpenNextFrame(0))
                {
                    if (skeletonFrame != null && SkeletonData != null)
                    {
                        skeletonFrame.CopySkeletonDataTo(SkeletonData);

                        foreach (Skeleton skel in SkeletonData)
                        {
                            if (skel.TrackingState == SkeletonTrackingState.Tracked)
                            {
                                if (IsTracking == false && TrackingChanged != null)
                                {
                                    IsTracking = true;
                                    TrackingChanged(this, EventArgs.Empty);
                                }
                                return skel;
                            }
                        }

                        if (IsTracking == true && TrackingChanged != null)
                        {
                            IsTracking = false;
                            TrackingChanged(this, EventArgs.Empty);
                        }
                        
                    }
                }
            }
            return null;
        }
        public Bitmap GetColorFrame()
        {
            if (Device != null)
            {
                using (ColorImageFrame colorFrame = Device.ColorStream.OpenNextFrame(0))
                {
                    if (colorFrame != null) 
                        return KKinectHelper.GetColorFrame(colorFrame);
                    return null;
                }
            } 
            return null;
        }
        public Bitmap GetDepthFrame()
        {
            if (Device != null)
            {
                using (DepthImageFrame depthFrame = Device.DepthStream.OpenNextFrame(0))
                {
                    if (depthFrame != null)
                        return KKinectHelper.GetDepthFrame(depthFrame);
                    return null;
                }
            }
            return null;
        }

        public void SetSmoothParameters(TransformSmoothParameters parameters)
        {
            if (Device != null) Device.SkeletonStream.Enable(parameters);
        }

        public void StartSensor()
        {
            if (Device != null && Status == KinectStatus.Connected)
            {
                InitializeSensor();
                Device.Start();
                if (KinectRunning != null)
                    KinectRunning(this, EventArgs.Empty);
            }
        }
        public void StopSensor()
        {
            if (IsRunning())
            {
                Device.Stop();
                if (KinectRunning != null)
                    KinectRunning(this, EventArgs.Empty);
            }
        }
        public bool IsRunning()
        {
            if (Device != null) return Device.IsRunning;
            return false;
        }

        // Zdarzenia
        private void OnStatusChange(object sender, StatusChangedEventArgs e)
        {
            if (Device != null)
            {
                Status = Device.Status;
                if (Status != KinectStatus.Connected)
                    StopSensor();
            }
            if (StatusChanged != null)
                StatusChanged(this, EventArgs.Empty);
        }
        public event EventHandler KinectRunning;
        public event EventHandler StatusChanged;
        public event EventHandler TrackingChanged;
    }
}
