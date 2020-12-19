using System;
using System.Drawing;
using Framework.Game;
using Framework.Interfaces;
using Framework.Render.Helper;
using Framework.Shapes;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Framework.Render
{
    public class QuadRenderer : IComponent, IRender
    {
        private enum DrawRectangle
        {
            /// <summary>
            /// Default value,
            /// Draw rectangle with color
            /// </summary>
            DrawColor,

            /// <summary>
            /// Draw rectangle with texture
            /// </summary>
            DrawBitmap,
        }

        private readonly RectangleBounds rectangleBounds;
        private readonly DrawRectangle drawRectangle;
        private readonly Color4 color;
        private readonly Bitmap textureBitmap;
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
            drawRectangle = DrawRectangle.DrawColor;
        }

        public QuadRenderer(GameObject gameObject, RectangleBounds rectangleBounds, Bitmap textureBitmap)
        {
            this.gameObject = gameObject;
            this.rectangleBounds = rectangleBounds;
            this.textureBitmap = textureBitmap;
            drawRectangle = DrawRectangle.DrawBitmap;
        }

        public void Draw()
        {
            switch (drawRectangle)
            {
                case DrawRectangle.DrawColor:
                    DrawColor();
                    break;
                case DrawRectangle.DrawBitmap:
                    DrawBitmap();
                    break;
                default:
                    throw new ArgumentException("Invalid " + nameof(DrawRectangle));
            }
        }

        private void DrawColor()
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

        private void DrawBitmap()
        {
            var rectangle = rectangleBounds.Transform(gameObject.transform);
            rectangle.Translate(-Camera.Camera.instance.transform.position);

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, TextureHelper.LoadTextureFromBitmap(textureBitmap));

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

            GL.Disable(EnableCap.Texture2D);
        }
    }
}