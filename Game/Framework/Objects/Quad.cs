using OpenTK;

namespace Framework.Objects
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

        // TODO add method Scale(), Rotate()
    }
}