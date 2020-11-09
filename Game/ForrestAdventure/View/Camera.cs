using OpenTK.Graphics.OpenGL;

namespace ForrestAdventure.View
{
    internal class Camera
    {
        public void Resize(int width, int height)
        {
            GL.Viewport(0, 0, width, height);
        }
    }
}