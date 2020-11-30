using System;
using Framework.Interfaces;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Framework.Objects
{
    public sealed class Camera : GameObject, IResizable
    {
        private static Camera instance;

        public static Camera Instance
        {
            get => instance;
            set
            {
                if (instance != null)
                {
                    throw new Exception("Only one camera allowed");
                }

                instance = value;
            }
        }

        public Camera()
        {
            Instance = this;
        }

        public Camera(Transform transform)
            : base(transform)
        {
            Instance = this;
        }

        public void Resize(int width, int height)
        {
            GL.Viewport(0, 0, (int) (width * transform.scale.X), (int) (height * transform.scale.Y));
        }
    }
}