using System.Drawing;
using Framework.Collision.Collider;
using Framework.Development.Components;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Traps
{
    public class VerticalMovingTrap : GameObject
    {
        public VerticalMovingTrap(
            Vector2 position,
            float movementBorderBottom,
            float movementBorderTop)
        {
            transform.position = position;

            var bodyBounds = new RectangleBounds(1f, 1f);
            var colliderBounds = new RectangleBounds(0f, 0f, 0.6f, 0.6f);

            AddComponent(new RectangleTextureRenderer(
                this,
                bodyBounds,
                Resources.Resources.WoodenPlatform,
                RenderScaleType.Crop));
            AddComponent(new RectangleColliderComponent(this, bodyBounds, true));
            AddComponent(new TrapMovementComponent(
                this,
                movementBorderBottom,
                movementBorderTop,
                TrapMovementComponent.MovementDirection.Vertical));
#if DEBUG
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bodyBounds, Color.GreenYellow));
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, colliderBounds));
#endif
        }
    }
}