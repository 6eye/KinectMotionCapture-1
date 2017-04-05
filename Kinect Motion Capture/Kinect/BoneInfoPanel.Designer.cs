namespace AnimationTest
{
    partial class BoneInfoPanel
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
            this.BoneTree = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LJoint = new System.Windows.Forms.Label();
            this.LOffset = new System.Windows.Forms.Label();
            this.LRoot = new System.Windows.Forms.Label();
            this.LRotation = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.JointRotation = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BoneTree
            // 
            this.BoneTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BoneTree.Location = new System.Drawing.Point(0, 21);
            this.BoneTree.Name = "BoneTree";
            this.BoneTree.Size = new System.Drawing.Size(240, 410);
            this.BoneTree.TabIndex = 0;
            this.BoneTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.EVENT_OnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bone list:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LJoint);
            this.groupBox1.Controls.Add(this.LOffset);
            this.groupBox1.Controls.Add(this.LRoot);
            this.groupBox1.Controls.Add(this.LRotation);
            this.groupBox1.Location = new System.Drawing.Point(0, 437);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 125);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bone information";
            // 
            // LJoint
            // 
            this.LJoint.AutoSize = true;
            this.LJoint.Location = new System.Drawing.Point(6, 96);
            this.LJoint.Name = "LJoint";
            this.LJoint.Size = new System.Drawing.Size(94, 13);
            this.LJoint.TabIndex = 6;
            this.LJoint.Text = "Kinect Joint: None";
            // 
            // LOffset
            // 
            this.LOffset.AutoSize = true;
            this.LOffset.Location = new System.Drawing.Point(6, 23);
            this.LOffset.Name = "LOffset";
            this.LOffset.Size = new System.Drawing.Size(197, 13);
            this.LOffset.TabIndex = 3;
            this.LOffset.Text = "Offset: X = 0,000   Y = 0,000   Z = 0,000";
            // 
            // LRoot
            // 
            this.LRoot.AutoSize = true;
            this.LRoot.Location = new System.Drawing.Point(6, 73);
            this.LRoot.Name = "LRoot";
            this.LRoot.Size = new System.Drawing.Size(78, 13);
            this.LRoot.TabIndex = 5;
            this.LRoot.Text = "Root Bone: No";
            // 
            // LRotation
            // 
            this.LRotation.AutoSize = true;
            this.LRotation.Location = new System.Drawing.Point(6, 48);
            this.LRotation.Name = "LRotation";
            this.LRotation.Size = new System.Drawing.Size(222, 13);
            this.LRotation.TabIndex = 4;
            this.LRotation.Text = "Rotation: Y = 0,000°   P = 0,000°   R = 0,000°";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.JointRotation);
            this.groupBox2.Location = new System.Drawing.Point(3, 568);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 51);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kinect Joint";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rotation:";
            // 
            // JointRotation
            // 
            this.JointRotation.FormattingEnabled = true;
            this.JointRotation.Location = new System.Drawing.Point(95, 19);
            this.JointRotation.Name = "JointRotation";
            this.JointRotation.Size = new System.Drawing.Size(134, 21);
            this.JointRotation.TabIndex = 0;
            this.JointRotation.SelectedValueChanged += new System.EventHandler(this.EVENT_JointValueChanged);
            // 
            // BoneInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BoneTree);
            this.Name = "BoneInformation";
            this.Size = new System.Drawing.Size(243, 620);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView BoneTree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LOffset;
        private System.Windows.Forms.Label LRoot;
        private System.Windows.Forms.Label LRotation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox JointRotation;
        private System.Windows.Forms.Label LJoint;
    }
}
