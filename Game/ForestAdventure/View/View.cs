using System;
using ForestAdventure.Helper;
using ForestAdventure.Model;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ForestAdventure.View
{
    [Obsolete]
    public class View
    {
        private readonly Camera camera;
        private readonly Color4 enemyColor = new Color4(184, 12, 0, 255);
        private readonly Color4 exitColor = new Color4(13, 175, 184, 255);
        private readonly Color4 platformColor = new Color4(77, 39, 3, 255);
        private readonly Color4 playerColor = new Color4(5, 128, 13, 255);
        private int background;

        public View(Camera camera)
        {
            this.camera = camera;
        }

        internal void Draw(IModel model)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            DrawBackground();

            GL.Color4(platformColor);
            foreach (var platform in model.Platform) Draw(platform);

            GL.Color4(playerColor);
            Draw(model.Player);
            GL.Color4(enemyColor);
            foreach (var enemy in model.Enemies) Draw(enemy);

            GL.Color4(exitColor);
            Draw(model.Exit);
        }

        internal void DrawBackground()
        {
            background = TextureTools.LoadFromResource("GraphicContents.ForestBackground.ForestBackground.png");
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, background);
            var rectangle = new Rectangle((camera.Center.X * 0.9f) - 1, (camera.Center.Y * 0.9f) - 1, 3, 3);
            Draw(rectangle);
            GL.Disable(EnableCap.Texture2D);
        }

        internal void Resize(int width, int height)
        {
            camera.Resize(width, height);
        }

        private void Draw(IRectangle rect)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(rect.MinX - camera.Center.X, rect.MinY - camera.Center.Y);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(rect.MaxX - camera.Center.X, rect.MinY - camera.Center.Y);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(rect.MaxX - camera.Center.X, rect.MaxY - camera.Center.Y);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(rect.MinX - camera.Center.X, rect.MaxY - camera.Center.Y);
            GL.End();
        }
    }
}