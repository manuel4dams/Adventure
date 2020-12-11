using System;
using Framework.Components;
using Framework.Development.Components;
using Framework.Interfaces;
using Framework.Objects;
using Framework.Util;
using OpenTK;
using OpenTK.Graphics;

namespace ForestAdventure.Objects
{
    public class Arrow : GameObject, IUpdateable, ICollision
    {
        private const float GRAVITY_CONSTANT = 9.81f;
        private const float FORCE_INITIAL_MULTIPLIER = 30f;
        private const float FORCE_DRAIN = 0.99f;
        private float gravityVelocity;
        private bool gravityEnabled = true;
        private Vector2 force;

        public Arrow(Vector2 force)
        {
            this.force = force;
            transform.rotation = MathF.Atan2(force.Y, force.X);

            var arrowBounds = new RectangleBounds(2f, 0.1f);
            AddComponent(new QuadRenderer(this, arrowBounds, Color4.Brown));
            AddComponent(new RectangleCollider(this, arrowBounds, true));
#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
            AddComponent(new DebugColliderEdgesComponent(this, arrowBounds));
#endif
        }

        public void OnCollision(ICollider other, Vector2 touchOffset)
        {
            if (other.gameObject is Platform && touchOffset.Y > 0f)
            {
                force = Vector2.Zero;
                gravityEnabled = false;
            }

            if (other.gameObject is Enemy)
            {
                // TODO kill enemy
                Console.WriteLine("Enemy hit");
            }
        }

        public void Update(float deltaTime)
        {
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

            // Calculate rotation by position change
            var positionOffset = previousPosition - transform.position;
            // transform.rotation = MathF.Atan2(positionOffset.Y, positionOffset.X);
            transform.rotation =
                LerpUtils.Lerp(transform.rotation, MathF.Atan2(positionOffset.Y, positionOffset.X), 0.1f);
        }
    }
}