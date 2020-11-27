using ForestAdventure.Components;
using Framework.Components;
using Framework.Objects;
using OpenTK;

namespace ForestAdventure.Objects
{
    public class Enemy : GameObject
    {
        public Enemy(
            Vector2 position,
            float movementBorderLeft,
            float movementBorderRight)
        {
            transform.position = position;

            var bodyBounds = new Bounds(0.075f, 0.075f);
            AddComponent(new RectangleComponent(this, bodyBounds));
            AddComponent(new MovementNoInputComponent(this, movementBorderLeft, movementBorderRight));
#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
#endif
        }
    }
}