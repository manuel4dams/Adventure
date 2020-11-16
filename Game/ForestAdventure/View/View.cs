using ForestAdventure.Helper;
using ForestAdventure.Model;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ForestAdventure.View
{
    public class View
    {
        private readonly Color4 exitColor = new Color4(13, 175, 184, 255);
        private readonly Color4 platformColor = new Color4(77, 39, 3, 255);
        private readonly Color4 playerColor = new Color4(5, 128, 13, 255);
        private readonly Color4 enemyColor = new Color4(184, 12, 0, 255);
        private int background;

        internal void Draw(IModel model)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            this.DrawBackground();

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
            this.background = TextureTools.LoadFromResource("GraphicContents.ForestBackground.ForestBackground.png");
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, this.background);
            Rectangle rectangle = new Rectangle((Camera.Position.X * 0.9f) - 1, (Camera.Position.Y * 0.9f) - 1, 3, 3);
            Draw(rectangle);
            GL.Disable(EnableCap.Texture2D);
        }

        internal void Resize(int width, int height)
        {
            GL.Viewport(0, 0, width, height);
        }

        private static void Draw(IRectangle rect)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(rect.MinX - Camera.Position.X, rect.MinY - Camera.Position.Y);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(rect.MaxX - Camera.Position.X, rect.MinY - Camera.Position.Y);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(rect.MaxX - Camera.Position.X, rect.MaxY - Camera.Position.Y);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(rect.MinX - Camera.Position.X, rect.MaxY - Camera.Position.Y);
            GL.End();
        }
    }
}