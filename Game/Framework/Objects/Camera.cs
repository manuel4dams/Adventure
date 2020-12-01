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
            /// <summary>
            /// Default value,
            /// Scale Objects by keeping their Aspect ratio
            /// </summary>
            KeepContentAspectRatio,

            /// <summary>
            /// Scale Objects by keeping Width Ratio
            /// </summary>
            KeepWidth,

            /// <summary>
            /// Scale Objects by keeping height Ratio
            /// </summary>
            KeepHeight,
        }

        private static Camera instance;
        private readonly float contentAspectRatio;
        private readonly ResizeViewport resizeViewport;

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

        // TODO fix bug when moving window
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