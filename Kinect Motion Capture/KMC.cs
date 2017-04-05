namespace AnimationTest
{
    using System;
    using System.Windows.Forms;
    static class KMC
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Window());
        }
    }
}