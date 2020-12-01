using Framework.Interfaces;
using Framework.Objects;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Framework.Components
{
    public class RectangleDrawable : IComponent, IDrawable
    {
        private readonly Bounds bounds;
        private readonly Color4 color;

        public RectangleDrawable(GameObject gameObject, Bounds bounds)
            : this(gameObject, bounds, Color4.White)
        {
        }

        public RectangleDrawable(GameObject gameObject, Bounds bounds, Color4 color)
        {
            this.gameObject = gameObject;
            this.bounds = bounds;
            this.color = color;
        }

        public GameObject gameObject { get; }

        public void Draw()
        {
            GL.Color4(color);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.minX - Camera.Instance.transform.position.X,
                gameObject.transform.position.Y + bounds.minY - Camera.Instance.transform.position.Y);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.maxX - Camera.Instance.transform.position.X,
                gameObject.transform.position.Y + bounds.minY - Camera.Instance.transform.position.Y);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.maxX - Camera.Instance.transform.position.X,
                gameObject.transform.position.Y + bounds.maxY - Camera.Instance.transform.position.Y);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.minX - Camera.Instance.transform.position.X,
                gameObject.transform.position.Y + bounds.maxY - Camera.Instance.transform.position.Y);
            GL.End();
        }
    }
}