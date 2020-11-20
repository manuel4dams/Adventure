using OpenTK.Graphics.OpenGL;

namespace ForestAdventure.Interfaces
{
    public interface IComponent
    {
        float MaxX { get; }

        float MaxY { get; }

        float MinX { get; }

        float MinY { get; }

        public void Update()
        {
            // TODO implement
        }

        public void Draw()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(MinX, MinY);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(MaxX, MinY);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(MaxX, MaxY);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(MinX, MaxY);
            GL.End();
        }
    }
}