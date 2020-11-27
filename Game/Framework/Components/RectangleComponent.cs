﻿using Framework.Interfaces;
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Framework.Components
{
    public class RectangleComponent : IDrawable
    {
        private readonly Bounds bounds;
        private readonly Color color;

        public RectangleComponent(GameObject gameObject, Bounds bounds)
            : this(gameObject, bounds, Color.White)
        {
        }

        public RectangleComponent(GameObject gameObject, Bounds bounds, Color color)
        {
            this.gameObject = gameObject;
            this.bounds = bounds;
            this.color = color;
        }

        public GameObject gameObject { get; }

        public void Draw()
        {
            GL.Color4(color);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(gameObject.transform.position.X + bounds.minX, gameObject.transform.position.Y + bounds.minY);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(gameObject.transform.position.X + bounds.maxX, gameObject.transform.position.Y + bounds.minY);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(gameObject.transform.position.X + bounds.maxX, gameObject.transform.position.Y + bounds.maxY);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(gameObject.transform.position.X + bounds.minX, gameObject.transform.position.Y + bounds.maxY);
            GL.End();
        }
    }
}