namespace AnimationTest
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class KMesh
    {
        protected GraphicsDevice device;
        protected BasicEffect MeshShader;

        protected IndexBuffer iBuffer;
        protected VertexBuffer vBuffer;
        protected int NumIndicies;
        protected int NumVertex;

        public KMesh() {}
        public virtual void SetViewMatrix(Matrix View)
        {
            if (MeshShader != null) MeshShader.View = View;
        }
        public virtual void Draw()
        {
            if (MeshShader != null && device != null)
            {
                MeshShader.CurrentTechnique.Passes[0].Apply();
                device.Indices = iBuffer;
                device.SetVertexBuffer(vBuffer);
                device.RasterizerState = RasterizerState.CullNone;
                device.DrawIndexedPrimitives(PrimitiveType.LineList, 0, 0, NumVertex, 0, NumIndicies); 
            }
        }
    }
}
