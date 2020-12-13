using Framework.Interfaces;
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Framework.Development.Components
{
    public class DebugTransformPositionComponent : IComponent, IRender
    {
        private readonly float lineLength;

        public GameObject gameObject { get; }

        public DebugTransformPositionComponent(GameObject gameObject)
            : this(gameObject, 0.1f)
        {
        }

        public DebugTransformPositionComponent(GameObject gameObject, float lineLength)
        {
            this.lineLength = lineLength;
            this.gameObject = gameObject;
        }

        public void Draw()
        {
            var pos = gameObject.transform.position - Camera.instance.transform.position;
            GL.Color4(Color.Pink);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(pos - Vector2.UnitX * lineLength);
            GL.Vertex2(pos + Vector2.UnitX * lineLength);
            GL.Vertex2(pos - Vector2.UnitY * lineLength);
            GL.Vertex2(pos + Vector2.UnitY * lineLength);
            GL.End();
        }
    }
}