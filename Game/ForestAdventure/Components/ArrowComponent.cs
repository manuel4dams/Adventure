using System;
using Framework.Interfaces;
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace ForestAdventure.Components
{
    [Obsolete]
    public class ArrowComponent : IComponent, IUpdateable, IDrawable
    {
        private readonly Bounds bounds;

        private readonly Vector2 direction;

        private readonly float force;

        public ArrowComponent(GameObject gameObject, float force, Vector2 direction)
        {
            this.gameObject = gameObject;
            this.force = force;
            this.direction = direction;
            bounds = new Bounds(gameObject.transform.position.X, gameObject.transform.position.Y, 2f, 0.1f);
#if DEBUG
            Console.WriteLine(
                "Mouseclick at: " + "X, " +
                Mouse.GetCursorState().X + "Y, " +
                Mouse.GetCursorState().Y);
#endif
        }
        // TODO add gravity falloff to arrows

        public GameObject gameObject { get; }

        public void Draw()
        {
            GL.Color4(Color4.Brown);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.minX - Camera.Instance.transform.position.X,
                gameObject.transform.position.Y + bounds.minY - Camera.Instance.transform.position.Y);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.maxX - Camera.Instance.transform.position.X,
                gameObject.transform.position.Y + bounds.minY - Camera.Instance.transform.position.Y);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.maxX - Camera.Instance.transform.position.X,
                gameObject.transform.position.Y + bounds.maxY - Camera.Instance.transform.position.Y);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(
                gameObject.transform.position.X + bounds.minX - Camera.Instance.transform.position.X,
                gameObject.transform.position.Y + bounds.maxY - Camera.Instance.transform.position.Y);
            GL.End();
        }

        public void Update(float deltaTime)
        {
            gameObject.transform.position.X += direction.X * force * deltaTime;
            gameObject.transform.position.Y += direction.Y * force * deltaTime;
        }
    }
}