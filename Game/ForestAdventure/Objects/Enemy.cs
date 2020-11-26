using ForestAdventure.Components;
using Framework.Components;
using Framework.Objects;

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
            var bounds = new Bounds(minX, minY, sizeX, sizeY);
            AddComponent(new RectangleComponent(this, bounds));
            AddComponent(new MovementNoInputComponent(this, movementBorderLeft, movementBorderRight));
        }
    }
}