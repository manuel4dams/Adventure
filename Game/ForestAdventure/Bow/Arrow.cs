using System;
using ForestAdventure.Enemies;
using ForestAdventure.MyPlayer;
using ForestAdventure.Ropes;
using Framework.Collision.Collider;
using Framework.Game;
using Framework.Interfaces;
using Framework.Render;
using Framework.Shapes;
using Framework.Util;
using OpenTK;

namespace ForestAdventure.Bow
{
    public class Arrow : GameObject, IUpdateable, ICollision
    {
        private const float GRAVITY_CONSTANT = 9.81f;
        private const float FORCE_INITIAL_MULTIPLIER = 30f;
        private const float FORCE_DRAIN = 0.99f;

        private readonly float arrowNoCollisionTime;
        private float lifeTime = 5f;
        private float gravityVelocity;
        private bool gravityEnabled = true;
        private Vector2 force;

        public Arrow(Vector2 force)
        {
            arrowNoCollisionTime = lifeTime - 0.04f;
            this.force = force;
            transform.rotation = MathF.Atan2(force.Y, force.X);

            var arrowBounds = new RectangleBounds(2f, 0.1f);
            AddComponent(new RectangleTextureRenderer(this, arrowBounds, Resources.Arrow));
            AddComponent(new RectangleColliderComponent(this, arrowBounds, true));
        }

        public void OnCollision(ICollider other, Vector2 touchOffset)
        {
            switch (other.gameObject)
            {
                case Player _:
                    break;
                case HorizontalRope _:
                    break;
                case VerticalRope _:
                    break;
                case Enemy _:
                    Game.instance.RemoveGameObject(other.gameObject);
                    Game.instance.RemoveGameObject(this);
                    break;
                default:
                    if (lifeTime < arrowNoCollisionTime)
                    {
                        Game.instance.RemoveGameObject(this);
                    }

                    break;
            }
        }

        public void Update(float deltaTime)
        {
            if ((lifeTime -= deltaTime) <= 0)
            {
                Game.instance.RemoveGameObject(this);
            }

            // Cache position
            var previousPosition = transform.position;

            // Apply force
            transform.position += FORCE_INITIAL_MULTIPLIER * deltaTime * force;
            force *= FORCE_DRAIN;

            // Apply gravity
            if (gravityEnabled)
            {
                gravityVelocity += deltaTime * deltaTime * GRAVITY_CONSTANT;
                transform.position += gravityVelocity * new Vector2(0f, -1f);
            }

            // TODO fix rotation of arrows
            // Calculate rotation by position change
            var positionOffset = previousPosition - transform.position;
            transform.rotation =
                LerpUtils.Lerp(transform.rotation, MathF.Atan2(positionOffset.Y, positionOffset.X), 1f);
        }
    }
}