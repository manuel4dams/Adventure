using Framework.Interfaces;
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Framework.Components
{
    public class DebugColliderEdges : IComponent, IDrawable
    {
        private readonly Bounds bounds;
        public GameObject gameObject { get; }

        public DebugColliderEdges(GameObject gameObject, Bounds bounds)
        {
            this.bounds = bounds;
            this.gameObject = gameObject;
        }

        public void Draw()
        {
            GL.Color4(Color.Pink);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.minX - Camera.Instance.transform.position.X,
                gameObject.transform.position.Y + bounds.minY - Camera.Instance.transform.position.Y);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.maxX - Camera.Instance.transform.position.X,
                gameObject.transform.position.Y + bounds.minY - Camera.Instance.transform.position.Y);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.minX - Camera.Instance.transform.position.X,
                gameObject.transform.position.Y + bounds.minY - Camera.Instance.transform.position.Y);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.minX - Camera.Instance.transform.position.X,
                gameObject.transform.position.Y + bounds.maxY - Camera.Instance.transform.position.Y);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.maxX - Camera.Instance.transform.position.X,
                gameObject.transform.position.Y + bounds.minY - Camera.Instance.transform.position.Y);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.maxX - Camera.Instance.transform.position.X,
                gameObject.transform.position.Y + bounds.maxY - Camera.Instance.transform.position.Y);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.maxX - Camera.Instance.transform.position.X,
                gameObject.transform.position.Y + bounds.maxY - Camera.Instance.transform.position.Y);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.minX - Camera.Instance.transform.position.X,
                gameObject.transform.position.Y + bounds.maxY - Camera.Instance.transform.position.Y);
            GL.End();
        }
    }
}