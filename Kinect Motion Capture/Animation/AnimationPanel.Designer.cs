namespace AnimationTest
{
    partial class AnimationPanel
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
            this.TimelineBar = new System.Windows.Forms.TrackBar();
            this.BRecord = new System.Windows.Forms.Button();
            this.BPause = new System.Windows.Forms.Button();
            this.BStop = new System.Windows.Forms.Button();
            this.BPlay = new System.Windows.Forms.Button();
            this.LActualFrame = new System.Windows.Forms.Label();
            this.LActualTime = new System.Windows.Forms.Label();
            this.LoopCheck = new System.Windows.Forms.CheckBox();
            this.AnimNameLabel = new System.Windows.Forms.Label();
            this.LAnimName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TimelineBar)).BeginInit();
            this.SuspendLayout();
            // 
            // TimelineBar
            // 
            this.TimelineBar.BackColor = System.Drawing.Color.White;
            this.TimelineBar.Enabled = false;
            this.TimelineBar.Location = new System.Drawing.Point(1, -1);
            this.TimelineBar.Maximum = 1;
            this.TimelineBar.Name = "TimelineBar";
            this.TimelineBar.Size = new System.Drawing.Size(953, 45);
            this.TimelineBar.TabIndex = 12;
            this.TimelineBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TimelineBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EVENT_KeyDown);
            this.TimelineBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EVENT_MouseDown);
            this.TimelineBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EVENT_MouseMove);
            this.TimelineBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EVENT_MouseUp);
            // 
            // BRecord
            // 
            this.BRecord.BackgroundImage = global::AnimationTest.Properties.Resources.record1;
            this.BRecord.Location = new System.Drawing.Point(3, 42);
            this.BRecord.Name = "BRecord";
            this.BRecord.Size = new System.Drawing.Size(32, 32);
            this.BRecord.TabIndex = 29;
            this.BRecord.UseVisualStyleBackColor = true;
            this.BRecord.Click += new System.EventHandler(this.EVENT_ButtonRecord);
            // 
            // BPause
            // 
            this.BPause.BackgroundImage = global::AnimationTest.Properties.Resources.pause;
            this.BPause.Location = new System.Drawing.Point(79, 42);
            this.BPause.Name = "BPause";
            this.BPause.Size = new System.Drawing.Size(32, 32);
            this.BPause.TabIndex = 28;
            this.BPause.UseVisualStyleBackColor = true;
            this.BPause.Visible = false;
            this.BPause.Click += new System.EventHandler(this.EVENT_ButtonPause);
            // 
            // BStop
            // 
            this.BStop.BackgroundImage = global::AnimationTest.Properties.Resources.stop;
            this.BStop.Location = new System.Drawing.Point(41, 42);
            this.BStop.Name = "BStop";
            this.BStop.Size = new System.Drawing.Size(32, 32);
            this.BStop.TabIndex = 27;
            this.BStop.UseVisualStyleBackColor = true;
            this.BStop.Click += new System.EventHandler(this.EVENT_ButtonStop);
            // 
            // BPlay
            // 
            this.BPlay.BackgroundImage = global::AnimationTest.Properties.Resources.play;
            this.BPlay.Location = new System.Drawing.Point(79, 42);
            this.BPlay.Name = "BPlay";
            this.BPlay.Size = new System.Drawing.Size(32, 32);
            this.BPlay.TabIndex = 26;
            this.BPlay.UseVisualStyleBackColor = true;
            this.BPlay.Click += new System.EventHandler(this.EVENT_ButtonPlay);
            // 
            // LActualFrame
            // 
            this.LActualFrame.AutoSize = true;
            this.LActualFrame.Location = new System.Drawing.Point(707, 51);
            this.LActualFrame.Name = "LActualFrame";
            this.LActualFrame.Size = new System.Drawing.Size(89, 13);
            this.LActualFrame.TabIndex = 30;
            this.LActualFrame.Text = "Actual Frame 0/0";
            // 
            // LActualTime
            // 
            this.LActualTime.AutoSize = true;
            this.LActualTime.Location = new System.Drawing.Point(835, 51);
            this.LActualTime.Name = "LActualTime";
            this.LActualTime.Size = new System.Drawing.Size(85, 13);
            this.LActualTime.TabIndex = 31;
            this.LActualTime.Text = "Total Time 0/0 s";
            // 
            // LoopCheck
            // 
            this.LoopCheck.AutoSize = true;
            this.LoopCheck.Location = new System.Drawing.Point(124, 50);
            this.LoopCheck.Name = "LoopCheck";
            this.LoopCheck.Size = new System.Drawing.Size(99, 17);
            this.LoopCheck.TabIndex = 32;
            this.LoopCheck.Text = "Loop Animation";
            this.LoopCheck.UseVisualStyleBackColor = true;
            this.LoopCheck.Click += new System.EventHandler(this.EVENT_ButtonLoop);
            // 
            // AnimNameLabel
            // 
            this.AnimNameLabel.AutoSize = true;
            this.AnimNameLabel.Location = new System.Drawing.Point(460, 51);
            this.AnimNameLabel.Name = "AnimNameLabel";
            this.AnimNameLabel.Size = new System.Drawing.Size(38, 13);
            this.AnimNameLabel.TabIndex = 33;
            this.AnimNameLabel.Text = "Name:";
            // 
            // LAnimName
            // 
            this.LAnimName.AutoSize = true;
            this.LAnimName.Location = new System.Drawing.Point(494, 51);
            this.LAnimName.Name = "LAnimName";
            this.LAnimName.Size = new System.Drawing.Size(0, 13);
            this.LAnimName.TabIndex = 34;
            // 
            // AnimationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.LAnimName);
            this.Controls.Add(this.AnimNameLabel);
            this.Controls.Add(this.LoopCheck);
            this.Controls.Add(this.LActualTime);
            this.Controls.Add(this.LActualFrame);
            this.Controls.Add(this.BRecord);
            this.Controls.Add(this.BPause);
            this.Controls.Add(this.BStop);
            this.Controls.Add(this.BPlay);
            this.Controls.Add(this.TimelineBar);
            this.Enabled = false;
            this.Name = "AnimationPanel";
            this.Size = new System.Drawing.Size(953, 78);
            ((System.ComponentModel.ISupportInitialize)(this.TimelineBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar TimelineBar;
        private System.Windows.Forms.Button BRecord;
        private System.Windows.Forms.Button BPause;
        private System.Windows.Forms.Button BStop;
        private System.Windows.Forms.Button BPlay;
        private System.Windows.Forms.Label LActualFrame;
        private System.Windows.Forms.Label LActualTime;
        private System.Windows.Forms.CheckBox LoopCheck;
        private System.Windows.Forms.Label AnimNameLabel;
        private System.Windows.Forms.Label LAnimName;
    }
}
