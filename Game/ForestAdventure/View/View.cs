using System.Drawing;
using ForrestAdventure.Model;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ForrestAdventure.View
{
    public class View
    {
        private readonly Color4 exitColor = new Color4(135, 206, 235, 255);
        private readonly Color4 platformColor = new Color4(139, 69, 19, 255);
        private readonly Color4 playerColor = new Color4(50, 205, 50, 255);
        private readonly Color4 enemyColor = new Color4(255, 0, 0, 255);
        private readonly Image background;

        public View()
        {
            // background = TextureTools.LoadFromResource("Content.ForestBackground.png");
        }

        internal void Draw(IModel model)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Color4(platformColor);
            foreach (IRectangle platform in model.Platform)
            {
                Draw(platform);
            }

            GL.Color4(playerColor);
            Draw(model.Player);
            GL.Color4(enemyColor);
            foreach (IRectangle enemy in model.Enemies)
            {
                Draw(enemy);
            }

            GL.Color4(exitColor);
            Draw(model.Exit);
        }

        internal void DrawBackground()
        {
        }

        internal void Resize(int width, int height)
        {
            GL.Viewport(0, 0, width, height);
        }

        private static void Draw(IRectangle rect)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(rect.MinX, rect.MinY);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(rect.MaxX, rect.MinY);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(rect.MaxX, rect.MaxY);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(rect.MinX, rect.MaxY);
            GL.End();
        }
    }
}