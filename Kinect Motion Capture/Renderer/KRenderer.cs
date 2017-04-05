namespace AnimationTest
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class KRenderer
    {
        private Color ClearColor;
        public GraphicsDevice device;
        public KCamera Camera;

        public KRenderer(IntPtr Handle, int SizeX, int SizeY)
        {
            PresentationParameters pp = new PresentationParameters();
            pp.BackBufferHeight = SizeY;
            pp.BackBufferWidth = SizeX;
            pp.IsFullScreen = false;
            pp.DeviceWindowHandle = Handle;
            pp.RenderTargetUsage = RenderTargetUsage.DiscardContents;
            pp.DepthStencilFormat = DepthFormat.Depth24Stencil8;

            ClearColor = new Color(55, 55, 55);
            Camera = new KCamera(300);
            device = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.Reach, pp);
        }
        public void BeginDraw()
        {
            device.Clear(ClearColor);
        }
        public void EndDraw()
        {
            device.Present();
        }
    }
}
