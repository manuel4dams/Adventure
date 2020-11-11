using ForestAdventure.Model;

namespace ForestAdventure.View
{
    internal class Rectangle : IRectangle
    {
        public Rectangle(float minX, float minY, float sizeX, float sizeY)
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
    }
}