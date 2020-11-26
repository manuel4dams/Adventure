using Framework.Components;
using Framework.Objects;

namespace ForestAdventure.Objects
{
    public class Entrance : GameObject
    {
        public Entrance(float minX, float minY, float sizeX, float sizeY)
        {
            Bounds bounds = new Bounds(minX, minY, sizeX, sizeY);
            AddComponent(new RectangleComponent(this, bounds));
        }
    }
}