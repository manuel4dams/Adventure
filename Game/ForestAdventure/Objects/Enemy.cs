using ForestAdventure.Components;
using Framework.Components;
using Framework.Development.Components;
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics;

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

            var bodyBounds = new RectangleBounds(0.6f, 1.7f);
            AddComponent(new QuadRenderer(this, bodyBounds, new Color4(184, 12, 0, 255)));
            AddComponent(new RectangleCollider(this, bodyBounds, true));

            AddComponent(new MovementNoInputComponent(this, movementBorderLeft, movementBorderRight));
#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
            AddComponent(new DebugColliderEdgesComponent(this, bodyBounds));
#endif
        }
    }
}