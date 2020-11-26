using Framework.Interfaces;
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Framework.Components
{
    public class DebugTransformPositionComponent : IDrawable
    {
        public GameObject gameObject { get; }
        private float lineLength;

        public DebugTransformPositionComponent(GameObject gameObject)
            : this(gameObject, 1f)
        {
        }

        public DebugTransformPositionComponent(GameObject gameObject, float lineLength)
        {
            this.lineLength = lineLength;
            this.gameObject = gameObject;
        }

        public void Draw()
        {
            GL.Color4(Color.Pink);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(gameObject.transform.position.X - lineLength, gameObject.transform.position.Y);
            GL.Vertex2(gameObject.transform.position.X + lineLength, gameObject.transform.position.Y);
            GL.Vertex2(gameObject.transform.position.X, gameObject.transform.position.Y - lineLength);
            GL.Vertex2(gameObject.transform.position.X, gameObject.transform.position.Y + lineLength);
            GL.End();
        }
    }
}