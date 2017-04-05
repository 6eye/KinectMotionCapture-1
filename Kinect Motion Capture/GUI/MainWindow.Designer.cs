namespace AnimationTest
{
    partial class Window
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.LKinectStatus = new System.Windows.Forms.Label();
            this.LKinectTracking = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.menu_animload = new System.Windows.Forms.ToolStripButton();
            this.menu_animsave = new System.Windows.Forms.ToolStripButton();
            this.menu_modelload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_modelmaterial = new System.Windows.Forms.ToolStripButton();
            this.AnimPanel = new AnimationTest.AnimationPanel();
            this.RenderingPanel = new AnimationTest.RenderPanel();
            this.KinectPanel = new AnimationTest.KinectPanel();
            this.BonePanel = new AnimationTest.BoneInfoPanel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(967, 65);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(266, 660);
            this.tabControl1.TabIndex = 35;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.KinectPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(258, 634);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Kinect";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BonePanel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(258, 634);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Mesh Bone Information";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 734);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Kinect status:";
            // 
            // LKinectStatus
            // 
            this.LKinectStatus.AutoSize = true;
            this.LKinectStatus.Location = new System.Drawing.Point(81, 734);
            this.LKinectStatus.Name = "LKinectStatus";
            this.LKinectStatus.Size = new System.Drawing.Size(16, 13);
            this.LKinectStatus.TabIndex = 42;
            this.LKinectStatus.Text = "...";
            // 
            // LKinectTracking
            // 
            this.LKinectTracking.AutoSize = true;
            this.LKinectTracking.Location = new System.Drawing.Point(296, 734);
            this.LKinectTracking.Name = "LKinectTracking";
            this.LKinectTracking.Size = new System.Drawing.Size(69, 13);
            this.LKinectTracking.TabIndex = 44;
            this.LKinectTracking.Text = "Not detected";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 734);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Tracking:";
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_modelload,
            this.menu_modelmaterial,
            this.toolStripSeparator2,
            this.menu_animload,
            this.menu_animsave});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1233, 64);
            this.menu.TabIndex = 40;
            this.menu.Text = "toolStrip1";
            // 
            // menu_animload
            // 
            this.menu_animload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menu_animload.Enabled = false;
            this.menu_animload.Image = ((System.Drawing.Image)(resources.GetObject("menu_animload.Image")));
            this.menu_animload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_animload.Name = "menu_animload";
            this.menu_animload.Size = new System.Drawing.Size(96, 61);
            this.menu_animload.Text = "Load Animation";
            this.menu_animload.Click += new System.EventHandler(this.EVENT_ButtonLoadPSA);
            // 
            // menu_animsave
            // 
            this.menu_animsave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menu_animsave.Enabled = false;
            this.menu_animsave.Image = ((System.Drawing.Image)(resources.GetObject("menu_animsave.Image")));
            this.menu_animsave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_animsave.Name = "menu_animsave";
            this.menu_animsave.Size = new System.Drawing.Size(91, 61);
            this.menu_animsave.Text = "SaveAnimation";
            this.menu_animsave.Click += new System.EventHandler(this.EVENT_ButtonSavePSA);
            // 
            // menu_modelload
            // 
            this.menu_modelload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menu_modelload.Image = ((System.Drawing.Image)(resources.GetObject("menu_modelload.Image")));
            this.menu_modelload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_modelload.Name = "menu_modelload";
            this.menu_modelload.Size = new System.Drawing.Size(91, 61);
            this.menu_modelload.Text = "Load 3D Model";
            this.menu_modelload.Click += new System.EventHandler(this.EVENT_ButtonLoadPSK);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 64);
            // 
            // menu_modelmaterial
            // 
            this.menu_modelmaterial.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menu_modelmaterial.Enabled = false;
            this.menu_modelmaterial.Image = ((System.Drawing.Image)(resources.GetObject("menu_modelmaterial.Image")));
            this.menu_modelmaterial.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menu_modelmaterial.Name = "menu_modelmaterial";
            this.menu_modelmaterial.Size = new System.Drawing.Size(73, 61);
            this.menu_modelmaterial.Text = "Set Material";
            this.menu_modelmaterial.Click += new System.EventHandler(this.EVENT_ButtonSetMaterial);
            // 
            // AnimPanel
            // 
            this.AnimPanel.BackColor = System.Drawing.Color.White;
            this.AnimPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnimPanel.Enabled = false;
            this.AnimPanel.Location = new System.Drawing.Point(4, 644);
            this.AnimPanel.Name = "AnimPanel";
            this.AnimPanel.Size = new System.Drawing.Size(955, 81);
            this.AnimPanel.TabIndex = 39;
            // 
            // RenderingPanel
            // 
            this.RenderingPanel.BackColor = System.Drawing.Color.White;
            this.RenderingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RenderingPanel.Location = new System.Drawing.Point(4, 64);
            this.RenderingPanel.Name = "RenderingPanel";
            this.RenderingPanel.Size = new System.Drawing.Size(955, 571);
            this.RenderingPanel.TabIndex = 38;
            // 
            // KinectPanel
            // 
            this.KinectPanel.BackColor = System.Drawing.Color.White;
            this.KinectPanel.Location = new System.Drawing.Point(6, 6);
            this.KinectPanel.Name = "KinectPanel";
            this.KinectPanel.Size = new System.Drawing.Size(249, 632);
            this.KinectPanel.TabIndex = 27;
            // 
            // BonePanel
            // 
            this.BonePanel.Location = new System.Drawing.Point(6, 10);
            this.BonePanel.Name = "BonePanel";
            this.BonePanel.Size = new System.Drawing.Size(303, 620);
            this.BonePanel.TabIndex = 26;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1233, 753);
            this.Controls.Add(this.LKinectTracking);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LKinectStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.AnimPanel);
            this.Controls.Add(this.RenderingPanel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kinect Motion Capture";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private BoneInfoPanel BonePanel;
        private KinectPanel KinectPanel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private AnimationPanel AnimPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LKinectStatus;
        private System.Windows.Forms.Label LKinectTracking;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStrip menu;
        private RenderPanel RenderingPanel;
        private System.Windows.Forms.ToolStripButton menu_modelload;
        private System.Windows.Forms.ToolStripButton menu_animload;
        private System.Windows.Forms.ToolStripButton menu_animsave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton menu_modelmaterial;
    }
}

