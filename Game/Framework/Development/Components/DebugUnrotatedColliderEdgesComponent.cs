using Framework.Game;
using Framework.Interfaces;
using Framework.Shapes;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Framework.Development.Components
{
    public class DebugUnrotatedColliderEdgesComponent : IComponent, IRender
    {
        private readonly RectangleBounds rectangleBounds;

        public GameObject gameObject { get; }

        public DebugUnrotatedColliderEdgesComponent(GameObject gameObject, RectangleBounds rectangleBounds)
        {
            this.rectangleBounds = rectangleBounds;
            this.gameObject = gameObject;
        }

        public void Draw()
        {
            GL.Color4(Color.Pink);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(
                gameObject.transform.position.X + rectangleBounds.minX - Camera.Camera.instance.transform.position.X,
                gameObject.transform.position.Y + rectangleBounds.minY - Camera.Camera.instance.transform.position.Y);
            GL.Vertex2(
                gameObject.transform.position.X + rectangleBounds.maxX - Camera.Camera.instance.transform.position.X,
                gameObject.transform.position.Y + rectangleBounds.minY - Camera.Camera.instance.transform.position.Y);
            GL.Vertex2(
                gameObject.transform.position.X + rectangleBounds.minX - Camera.Camera.instance.transform.position.X,
                gameObject.transform.position.Y + rectangleBounds.minY - Camera.Camera.instance.transform.position.Y);
            GL.Vertex2(
                gameObject.transform.position.X + rectangleBounds.minX - Camera.Camera.instance.transform.position.X,
                gameObject.transform.position.Y + rectangleBounds.maxY - Camera.Camera.instance.transform.position.Y);
            GL.Vertex2(
                gameObject.transform.position.X + rectangleBounds.maxX - Camera.Camera.instance.transform.position.X,
                gameObject.transform.position.Y + rectangleBounds.minY - Camera.Camera.instance.transform.position.Y);
            GL.Vertex2(
                gameObject.transform.position.X + rectangleBounds.maxX - Camera.Camera.instance.transform.position.X,
                gameObject.transform.position.Y + rectangleBounds.maxY - Camera.Camera.instance.transform.position.Y);
            GL.Vertex2(
                gameObject.transform.position.X + rectangleBounds.maxX - Camera.Camera.instance.transform.position.X,
                gameObject.transform.position.Y + rectangleBounds.maxY - Camera.Camera.instance.transform.position.Y);
            GL.Vertex2(
                gameObject.transform.position.X + rectangleBounds.minX - Camera.Camera.instance.transform.position.X,
                gameObject.transform.position.Y + rectangleBounds.maxY - Camera.Camera.instance.transform.position.Y);
            GL.End();
        }
    }
}