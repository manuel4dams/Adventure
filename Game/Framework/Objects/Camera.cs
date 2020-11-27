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
                // minimaler und maximaler X-Wert der Camera
                center.X = value.X <= 0 ? 0 : value.X >= 4 ? 4 : value.X;

                // minimaler und maximaler Y-Wert der Camera
                center.Y = value.Y <= 0 ? 0 : value.Y >= 2 ? 2 : value.Y;
            }
        }

        internal void Resize(int width, int height)
        {
            GL.Viewport(0, 0, width, height);
        }
    }
}