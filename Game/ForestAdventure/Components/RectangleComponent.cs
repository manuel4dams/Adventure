using ForestAdventure.Helper;
using ForestAdventure.Interfaces;
using OpenTK.Graphics.OpenGL;

namespace ForestAdventure.Components
{
    public class RectangleComponent : IDrawable
    {
        private Bounds bounds;

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