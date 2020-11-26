namespace ForestAdventure.Objects
{
    public class Exit : GameObject
    {
        public Exit(float minX, float minY, float sizeX, float sizeY)
        {
            Bounds bounds = new Bounds(minX, minY, sizeX, sizeY);
            AddComponent(new RectangleComponent(bounds));
        }
    }
}