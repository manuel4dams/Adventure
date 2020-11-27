using Framework.Interfaces;
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Framework.Components
{
    public class DebugTransformPositionComponent : IDrawable
    {
        private readonly float lineLength;

        public DebugTransformPositionComponent(GameObject gameObject)
            : this(gameObject, 1f)
        {
        }

        public DebugTransformPositionComponent(GameObject gameObject, float lineLength)
        {
            this.lineLength = lineLength;
            this.gameObject = gameObject;
        }

        public GameObject gameObject { get; }

        public void Draw()
        {
            GL.Color4(Color.Pink);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(
                gameObject.transform.position.X - lineLength - Camera.Instance.centerPosition.X,
                gameObject.transform.position.Y - Camera.Instance.centerPosition.Y);
            GL.Vertex2(
                gameObject.transform.position.X + lineLength - Camera.Instance.centerPosition.X,
                gameObject.transform.position.Y - Camera.Instance.centerPosition.Y);
            GL.Vertex2(
                gameObject.transform.position.X - Camera.Instance.centerPosition.X,
                gameObject.transform.position.Y - lineLength - Camera.Instance.centerPosition.Y);
            GL.Vertex2(
                gameObject.transform.position.X - Camera.Instance.centerPosition.X,
                gameObject.transform.position.Y + lineLength - Camera.Instance.centerPosition.Y);
            GL.End();
        }
    }
}