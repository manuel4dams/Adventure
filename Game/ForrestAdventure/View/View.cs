using ForrestAdventure.Model;
using OpenTK.Graphics.OpenGL;

namespace ForrestAdventure.View
{
    public class View
    {
        internal void Draw(IModel model)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            foreach (IRectangle platform in model.Platform)
            {
                Draw(platform);
            }

            Draw(model.Player);
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