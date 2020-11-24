using ForestAdventure.Interfaces;
using OpenTK.Graphics.OpenGL;

namespace ForestAdventure.Components
{
    public class CRectangle : IDrawable, IUpdateable
    {
        public CRectangle(float minX, float minY, float sizeX, float sizeY)
        {
            MinX = minX;
            MinY = minY;
            SizeX = sizeX;
            SizeY = sizeY;
        }

        public float MinX { get; set; }

        public float MinY { get; set; }

        public float MaxX => MinX + SizeX;

        public float MaxY => MinY + SizeY;

        public float SizeX { get; }

        public float SizeY { get; }

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