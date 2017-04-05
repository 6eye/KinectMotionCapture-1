namespace AnimationTest
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class KGrid : KMesh
    {
        public KGrid(GraphicsDevice dev,int size, float step)
        {
            VertexPositionColor[] vertices;
            short[] indices;

            device = dev;
            MeshShader = new BasicEffect(device);
            MeshShader.VertexColorEnabled = true;
            MeshShader.World = Matrix.Identity;

            MeshShader.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), device.Viewport.AspectRatio, 0.01f, 1000f);

            Color c = new Color(100, 100, 100);

            if (size < 1) size = 2; // Ustawiamy minimalna ilosc pol
            else size = size + 1;
            float offest = (step * (size - 1)) / 2;

            // Vertexy
            vertices = new VertexPositionColor[size * size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    vertices[size * i + j].Position = new Vector3(step * j - offest, step * i - offest, 0);
                    vertices[size * i + j].Color = c;
                }
            }
            NumVertex = vertices.Length;
            vBuffer = new VertexBuffer(device, typeof(VertexPositionColor), NumVertex, BufferUsage.WriteOnly);
            vBuffer.SetData(vertices);

            // Indexy
            NumIndicies = ((size - 1) * size) * 4;
            indices = new short[NumIndicies];

            int steps = (size * size) - 1;
            int pos = 0;

            for (short i = 0; i < steps; i++)
            {
                // ----------- A -----------
                if ((i + 1) % size != 0)
                {
                    indices[pos] = i;
                    indices[pos + 1] = (short)(i + 1);
                    pos += 2;
                }
                // ----------- B -----------
                if (i < size * size - size)
                {
                    indices[pos] = i;
                    indices[pos + 1] = (short)(i + size);
                    pos += 2;
                }
            }
            iBuffer = new IndexBuffer(device, IndexElementSize.SixteenBits, sizeof(short) * NumIndicies, BufferUsage.None);
            iBuffer.SetData(indices);
        }
    }
}
