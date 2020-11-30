using System;
using Framework.Interfaces;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Framework.Objects
{
    public sealed class Camera : GameObject, IResizable
    {
        public enum ResizeViewport
        {
            KeepContentSize,
            KeepWidth,
            KeepHeight,
        }

        private static Camera instance;
        private ResizeViewport resizeViewport;

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

        public Camera(ResizeViewport resizeViewport = ResizeViewport.KeepContentSize)
        {
            Instance = this;
            this.resizeViewport = resizeViewport;
        }

        public Camera(Transform transform, ResizeViewport resizeViewport = ResizeViewport.KeepContentSize)
            : base(transform)
        {
            Instance = this;
            this.resizeViewport = resizeViewport;
        }

        public void Resize(int width, int height)
        {
            switch (resizeViewport)
            {
                case ResizeViewport.KeepContentSize:
                    ResizeKeepContentSize(width, height);
                    break;
                case ResizeViewport.KeepWidth:
                    ResizeKeepWidth(width, height);
                    break;
                case ResizeViewport.KeepHeight:
                    break;
                default:
                    throw new ArgumentException("Invalid " + nameof(ResizeViewport));
            }
        }

        private void ResizeKeepContentSize(int width, int height)
        {
            GL.LoadIdentity();
            GL.Viewport(0, 0, width, height);
            GL.Scale(new Vector3(transform.scale.X / width, transform.scale.Y / height, 0f));
        }

        private void ResizeKeepWidth(int width, int height)
        {
            GL.LoadIdentity();
            GL.Viewport(0, 0, width, height);

            var aspectRatio = (float) width / height;
            GL.Scale(new Vector3(
                transform.scale.X,
                transform.scale.Y * aspectRatio,
                0f));
        }

        private void ResizeKeepHeight(int width, int height)
        {
        }
    }
}