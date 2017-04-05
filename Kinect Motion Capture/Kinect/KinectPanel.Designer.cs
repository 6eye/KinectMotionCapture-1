namespace AnimationTest
{
    partial class KinectPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SmoothBar = new System.Windows.Forms.TrackBar();
            this.PredictionBar = new System.Windows.Forms.TrackBar();
            this.CorrectionBar = new System.Windows.Forms.TrackBar();
            this.JitterRadiusBar = new System.Windows.Forms.TrackBar();
            this.MaxDeviationRadiusBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LSmoothing = new System.Windows.Forms.Label();
            this.LCorrection = new System.Windows.Forms.Label();
            this.LJitterRadius = new System.Windows.Forms.Label();
            this.LPrediction = new System.Windows.Forms.Label();
            this.LMaxDeviationRadius = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.KinectSmooth = new System.Windows.Forms.GroupBox();
            this.KinectBasic = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DepthModeBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TrackingModeBox = new System.Windows.Forms.ComboBox();
            this.KinectElevation = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.LElevation = new System.Windows.Forms.Label();
            this.ElevationAngleBar = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SmoothBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PredictionBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CorrectionBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JitterRadiusBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxDeviationRadiusBar)).BeginInit();
            this.KinectSmooth.SuspendLayout();
            this.KinectBasic.SuspendLayout();
            this.KinectElevation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElevationAngleBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SmoothBar
            // 
            this.SmoothBar.BackColor = System.Drawing.Color.White;
            this.SmoothBar.Location = new System.Drawing.Point(6, 21);
            this.SmoothBar.Maximum = 100;
            this.SmoothBar.Name = "SmoothBar";
            this.SmoothBar.Size = new System.Drawing.Size(165, 45);
            this.SmoothBar.TabIndex = 0;
            this.SmoothBar.TickFrequency = 5;
            this.SmoothBar.ValueChanged += new System.EventHandler(this.EVENT_SmoothChange);
            // 
            // PredictionBar
            // 
            this.PredictionBar.BackColor = System.Drawing.Color.White;
            this.PredictionBar.Location = new System.Drawing.Point(6, 107);
            this.PredictionBar.Maximum = 100;
            this.PredictionBar.Name = "PredictionBar";
            this.PredictionBar.Size = new System.Drawing.Size(165, 45);
            this.PredictionBar.TabIndex = 1;
            this.PredictionBar.TickFrequency = 5;
            this.PredictionBar.ValueChanged += new System.EventHandler(this.EVENT_PredictionChange);
            // 
            // CorrectionBar
            // 
            this.CorrectionBar.BackColor = System.Drawing.Color.White;
            this.CorrectionBar.Location = new System.Drawing.Point(6, 64);
            this.CorrectionBar.Maximum = 100;
            this.CorrectionBar.Name = "CorrectionBar";
            this.CorrectionBar.Size = new System.Drawing.Size(165, 45);
            this.CorrectionBar.TabIndex = 2;
            this.CorrectionBar.TickFrequency = 5;
            this.CorrectionBar.ValueChanged += new System.EventHandler(this.EVENT_CorrectionChange);
            // 
            // JitterRadiusBar
            // 
            this.JitterRadiusBar.BackColor = System.Drawing.Color.White;
            this.JitterRadiusBar.Location = new System.Drawing.Point(6, 150);
            this.JitterRadiusBar.Maximum = 100;
            this.JitterRadiusBar.Name = "JitterRadiusBar";
            this.JitterRadiusBar.Size = new System.Drawing.Size(165, 45);
            this.JitterRadiusBar.TabIndex = 3;
            this.JitterRadiusBar.TickFrequency = 5;
            this.JitterRadiusBar.ValueChanged += new System.EventHandler(this.EVENT_JitterRadiusChange);
            // 
            // MaxDeviationRadiusBar
            // 
            this.MaxDeviationRadiusBar.BackColor = System.Drawing.Color.White;
            this.MaxDeviationRadiusBar.Location = new System.Drawing.Point(6, 193);
            this.MaxDeviationRadiusBar.Maximum = 100;
            this.MaxDeviationRadiusBar.Name = "MaxDeviationRadiusBar";
            this.MaxDeviationRadiusBar.Size = new System.Drawing.Size(165, 45);
            this.MaxDeviationRadiusBar.TabIndex = 4;
            this.MaxDeviationRadiusBar.TickFrequency = 5;
            this.MaxDeviationRadiusBar.ValueChanged += new System.EventHandler(this.EVENT_MaxDeviationRadiusChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Smoothing";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Correction";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Prediction";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Jitter Radius";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(166, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Max Deviation";
            // 
            // LSmoothing
            // 
            this.LSmoothing.AutoSize = true;
            this.LSmoothing.Location = new System.Drawing.Point(166, 34);
            this.LSmoothing.Name = "LSmoothing";
            this.LSmoothing.Size = new System.Drawing.Size(61, 13);
            this.LSmoothing.TabIndex = 10;
            this.LSmoothing.Text = "Value: 0.00";
            // 
            // LCorrection
            // 
            this.LCorrection.AutoSize = true;
            this.LCorrection.Location = new System.Drawing.Point(166, 76);
            this.LCorrection.Name = "LCorrection";
            this.LCorrection.Size = new System.Drawing.Size(61, 13);
            this.LCorrection.TabIndex = 11;
            this.LCorrection.Text = "Value: 0.00";
            // 
            // LJitterRadius
            // 
            this.LJitterRadius.AutoSize = true;
            this.LJitterRadius.Location = new System.Drawing.Point(166, 163);
            this.LJitterRadius.Name = "LJitterRadius";
            this.LJitterRadius.Size = new System.Drawing.Size(61, 13);
            this.LJitterRadius.TabIndex = 13;
            this.LJitterRadius.Text = "Value: 0.00";
            // 
            // LPrediction
            // 
            this.LPrediction.AutoSize = true;
            this.LPrediction.Location = new System.Drawing.Point(166, 119);
            this.LPrediction.Name = "LPrediction";
            this.LPrediction.Size = new System.Drawing.Size(61, 13);
            this.LPrediction.TabIndex = 12;
            this.LPrediction.Text = "Value: 0.00";
            // 
            // LMaxDeviationRadius
            // 
            this.LMaxDeviationRadius.AutoSize = true;
            this.LMaxDeviationRadius.Location = new System.Drawing.Point(166, 205);
            this.LMaxDeviationRadius.Name = "LMaxDeviationRadius";
            this.LMaxDeviationRadius.Size = new System.Drawing.Size(61, 13);
            this.LMaxDeviationRadius.TabIndex = 14;
            this.LMaxDeviationRadius.Text = "Value: 0.00";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Default";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.EVENT_DefaultClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(87, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.EVENT_ResetClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(163, 227);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Apply";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.EVENT_ApplyClick);
            // 
            // KinectSmooth
            // 
            this.KinectSmooth.Controls.Add(this.LCorrection);
            this.KinectSmooth.Controls.Add(this.label2);
            this.KinectSmooth.Controls.Add(this.LJitterRadius);
            this.KinectSmooth.Controls.Add(this.LPrediction);
            this.KinectSmooth.Controls.Add(this.LSmoothing);
            this.KinectSmooth.Controls.Add(this.label5);
            this.KinectSmooth.Controls.Add(this.label4);
            this.KinectSmooth.Controls.Add(this.label3);
            this.KinectSmooth.Controls.Add(this.label1);
            this.KinectSmooth.Controls.Add(this.button3);
            this.KinectSmooth.Controls.Add(this.SmoothBar);
            this.KinectSmooth.Controls.Add(this.button2);
            this.KinectSmooth.Controls.Add(this.PredictionBar);
            this.KinectSmooth.Controls.Add(this.button1);
            this.KinectSmooth.Controls.Add(this.LMaxDeviationRadius);
            this.KinectSmooth.Controls.Add(this.JitterRadiusBar);
            this.KinectSmooth.Controls.Add(this.MaxDeviationRadiusBar);
            this.KinectSmooth.Controls.Add(this.CorrectionBar);
            this.KinectSmooth.Location = new System.Drawing.Point(1, 301);
            this.KinectSmooth.Name = "KinectSmooth";
            this.KinectSmooth.Size = new System.Drawing.Size(243, 260);
            this.KinectSmooth.TabIndex = 18;
            this.KinectSmooth.TabStop = false;
            this.KinectSmooth.Text = "Kinect Smooth Parameters";
            // 
            // KinectBasic
            // 
            this.KinectBasic.Controls.Add(this.label7);
            this.KinectBasic.Controls.Add(this.DepthModeBox);
            this.KinectBasic.Controls.Add(this.label6);
            this.KinectBasic.Controls.Add(this.TrackingModeBox);
            this.KinectBasic.Location = new System.Drawing.Point(1, 226);
            this.KinectBasic.Name = "KinectBasic";
            this.KinectBasic.Size = new System.Drawing.Size(243, 72);
            this.KinectBasic.TabIndex = 19;
            this.KinectBasic.TabStop = false;
            this.KinectBasic.Text = "Kinect Basic Settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Near Depth Mode:";
            // 
            // DepthModeBox
            // 
            this.DepthModeBox.AutoSize = true;
            this.DepthModeBox.Location = new System.Drawing.Point(112, 48);
            this.DepthModeBox.Name = "DepthModeBox";
            this.DepthModeBox.Size = new System.Drawing.Size(59, 17);
            this.DepthModeBox.TabIndex = 2;
            this.DepthModeBox.Text = "Enable";
            this.DepthModeBox.UseVisualStyleBackColor = true;
            this.DepthModeBox.CheckedChanged += new System.EventHandler(this.EVENT_DepthModeChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Tracking Mode:";
            // 
            // TrackingModeBox
            // 
            this.TrackingModeBox.FormattingEnabled = true;
            this.TrackingModeBox.Items.AddRange(new object[] {
            "Default",
            "Seated"});
            this.TrackingModeBox.Location = new System.Drawing.Point(112, 19);
            this.TrackingModeBox.Name = "TrackingModeBox";
            this.TrackingModeBox.Size = new System.Drawing.Size(121, 21);
            this.TrackingModeBox.TabIndex = 0;
            this.TrackingModeBox.Text = "Default";
            this.TrackingModeBox.SelectedIndexChanged += new System.EventHandler(this.EVENT_TrakingModeChanged);
            // 
            // KinectElevation
            // 
            this.KinectElevation.Controls.Add(this.button4);
            this.KinectElevation.Controls.Add(this.LElevation);
            this.KinectElevation.Controls.Add(this.ElevationAngleBar);
            this.KinectElevation.Location = new System.Drawing.Point(1, 564);
            this.KinectElevation.Name = "KinectElevation";
            this.KinectElevation.Size = new System.Drawing.Size(243, 65);
            this.KinectElevation.TabIndex = 20;
            this.KinectElevation.TabStop = false;
            this.KinectElevation.Text = "Kinect Elevation Angle";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(167, 33);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Default";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.EVENT_ElevationDefault);
            // 
            // LElevation
            // 
            this.LElevation.AutoSize = true;
            this.LElevation.Location = new System.Drawing.Point(179, 18);
            this.LElevation.Name = "LElevation";
            this.LElevation.Size = new System.Drawing.Size(46, 13);
            this.LElevation.TabIndex = 1;
            this.LElevation.Text = "Angle: 0";
            // 
            // ElevationAngleBar
            // 
            this.ElevationAngleBar.Location = new System.Drawing.Point(11, 16);
            this.ElevationAngleBar.Maximum = 27;
            this.ElevationAngleBar.Minimum = -27;
            this.ElevationAngleBar.Name = "ElevationAngleBar";
            this.ElevationAngleBar.Size = new System.Drawing.Size(160, 45);
            this.ElevationAngleBar.SmallChange = 5;
            this.ElevationAngleBar.TabIndex = 0;
            this.ElevationAngleBar.TickFrequency = 5;
            this.ElevationAngleBar.ValueChanged += new System.EventHandler(this.EVENT_ElevationChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-2, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Render Mode:";
            // 
            // comboBox1
            // 
            this.comboBox1.Items.AddRange(new object[] {
            "Color",
            "Depth"});
            this.comboBox1.Location = new System.Drawing.Point(74, 1);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(58, 21);
            this.comboBox1.TabIndex = 22;
            this.comboBox1.Text = "Color";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.EVENT_ButtonRenderMode);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(138, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(106, 23);
            this.button5.TabIndex = 24;
            this.button5.Text = "Enable Kinect";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.EVENT_ButtonKinectSetup);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(1, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(243, 191);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // KinectPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.KinectElevation);
            this.Controls.Add(this.KinectBasic);
            this.Controls.Add(this.KinectSmooth);
            this.Name = "KinectPanel";
            this.Size = new System.Drawing.Size(245, 632);
            ((System.ComponentModel.ISupportInitialize)(this.SmoothBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PredictionBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CorrectionBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JitterRadiusBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxDeviationRadiusBar)).EndInit();
            this.KinectSmooth.ResumeLayout(false);
            this.KinectSmooth.PerformLayout();
            this.KinectBasic.ResumeLayout(false);
            this.KinectBasic.PerformLayout();
            this.KinectElevation.ResumeLayout(false);
            this.KinectElevation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElevationAngleBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar SmoothBar;
        private System.Windows.Forms.TrackBar PredictionBar;
        private System.Windows.Forms.TrackBar CorrectionBar;
        private System.Windows.Forms.TrackBar JitterRadiusBar;
        private System.Windows.Forms.TrackBar MaxDeviationRadiusBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LSmoothing;
        private System.Windows.Forms.Label LCorrection;
        private System.Windows.Forms.Label LJitterRadius;
        private System.Windows.Forms.Label LPrediction;
        private System.Windows.Forms.Label LMaxDeviationRadius;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox KinectSmooth;
        private System.Windows.Forms.GroupBox KinectBasic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox TrackingModeBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox DepthModeBox;
        private System.Windows.Forms.GroupBox KinectElevation;
        private System.Windows.Forms.Label LElevation;
        private System.Windows.Forms.TrackBar ElevationAngleBar;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
