using Framework.Components;
using Framework.Objects;

namespace ForestAdventure.Objects
{
    public class Exit : GameObject
    {
        public Exit(float minX, float minY, float sizeX, float sizeY)
        {
            var bounds = new Bounds(minX, minY, sizeX, sizeY);
            AddComponent(new RectangleComponent(this, bounds));
        }
    }
}