using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Framework.Objects
{
    public sealed class Camera
    {
        private static Camera instance = null;
        private static readonly object padlock = new object();
        private Vector2 center = new Vector2(0, 0);

        private Camera()
        {
        }

        public static Camera Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Camera();
                    }

                    return instance;
                }
            }
        }

        public Vector2 centerPosition
        {
            get => center;
            set
            {
                center.X = value.X;
                center.Y = value.Y;
            }
        }

        internal void Resize(int width, int height)
        {
            GL.Viewport(0, 0, width, height);
        }
    }
}