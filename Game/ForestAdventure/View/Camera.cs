using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ForestAdventure.View
{
    internal class Camera
    {
        private static Vector2 position = new Vector2(0, 0);

        public static Vector2 Position
        {
            get => position;
            set
            {
                position.X = value.X <= 0 ? 0 : value.X >= 2 ? 2 : value.X;
                position.Y = value.Y <= 0 ? 0 : value.Y >= 2 ? 2 : value.Y;
            }
        }

        public void Resize(int width, int height)
        {
            GL.Viewport(0, 0, width, height);
        }
    }
}