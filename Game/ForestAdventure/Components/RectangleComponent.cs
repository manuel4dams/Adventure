using ForestAdventure.Interfaces;

namespace ForestAdventure.Components
{
    public class RectangleComponent : IRectangle
    {
        public RectangleComponent(float minX, float minY, float sizeX, float sizeY)
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