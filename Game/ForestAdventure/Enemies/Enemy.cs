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

            var bodyBounds = new RectangleBounds(2f, 3f);
            AddComponent(new RectangleTextureRenderer(this, bodyBounds, Resources.EnemyRight));
            AddComponent(new RectangleColliderComponent(this, bodyBounds, true));
            AddComponent(new MovementNoInputComponent(this, movementBorderLeft, movementBorderRight));
        }
    }
}