namespace AnimationTest
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class KGizmo : KMesh
    {
        public KGizmo(GraphicsDevice dev, int size = 2)
        {
            device = dev;

            MeshShader = new BasicEffect(device);
            MeshShader.VertexColorEnabled = true;
            MeshShader.World = Matrix.Identity;

            MeshShader.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), device.Viewport.AspectRatio, 0.01f, 1000f);
            
            VertexPositionColor[] vertices = new VertexPositionColor[6];
            short[] indices = new short[6];

            // Ustawiamy Vertexy
            vertices[0].Position = Vector3.Zero;
            vertices[0].Color = Color.Blue;
            vertices[1].Position = Vector3.UnitZ * size;
            vertices[1].Color = Color.Blue;

            vertices[2].Position = Vector3.Zero;
            vertices[2].Color = Color.Red;
            vertices[3].Position = Vector3.UnitX * size;
            vertices[3].Color = Color.Red;

            vertices[4].Position = Vector3.Zero;
            vertices[4].Color = Color.ForestGreen;
            vertices[5].Position = Vector3.UnitY * size;
            vertices[5].Color = Color.ForestGreen;

            // Ustawiamy indeksy
            indices[0] = 0;
            indices[1] = 1;
            indices[2] = 2;
            indices[3] = 3;
            indices[4] = 4;
            indices[5] = 5;

            vBuffer = new VertexBuffer(device, typeof(VertexPositionColor), vertices.Length, BufferUsage.WriteOnly);
            iBuffer = new IndexBuffer(device, IndexElementSize.SixteenBits, sizeof(short) * indices.Length, BufferUsage.None);

            vBuffer.SetData(vertices);
            iBuffer.SetData(indices);

            NumIndicies = indices.Length;
            NumVertex = vertices.Length;
        }
    }
}
