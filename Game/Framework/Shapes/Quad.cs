using System;
using OpenTK;

namespace Framework.Shapes
{
    public struct Quad
    {
        public Vector2 vertex1;
        public Vector2 vertex2;
        public Vector2 vertex3;
        public Vector2 vertex4;

        public void Translate(Vector2 position)
        {
            vertex1 += position;
            vertex2 += position;
            vertex3 += position;
            vertex4 += position;
        }

        public void Scale()
        {
            throw new NotImplementedException();
        }

        public void Rotate()
        {
            throw new NotImplementedException();
        }
    }
}