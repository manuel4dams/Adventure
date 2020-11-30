using System;
using Framework.Interfaces;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Framework.Objects
{
    public sealed class Camera : GameObject, IResizable
    {
        public enum ResizeViewport
        {
            KeepContentAspectRatio,
            KeepWidth,
            KeepHeight,
        }

        private static Camera instance;
        private ResizeViewport resizeViewport;
        private float contentAspectRatio;

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

        public Camera(ResizeViewport resizeViewport = ResizeViewport.KeepWidth)
        {
            Instance = this;
            this.resizeViewport = resizeViewport;
        }

        public Camera(Transform transform, ResizeViewport resizeViewport = ResizeViewport.KeepWidth)
            : base(transform)
        {
            Instance = this;
            this.resizeViewport = resizeViewport;
        }

        public Camera(Transform transform, float contentAspectRatio)
            : base(transform)
        {
            Instance = this;
            resizeViewport = ResizeViewport.KeepContentAspectRatio;
            this.contentAspectRatio = contentAspectRatio;
        }


        public void Resize(int width, int height)
        {
            switch (resizeViewport)
            {
                case ResizeViewport.KeepContentAspectRatio:
                    ResizeKeepContentAspectRatio(width, height);
                    break;
                case ResizeViewport.KeepWidth:
                    ResizeKeepWidth(width, height);
                    break;
                case ResizeViewport.KeepHeight:
                    ResizeKeepHeight(width, height);
                    break;
                default:
                    throw new ArgumentException("Invalid " + nameof(ResizeViewport));
            }
        }

        private void ResizeKeepContentAspectRatio(int width, int height)
        {
            GL.LoadIdentity();
            GL.Viewport(0, 0, width, height);
            var aspectRatio = (float) width / height;
            if (aspectRatio < contentAspectRatio)
            {
                GL.Scale(new Vector3(
                    1 / transform.scale.X,
                    1 / transform.scale.Y * aspectRatio,
                    0f));
            }
            else
            {
                GL.Scale(new Vector3(
                    1 / transform.scale.X / aspectRatio,
                    1 / transform.scale.Y,
                    0f));
            }
        }

        [Obsolete]
        private void ResizeScaleContentByWindow(int width, int height)
        {
            GL.LoadIdentity();
            GL.Viewport(0, 0, width, height);
            // added 1
            GL.Scale(new Vector3(1 / transform.scale.X / width, 1 / transform.scale.Y / height, 0f));
        }

        private void ResizeKeepWidth(int width, int height)
        {
            GL.LoadIdentity();
            GL.Viewport(0, 0, width, height);
            var aspectRatio = (float) width / height;
            GL.Scale(new Vector3(
                1 / transform.scale.X,
                1 / transform.scale.Y * aspectRatio,
                0f));
        }

        private void ResizeKeepHeight(int width, int height)
        {
            GL.LoadIdentity();
            GL.Viewport(0, 0, width, height);
            var aspectRatio = (float) width / height;
            GL.Scale(new Vector3(
                1 / transform.scale.X / aspectRatio,
                1 / transform.scale.Y,
                0f));
        }
    }
}