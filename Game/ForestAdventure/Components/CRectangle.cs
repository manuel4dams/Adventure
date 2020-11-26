using System;
using ForestAdventure.Helper;
using ForestAdventure.Interfaces;
using OpenTK.Graphics.OpenGL;

namespace ForestAdventure.Components
{
    public class CRectangle : IDrawable
    {
        private GameObjectBounds gameObjectBounds;

        public CRectangle(GameObjectBounds gameObjectBounds)
        {
            this.gameObjectBounds = gameObjectBounds;
        }

        public void Draw()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(gameObjectBounds.MinX, gameObjectBounds.MinY);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(gameObjectBounds.MaxX, gameObjectBounds.MinY);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(gameObjectBounds.MaxX, gameObjectBounds.MaxY);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(gameObjectBounds.MinX, gameObjectBounds.MaxY);
            GL.End();
        }
    }
}