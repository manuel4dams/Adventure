using OpenTK;

namespace Framework.Objects
{
    public class Bounds
    {
        private Vector2 center;
        private Vector2 size;

        public Bounds(Vector2 size)
            : this(Vector2.Zero, size)
        {
            this.size = size;
        }

        public Bounds(Vector2 center, Vector2 size)
        {
            this.center = center;
            this.size = size;
        }

        public Bounds(float sizeX, float sizeY)
            : this(new Vector2(sizeX, sizeY))
        {
        }

        public Bounds(float centerX, float centerY, float sizeX, float sizeY)
            : this(new Vector2(centerX, centerY), new Vector2(sizeX, sizeY))
        {
        }

        public float centerX
        {
            get { return center.X; } set { center.X = value; }
        }

        public float centerY
        {
            get { return center.Y; } set { center.Y = value; }
        }

        public float minX => center.X - size.X / 2f;

        public float maxX => center.X + size.X / 2f;

        public float minY => center.Y - size.Y / 2f;

        public float maxY => center.Y + size.Y / 2f;
    }
}