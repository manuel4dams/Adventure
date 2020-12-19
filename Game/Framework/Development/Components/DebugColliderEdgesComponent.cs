using System.Drawing;
using Framework.Game;
using Framework.Interfaces;
using Framework.Shapes;
using OpenTK.Graphics.OpenGL;

namespace Framework.Development.Components
{
    public class DebugColliderEdgesComponent : IComponent, IRender
    {
        private readonly RectangleBounds rectangleBounds;

        public GameObject gameObject { get; }

        public DebugColliderEdgesComponent(GameObject gameObject, RectangleBounds rectangleBounds)
        {
            this.rectangleBounds = rectangleBounds;
            this.gameObject = gameObject;
        }

        public void Draw()
        {
            var rectangle = rectangleBounds.Transform(gameObject.transform);
            rectangle.Translate(-Camera.Camera.instance.transform.position);

            GL.Color4(Color.Pink);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(rectangle.vertex1);
            GL.Vertex2(rectangle.vertex2);
            GL.Vertex2(rectangle.vertex2);
            GL.Vertex2(rectangle.vertex3);
            GL.Vertex2(rectangle.vertex3);
            GL.Vertex2(rectangle.vertex4);
            GL.Vertex2(rectangle.vertex4);
            GL.Vertex2(rectangle.vertex1);
            GL.End();
        }
    }
}