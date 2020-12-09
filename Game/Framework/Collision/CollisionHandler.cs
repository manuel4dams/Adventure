using System;
using Framework.Interfaces;

namespace Framework.Collision
{
    public static class CollisionHandler
    {
        public static void HandleCollision(ICollider colliderA, ICollider colliderB)
        {
            if (!CollisionCalculator.UnrotatedIntersects(colliderA, colliderB))
            {
                return;
            }

            var offset = CollisionCalculator.UnrotatedOverlap(colliderA, colliderB);
            (colliderA.gameObject as ICollision)?.OnCollision(colliderB, offset);
            colliderA.gameObject.components
                .ForEach(component => (component as ICollision)?.OnCollision(colliderB, offset));

            if (colliderA.isTrigger || colliderB.isTrigger || colliderA.isStatic)
            {
                return;
            }

            colliderA.gameObject.transform.position += offset;
        }
    }
}