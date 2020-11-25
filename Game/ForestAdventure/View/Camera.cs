using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ForestAdventure.View
{
    [Obsolete]
    public class Camera
    {
        private Vector2 center = new Vector2(0, 0);

        private float scale = 1f;

        // public Matrix4 CameraMatrix => cameraMatrix;
        // public Matrix4 InvViewportMatrix { get; private set; }
        // private Matrix4 cameraMatrix = Matrix4.Identity;
        // private float _invWindowAspectRatio = 1f;
        public Vector2 Center
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

        internal float Scale
        {
            get => scale;
            set
            {
                // avoid division by 0 and negative
                scale = MathF.Max(0.001f, value);
                UpdateMatrix();
            }
        }

        public void Draw()
        {
            // TODO
            // GL.LoadMatrix(ref cameraMatrix);
        }

        internal void Resize(int width, int height)
        {
            GL.Viewport(0, 0, width, height);

            // _invWindowAspectRatio = height / (float)width;
            // InvViewportMatrix = Transformation.Combine(Transformation.Scale(2f / width, 2f / height), Transformation.Translate(-Vector2.One));
            // UpdateMatrix();
        }

        private void UpdateMatrix()
        {
            // TODO
            // var translate = Transformation.Translate(-Center);
            // var scale = Transformation.Scale(1f / Scale);
            // var aspect = Transformation.Scale(_invWindowAspectRatio, 1f);
            // cameraMatrix = Transformation.Combine(translate, scale, aspect);
        }
    }
}