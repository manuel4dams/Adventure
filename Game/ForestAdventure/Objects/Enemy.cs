using ForestAdventure.Components;

namespace ForestAdventure.Objects
{
    public class Enemy : GameObject
    {
        public Enemy(
            float minX,
            float minY,
            float sizeX,
            float sizeY,
            float movementBorderLeft,
            float movementBorderRight)
        {
            Bounds bounds = new Bounds(minX, minY, sizeX, sizeY);
            AddComponent(new RectangleComponent(bounds));
            AddComponent(new MovementNoInputComponent(movementBorderLeft, movementBorderRight, bounds));
        }
    }
}