using OpenTK;

namespace Framework.Objects
{
    public class Bounds
    {
        public Vector2 center;
        public Vector2 size;

        public float MinX => center.X - size.X / 2f;

        public float MaxX => center.X + size.X / 2f;

        public float MinY => center.Y - size.Y / 2f;

        public float MaxY => center.Y + size.Y / 2f;

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
    }
}