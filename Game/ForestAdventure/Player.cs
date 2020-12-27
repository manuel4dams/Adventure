using ForestAdventure.Bow;
using ForestAdventure.Enemies;
using ForestAdventure.GameCamera;
using ForestAdventure.Level;
using ForestAdventure.PlayerComponents;
using Framework.Collision.Collider;
using Framework.Game;
using Framework.Interfaces;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure
{
    public class Player : GameObject, ICollision
    {
        public Player()
        {
            transform.position = new Vector2(3f, 8f);

            var bodyBounds = new RectangleBounds(2f, 3f);
            AddComponent(new RectangleTextureRenderer(this, bodyBounds, Resources.PlayerRight));
            AddComponent(new RectangleColliderComponent(this, bodyBounds));
            AddComponent(new PlayerMovementComponent(this));
            AddComponent(new CameraFollowObjectComponent(this));
            AddComponent(new BowComponent(this));
        }

        public void OnCollision(ICollider other, Vector2 touchOffset)
        {
            if (other.gameObject is Enemy)
            {
                ForestAdventure.GameEnded(transform.position);
            }
            else if (other.gameObject is Exit)
            {
                ForestAdventure.GameEnded(transform.position, true);
            }
        }
    }
}