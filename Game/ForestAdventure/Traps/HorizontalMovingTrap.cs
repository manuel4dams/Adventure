using System.Drawing;
using Framework.Collision.Collider;
using Framework.Development.Components;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Traps
{
    public class HorizontalMovingTrap : GameObject
    {
        public HorizontalMovingTrap(
            Vector2 position,
            float movementBorderLeft,
            float movementBorderRight)
        {
            transform.position = position;

            var bodyBounds = new RectangleBounds(1f, 1f);
            var colliderBounds = new RectangleBounds(0f, 0f, 0.6f, 0.6f);

            AddComponent(new RectangleTextureRenderer(
                this,
                bodyBounds,
                Resources.Resources.Spiked_Ball,
                RenderScaleType.Crop));
            AddComponent(new RectangleColliderComponent(this, bodyBounds, true));
            AddComponent(new TrapMovementComponent(this, movementBorderLeft, movementBorderRight));
#if DEBUG
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bodyBounds, Color.GreenYellow));
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, colliderBounds));
#endif
        }
    }
}