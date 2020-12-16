using Framework.Camera;
using Framework.Game;
using Framework.Interfaces;
using Framework.Render;
using Framework.Shapes;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace ForestAdventure.Objects.Develop
{
    public class DebugGameObject : GameObject, IUpdateable
    {
        public DebugGameObject()
        {
            transform.scale = new Vector2(1f, 2f);
            transform.position = new Vector2(3f, 1f);

            var bounds = new RectangleBounds(8f, 2f);
            AddComponent(new QuadRenderer(this, bounds, Color4.Cyan));
            AddComponent(new RectanglePointRenderer(this, bounds, 8f));
        }

        public void Update(float deltaTime)
        {
            transform.rotation += deltaTime;
            if (!Keyboard.GetState().IsKeyDown(Key.Space))
                transform.rotation = 0f;
        }

        private class RectanglePointRenderer : IComponent, IRender
        {
            private readonly RectangleBounds rectangleBounds;
            private readonly float pointSize;

            public GameObject gameObject { get; }

            public RectanglePointRenderer(GameObject gameObject, RectangleBounds rectangleBounds, float pointSize = 1f)
            {
                this.gameObject = gameObject;
                this.rectangleBounds = rectangleBounds;
                this.pointSize = pointSize;
            }

            public void Draw()
            {
                var rectangle = rectangleBounds.Transform(gameObject.transform);
                rectangle.Translate(-Camera.instance.transform.position);

                GL.PointSize(pointSize);
                GL.Begin(PrimitiveType.Points);
                GL.Color4(new Color4(1f, 0f, 0f, 1f));
                GL.Vertex2(rectangle.vertex1);
                GL.Color4(new Color4(1f, 0.4f, 0.4f, 1f));
                GL.Vertex2(rectangle.vertex2);
                GL.Color4(new Color4(1f, 0.6f, 0.6f, 1f));
                GL.Vertex2(rectangle.vertex3);
                GL.Color4(new Color4(1f, 0.8f, 0.8f, 1f));
                GL.Vertex2(rectangle.vertex4);
                GL.End();
            }
        }
    }
}