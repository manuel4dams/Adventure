using Framework.Game;
using Framework.Interfaces;
using Framework.Shapes;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Framework.Render
{
    public class QuadRenderer : IComponent, IRender
    {
        private readonly RectangleBounds rectangleBounds;
        private readonly Color4 color;

        public GameObject gameObject { get; }

        public QuadRenderer(GameObject gameObject, RectangleBounds rectangleBounds)
            : this(gameObject, rectangleBounds, Color4.White)
        {
        }

        public QuadRenderer(GameObject gameObject, RectangleBounds rectangleBounds, Color4 color)
        {
            this.gameObject = gameObject;
            this.rectangleBounds = rectangleBounds;
            this.color = color;
        }

        public void Draw()
        {
            var rectangle = rectangleBounds.Transform(gameObject.transform);
            rectangle.Translate(-Camera.Camera.instance.transform.position);

            GL.Color4(color);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(rectangle.vertex1);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(rectangle.vertex2);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(rectangle.vertex3);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(rectangle.vertex4);
            GL.End();
        }
    }
}