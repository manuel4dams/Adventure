using System;
using System.Collections.Generic;
using System.Text;
using Framework.Interfaces;
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ForestAdventure.Components
{
    public class ArrowComponent : IUpdateable, IDrawable
    {
        private Bounds bounds;
        private float force;
        private Vector2 direction;

        public ArrowComponent(GameObject gameObject, float force, Vector2 direction)
        {
            this.gameObject = gameObject;
            this.force = force;
            this.direction = direction;
            bounds = new Bounds(gameObject.transform.position.X, gameObject.transform.position.Y, 0.1f, 0.01f);

            // Debug um mausposition zu sehen
            // bounds = new Bounds(OpenTK.Input.Mouse.GetCursorState().X, OpenTK.Input.Mouse.GetCursorState().Y , 0.1f, 0.01f);
        }

        public GameObject gameObject { get; }

        public void Draw()
        {
            GL.Color4(Color4.Brown);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.minX - Camera.Instance.centerPosition.X,
                gameObject.transform.position.Y + bounds.minY - Camera.Instance.centerPosition.Y);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.maxX - Camera.Instance.centerPosition.X,
                gameObject.transform.position.Y + bounds.minY - Camera.Instance.centerPosition.Y);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.maxX - Camera.Instance.centerPosition.X,
                gameObject.transform.position.Y + bounds.maxY - Camera.Instance.centerPosition.Y);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.minX - Camera.Instance.centerPosition.X,
                gameObject.transform.position.Y + bounds.maxY - Camera.Instance.centerPosition.Y);
            GL.End();
        }

        public void Update(float deltaTime)
        {
            gameObject.transform.position.X += direction.X * this.force * deltaTime;
            gameObject.transform.position.Y += direction.Y * this.force * deltaTime;
        }
    }
}
