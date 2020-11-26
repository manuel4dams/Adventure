using ForestAdventure.Components;

namespace ForestAdventure.Objects
{
    public class Player : GameObject
    {
        public Player(float minX, float minY, float sizeX, float sizeY)
        {
            Bounds bounds = new Bounds(minX, minY, sizeX, sizeY);
            AddComponent(new RectangleComponent(bounds));
            AddComponent(new PlayerMovementComponent(bounds));
        }
    }
}