namespace AnimationTest
{
    using System;
    using System.Windows.Forms;

    public partial class AnimNameWindow : Form
    {
        public string AnimationName;
        public AnimNameWindow()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (AnimationNameBox.Text.Length == 0)
                AnimationName = "none";
            else
                AnimationName = AnimationNameBox.Text;
        }

        private void AnimationNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // "BACKSPACE"
            if (e.KeyChar == 8) 
            {
                e.Handled = false;
                return;
            }
            // a-zA-Z0-9_"Space" + maksymalna ilosc znakow: 32 znaki
            e.Handled = (((e.KeyChar >= 65 && e.KeyChar <= 122) || (e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar == 95 || e.KeyChar == 32)) && AnimationNameBox.Text.Length < 32) ? false : true;
        }
    }
}
