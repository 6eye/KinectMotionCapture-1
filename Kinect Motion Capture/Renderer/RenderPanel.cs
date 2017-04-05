namespace AnimationTest
{
    using System;
    using System.Windows.Forms;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public partial class RenderPanel : UserControl
    {
        public  KRenderer Renderer;
        private KGizmo    gizmo;
        private KGrid     grid;
        private KModel    mesh;

        // Myszka
        private bool  MouseLeftButton;  // Lewy przycisk myszy
        private bool  MouseRightButton; // Prawy przycisk myszy
        private float MousePosX;
        private float MousePosY;

        public RenderPanel()
        {
            InitializeComponent();
            Renderer = new KRenderer(RenderWnd.Handle, RenderWnd.ClientSize.Width, RenderWnd.ClientSize.Height);
            gizmo = new KGizmo(Renderer.device, 50);
            grid = new KGrid(Renderer.device, 20, 50.0f);
            gizmo.SetViewMatrix(Renderer.Camera.View);
            grid.SetViewMatrix(Renderer.Camera.View);
        }
    
        public void SetFPS(int FPS)
        {
            FPSLabel.Text = FPS.ToString();
        }
        public void Draw()
        {
            Renderer.BeginDraw();
            if (grid  != null) grid.Draw();
            if (gizmo != null) gizmo.Draw();
            if (mesh  != null) mesh.Draw();
            Renderer.EndDraw();
        }
        public void SetMesh(KModel m)
        {
            if (m != null)
            {
                mesh = m;
                mesh.SetViewMatrix(Renderer.Camera.View);
            }
        }

        // Myszka
        private void EVENT_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) MouseLeftButton = true;
            if (e.Button == MouseButtons.Right) MouseRightButton = true;
            MousePosX = e.X;
            MousePosY = e.Y;
        }
        private void EVENT_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) MouseLeftButton = false;
            if (e.Button == MouseButtons.Right) MouseRightButton = false;
            MousePosX = e.X;
            MousePosY = e.Y;
        }
        private void EVENT_MouseMove(object sender, MouseEventArgs e)
        {
            float x = MousePosX - e.X;
            float y = MousePosY - e.Y;

            if (MouseRightButton)
            {
                Renderer.Camera.Zoom(y);    // Zmiana odleglosci kamery
            }
            else if (MouseLeftButton)
            {
                Renderer.Camera.Move(new Vector3(0, 0, -y)); // Poruszanie kamery w pionie
                Renderer.Camera.Rotate(x * 0.01f);           // Obrót kamery
            }

            MousePosX = e.X;
            MousePosY = e.Y;

            gizmo.SetViewMatrix(Renderer.Camera.View);
            grid.SetViewMatrix(Renderer.Camera.View);
            if (mesh != null) mesh.SetViewMatrix(Renderer.Camera.View);
        }

        // Opcje ( gorne )
        private void EVENT_DrawModel(object sender, EventArgs e)
        {
            if (mesh != null) mesh.DrawMesh = !mesh.DrawMesh;
        }
        private void EVENT_DrawBones(object sender, EventArgs e)
        {
            if (mesh != null) mesh.DrawBones = !mesh.DrawBones;
        }
    }
}
