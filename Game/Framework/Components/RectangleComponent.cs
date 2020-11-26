using Framework.Interfaces;
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Framework.Components
{
    public class RectangleComponent : IDrawable
    {
        public GameObject gameObject { get; }
        private Bounds bounds;
        private Color color;

        public RectangleComponent(GameObject gameObject, Bounds bounds)
            : this(gameObject, bounds, Color.White)
        {
        }

        public RectangleComponent(GameObject gameObject, Bounds bounds, Color color)
        {
            this.gameObject = gameObject;
            this.bounds = bounds;
            this.color = color;
        }

        public void Draw()
        {
            GL.Color4(color);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(gameObject.transform.position.X + bounds.MinX, gameObject.transform.position.Y + bounds.MinY);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(gameObject.transform.position.X + bounds.MaxX, gameObject.transform.position.Y + bounds.MinY);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(gameObject.transform.position.X + bounds.MaxX, gameObject.transform.position.Y + bounds.MaxY);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(gameObject.transform.position.X + bounds.MinX, gameObject.transform.position.Y + bounds.MaxY);
            GL.End();
        }
    }
}