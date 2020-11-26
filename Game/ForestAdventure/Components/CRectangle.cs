using System;
using ForestAdventure.Helper;
using ForestAdventure.Interfaces;
using OpenTK.Graphics.OpenGL;

namespace ForestAdventure.Components
{
    public class CRectangle : IDrawable
    {
        private ObjectData objectData;

        public CRectangle(ObjectData objectData)
        {
            this.objectData = objectData;
        }

        public void Draw()
        {
            Console.WriteLine(objectData.MinX);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(objectData.MinX, objectData.MinY);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(objectData.MaxX, objectData.MinY);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(objectData.MaxX, objectData.MaxY);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(objectData.MinX, objectData.MaxY);
            GL.End();
        }
    }
}