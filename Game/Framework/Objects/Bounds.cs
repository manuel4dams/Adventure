using OpenTK;

namespace Framework.Objects
{
    public class Bounds
    {
        private readonly Vector2 size;
        private Vector2 center;


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

        public float minX
        {
            get => center.X - size.X / 2f;
            set => center.X = value + size.X / 2f;
        }

        public float maxX
        {
            get => center.X + size.X / 2f;
            set => center.X = value - size.X / 2f;
        }

        public float minY
        {
            get => center.Y - size.Y / 2f;
            set => center.Y = value + size.Y / 2f;
        }

        public float maxY
        {
            get => center.Y + size.Y / 2f;
            set => center.Y = value - size.Y / 2f;
        }
    }
}