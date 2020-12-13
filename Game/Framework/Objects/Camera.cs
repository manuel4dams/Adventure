using System;
using System.Linq.Expressions;
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

        private static Camera instanceInternal;
        private readonly float contentAspectRatio;
        private readonly ResizeViewport resizeViewport;

        public Camera(ResizeViewport resizeViewport = ResizeViewport.KeepWidth)
        {
            instance = this;
            this.resizeViewport = resizeViewport;
        }

        public Camera(Transform transform, ResizeViewport resizeViewport = ResizeViewport.KeepWidth)
            : base(transform)
        {
            instance = this;
            this.resizeViewport = resizeViewport;
        }

        public Camera(Transform transform, float contentAspectRatio)
            : base(transform)
        {
            instance = this;
            resizeViewport = ResizeViewport.KeepContentAspectRatio;
            this.contentAspectRatio = contentAspectRatio;
        }

        public static Camera instance
        {
            get => instanceInternal;
            set
            {
                if (instanceInternal != null)
                {
                    throw new Exception("Only one camera allowed");
                }

                instanceInternal = value;
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

        public Vector2 MousePositionToWorld()
        {
            return MousePositionToWorld(Mouse.GetCursorState());
        }

        public Vector2 MousePositionToWorld(MouseState mouseState)
        {
            return MousePositionToWorld(mouseState.X, mouseState.Y);
        }

        public Vector2 MousePositionToWorld(float x, float y)
        {
            var canvasScreenOffset = Game.instance.gameWindow.PointToClient(new Point(0, 0));
            var mousePositionInCanvas = new Vector2(x + canvasScreenOffset.X, y + canvasScreenOffset.Y);
            var mousePositionRelativeToCanvas = new Vector2(
                mousePositionInCanvas.X / Game.instance.gameWindow.Width * 2f - 1f,
                -(mousePositionInCanvas.Y / Game.instance.gameWindow.Height * 2f - 1f));

            // TODO Maybe separate into different methods and reuse them also in the Resize() functions?
            var aspectRatio = (float) Game.instance.gameWindow.Width / Game.instance.gameWindow.Height;
            Vector2 mousePositionRespectingAspectRatio;
            switch (resizeViewport)
            {
                case ResizeViewport.KeepContentAspectRatio:
                    if (aspectRatio < contentAspectRatio)
                    {
                        mousePositionRespectingAspectRatio =
                            mousePositionRelativeToCanvas * new Vector2(1f, 1f / aspectRatio);
                    }
                    else
                    {
                        mousePositionRespectingAspectRatio =
                            mousePositionRelativeToCanvas * new Vector2(aspectRatio, 1f);
                    }

                    break;
                case ResizeViewport.KeepWidth:
                    mousePositionRespectingAspectRatio =
                        mousePositionRelativeToCanvas * new Vector2(1f, 1f / aspectRatio);
                    break;
                case ResizeViewport.KeepHeight:
                    mousePositionRespectingAspectRatio =
                        mousePositionRelativeToCanvas * new Vector2(aspectRatio, 1f);
                    break;
                default:
                    throw new ArgumentException("Invalid " + nameof(ResizeViewport));
            }

            var scaled = mousePositionRespectingAspectRatio * transform.scale;
            var positioned = transform.TranslatePosition(scaled);
            return positioned;
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