namespace Framework.Objects
{
    public class Bounds
    {
        public Bounds(float minX, float minY, float sizeX, float sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            // todo rename minX/Y
            MinX = minX;
            MinY = minY;
        }

        public float SizeX { get; set; }

        public float SizeY { get; set; }

        public float MinX { get; set; }

        public float MaxX => MinX + SizeX;

        public float MinY { get; set; }

        public float MaxY => MinY + SizeY;
    }
}