using Framework.Collision.Collider;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Enemies
{
    public class Enemy : GameObject
    {
        public Enemy(
            Vector2 position,
            float movementBorderLeft,
            float movementBorderRight)
        {
            transform.position = position;

            var colliderBounds = new RectangleBounds(2f, 3f);
            var textureBounds = new RectangleBounds(3f, 3f);
            AddComponent(new RectangleTextureRenderer(
                this,
                textureBounds,
                Resources.Resources.Enemy,
                RenderScaleType.Crop,
                size: new Vector4(0f, 0f, 0.25f, 1f)));
            AddComponent(new RectangleColliderComponent(this, colliderBounds, true));
            AddComponent(new MovementNoInputComponent(this, movementBorderLeft, movementBorderRight));
        }
    }
}