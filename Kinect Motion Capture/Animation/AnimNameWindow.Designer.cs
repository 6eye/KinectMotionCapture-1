namespace AnimationTest
{
    partial class AnimNameWindow
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
            this.OKButton = new System.Windows.Forms.Button();
            this.AnimationLabel = new System.Windows.Forms.Label();
            this.AnimationNameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(311, 64);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // AnimationLabel
            // 
            this.AnimationLabel.AutoSize = true;
            this.AnimationLabel.Location = new System.Drawing.Point(13, 13);
            this.AnimationLabel.Name = "AnimationLabel";
            this.AnimationLabel.Size = new System.Drawing.Size(187, 13);
            this.AnimationLabel.TabIndex = 1;
            this.AnimationLabel.Text = "Animation name: ( max 32 characters )";
            // 
            // AnimationNameBox
            // 
            this.AnimationNameBox.Location = new System.Drawing.Point(12, 38);
            this.AnimationNameBox.Name = "AnimationNameBox";
            this.AnimationNameBox.Size = new System.Drawing.Size(374, 20);
            this.AnimationNameBox.TabIndex = 2;
            this.AnimationNameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AnimationNameBox_KeyPress);
            // 
            // AnimNameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 98);
            this.Controls.Add(this.AnimationNameBox);
            this.Controls.Add(this.AnimationLabel);
            this.Controls.Add(this.OKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnimNameWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create new animation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label AnimationLabel;
        private System.Windows.Forms.TextBox AnimationNameBox;
    }
}