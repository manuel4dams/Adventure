using System.Drawing;
using Framework.Game;
using Framework.Interfaces;
using Framework.Shapes;
using OpenTK.Graphics.OpenGL;

namespace Framework.Render
{
    public class RectangleColorRenderer : IComponent, IRender
    {
        private readonly RectangleBounds rectangleBounds;
        private readonly Color color;
        public GameObject gameObject { get; }

        public RectangleColorRenderer(GameObject gameObject, RectangleBounds rectangleBounds)
            : this(gameObject, rectangleBounds, Color.White)
        {
        }

        public RectangleColorRenderer(GameObject gameObject, RectangleBounds rectangleBounds, Color color)
        {
            this.gameObject = gameObject;
            this.rectangleBounds = rectangleBounds;
            this.color = color;
        }

        public void Draw()
        {
            var quad = rectangleBounds.Transform(gameObject.transform);
            quad.Translate(-Camera.Camera.instance.transform.position);

            GL.Color4(color);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(quad.vertex1);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(quad.vertex2);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(quad.vertex3);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(quad.vertex4);
            GL.End();
        }
    }
}