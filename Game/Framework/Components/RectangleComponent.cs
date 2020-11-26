using Framework.Interfaces;
using Framework.Objects;
using OpenTK.Graphics.OpenGL;

namespace Framework.Components
{
    public class RectangleComponent : IDrawable
    {
        private readonly Bounds bounds;

        public RectangleComponent(Bounds bounds)
        {
            this.bounds = bounds;
        }

        public void Draw()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(bounds.MinX, bounds.MinY);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(bounds.MaxX, bounds.MinY);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(bounds.MaxX, bounds.MaxY);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(bounds.MinX, bounds.MaxY);
            GL.End();
        }
    }
}