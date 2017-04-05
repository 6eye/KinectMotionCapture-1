namespace AnimationTest
{
    using System;
    using System.Windows.Forms;
    using Microsoft.Kinect;
    using System.Drawing;

    public partial class KinectPanel : UserControl
    {
        private TransformSmoothParameters Parameters;
        private bool bRenderDepth;
        private bool bSensorEnabled;
        public KKinect Sensor;

        // Konstruktor
        public KinectPanel()
        {
            InitializeComponent();
            Parameters = new TransformSmoothParameters();
            ActivateElements(false);
            Sensor = new KKinect();
            Sensor.KinectRunning += new EventHandler(EVENT_SensorRunning);
        }

        public void Draw()
        {
            if (Sensor != null && Sensor.IsRunning())
            {
                Bitmap Frame = (bRenderDepth) ? Sensor.GetDepthFrame() : Sensor.GetColorFrame();
                if (Frame != null) pictureBox1.Image = Frame;
            }
        }
        public void ActivateElements(bool Activate)
        {
            KinectSmooth.Enabled = Activate;
            KinectBasic.Enabled = Activate;
            KinectElevation.Enabled = Activate;
        }

        // Paski
        private void EVENT_SmoothChange(object sender, EventArgs e)
        {
            float Smoothing = SmoothBar.Value / 100.0f;
            if (Smoothing >= 0 && Smoothing <= 1.0f)
            {
                LSmoothing.Text = "Value: " + Smoothing.ToString("0.00");
            }
        }
        private void EVENT_CorrectionChange(object sender, EventArgs e)
        {
            float Correction = CorrectionBar.Value / 100.0f;
            if (Correction >= 0 && Correction <= 1.0f)
            {
                LCorrection.Text = "Value: " + Correction.ToString("0.00");
            }
        }
        private void EVENT_PredictionChange(object sender, EventArgs e)
        {
            float Prediction = PredictionBar.Value / 100.0f;
            if (Prediction >= 0 && Prediction <= 1.0f)
            {
                LPrediction.Text = "Value: " + Prediction.ToString("0.00");
            }
        }
        private void EVENT_JitterRadiusChange(object sender, EventArgs e)
        {
            float JitterRadius = JitterRadiusBar.Value / 100.0f;
            if (JitterRadius >= 0 && JitterRadius <= 1.0f)
            {
                LJitterRadius.Text = "Value: " + JitterRadius.ToString("0.00");
            }
        }
        private void EVENT_MaxDeviationRadiusChange(object sender, EventArgs e)
        {
            float MaxDeviationRadius = MaxDeviationRadiusBar.Value / 100.0f;
            if (MaxDeviationRadius >= 0 && MaxDeviationRadius <= 1.0f)
            {
                LMaxDeviationRadius.Text = "Value: " + MaxDeviationRadius.ToString("0.00");
            }
        }
        // Przyciski
        private void EVENT_DefaultClick(object sender, EventArgs e)
        {
            Parameters.Smoothing = 0.5f;
            Parameters.Correction = 0.5f;
            Parameters.Prediction = 0.5f;
            Parameters.JitterRadius = 0.05f;
            Parameters.MaxDeviationRadius = 0.04f;
            // Paski
            SmoothBar.Value = (int)(Parameters.Smoothing * 100);
            CorrectionBar.Value = (int)(Parameters.Correction * 100);
            PredictionBar.Value = (int)(Parameters.Prediction * 100);
            JitterRadiusBar.Value = (int)(Parameters.JitterRadius * 100);
            MaxDeviationRadiusBar.Value = (int)(Parameters.MaxDeviationRadius * 100);
        }
        private void EVENT_ResetClick(object sender, EventArgs e)
        {
            Parameters.Smoothing = 0.0f;
            Parameters.Correction = 0.0f;
            Parameters.Prediction = 0.0f;
            Parameters.JitterRadius = 0.0f;
            Parameters.MaxDeviationRadius = 0.0f;
            // Paski
            SmoothBar.Value = (int)(Parameters.Smoothing * 100);
            CorrectionBar.Value = (int)(Parameters.Correction * 100);
            PredictionBar.Value = (int)(Parameters.Prediction * 100);
            JitterRadiusBar.Value = (int)(Parameters.JitterRadius * 100);
            MaxDeviationRadiusBar.Value = (int)(Parameters.MaxDeviationRadius * 100);
        }
        private void EVENT_ApplyClick(object sender, EventArgs e)
        {
            if (Sensor != null) Sensor.SetSmoothParameters(Parameters);
        }

        private void EVENT_TrakingModeChanged(object sender, EventArgs e)
        {
            if (Sensor != null)
                Sensor.SeatedMode = (TrackingModeBox.SelectedIndex == 0) ? false : true;
        }
        private void EVENT_DepthModeChanged(object sender, EventArgs e)
        {
            if (Sensor != null)
                Sensor.NearMode = (DepthModeBox.Checked == true) ? true : false;
        }
        private void EVENT_ElevationChanged(object sender, EventArgs e)
        {
            int value = 0;
            if (Sensor != null)
            {
                Sensor.KinectAngle = ElevationAngleBar.Value;
                value = Sensor.KinectAngle;
            }

            LElevation.Text = "Angle: " + value;
        }
        private void EVENT_ElevationDefault(object sender, EventArgs e)
        {
            int value = 0;
            if (Sensor != null)
            {
                Sensor.KinectAngle = value;
                ElevationAngleBar.Value = value;
                LElevation.Text = "Angle: " + value;
            }
        }

        private void EVENT_ButtonKinectSetup(object sender, EventArgs e)
        {
            if (Sensor != null)
            {
                if (Sensor.IsRunning())
                {
                    Sensor.StopSensor();
                    bSensorEnabled = false;
                    ActivateElements(false);
                    button4.Text = "Enable Kinect";
                    pictureBox1.Image = null;
                }
                else
                {
                    Sensor.StartSensor();
                    if (Sensor.IsRunning())
                    {
                        bSensorEnabled = true;
                        ActivateElements(true);
                        button4.Text = "Disable Kinect";
                    }
                }
            }
        }
        private void EVENT_ButtonRenderMode(object sender, EventArgs e)
        {
            bRenderDepth = (comboBox1.SelectedIndex == 0) ? false : true;
        }
        private void EVENT_SensorRunning(object sender, EventArgs e)
        {
            if(Sensor != null)
            {
                if (!Sensor.IsRunning() && bSensorEnabled)
                {
                    bSensorEnabled = false;
                    ActivateElements(false);
                    button4.Text = "Enable Kinect";
                    pictureBox1.Image = null;
                    EVENT_ResetClick(this, EventArgs.Empty);
                }
            }
        }
    }
}
