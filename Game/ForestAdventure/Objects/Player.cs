using System;
using ForestAdventure.Components;
using Framework.Components;
using Framework.Interfaces;
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics;

namespace ForestAdventure.Objects
{
    public class Player : GameObject, ICollision
    {
        public Player()
        {
            transform.position = new Vector2(0f, 4f);

            var bodyBounds = new Bounds(0.6f, 1.7f);
            AddComponent(new RectangleDrawable(this, bodyBounds, new Color4(5, 128, 13, 255)));

            AddComponent(new RectangleCollider(this, bodyBounds));

            AddComponent(new PlayerMovementComponent(this));
            AddComponent(new CameraFollowObjectComponent(this));

            AddComponent(new BowComponent(this));

#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
            AddComponent(new DebugColliderEdges(this, bodyBounds));
#endif
        }

        public void OnCollision(ICollider other)
        {
            if (other.gameObject is Enemy)
            {
                // TODO handle death
                transform.position = new Vector2(0f, 4f);
            }
            else if (other.gameObject is Exit)
            {
                // TODO won status
                Console.WriteLine("Game Won");
            }
        }
    }
}