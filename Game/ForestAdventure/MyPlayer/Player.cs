using System;
using System.Drawing;
using ForestAdventure.Bow;
using ForestAdventure.Enemies;
using ForestAdventure.GameCamera;
using ForestAdventure.Level;
using Framework.Collision.Collider;
using Framework.Development.Components;
using Framework.Game;
using Framework.Interfaces;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.MyPlayer
{
    public class Player : GameObject, ICollision
    {
        public Player()
        {
            transform.position = new Vector2(2f, 2f);

            var bodyBounds = new RectangleBounds(0.5f, 2f);
            AddComponent(new RectangleTextureRenderer(this, bodyBounds, Resources.PlayerRight));
            AddComponent(new RectangleColliderComponent(this, bodyBounds));
            AddComponent(new PlayerMovementComponent(this));
            AddComponent(new CameraFollowObjectComponent(this));
            AddComponent(new BowComponent(this));
#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bodyBounds));
#endif
        }

        public void OnCollision(ICollider other, Vector2 touchOffset)
        {
            if (other.gameObject is Enemy)
            {
                // TODO handle death
                transform.position = new Vector2(2f, 2f);
            }
            else if (other.gameObject is Exit)
            {
                // TODO won status
                Console.WriteLine("Game Won");
            }
        }
    }
}