using System;
using ForestAdventure.Components;
using Framework.Collision.Collider;
using Framework.Development.Components;
using Framework.Game;
using Framework.Interfaces;
using Framework.Render;
using Framework.Shapes;
using OpenTK;
using OpenTK.Graphics;

namespace ForestAdventure.Objects
{
    public class Player : GameObject, ICollision
    {
        public Player()
        {
            transform.position = new Vector2(1f, 1f);

            var bodyBounds = new RectangleBounds(0.5f, 2f);
            AddComponent(new QuadRenderer(this, bodyBounds, new Color4(5, 128, 13, 255)));
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
                transform.position = new Vector2(0f, 0f);
            }
            else if (other.gameObject is Exit)
            {
                // TODO won status
                Console.WriteLine("Game Won");
            }
        }
    }
}