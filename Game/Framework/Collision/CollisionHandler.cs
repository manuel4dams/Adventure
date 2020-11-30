using System;
using Framework.Interfaces;
using Framework.Objects;

namespace Framework.Collision
{
    public static class CollisionHandler
    {
        public static void HandleCollision(ICollider colliderA, ICollider colliderB)
        {
            if (!CollisionCalculator.UnrotatedIntersects(colliderA, colliderB))
                return;

            (colliderA.gameObject as ICollision)?.OnCollision(colliderB);
            colliderA.gameObject.components
                .ForEach(component => (component as ICollision)?.OnCollision(colliderB));

            if (!colliderA.isTrigger && !colliderB.isTrigger && !colliderA.isStatic)
            {
                Console.WriteLine(CollisionCalculator.UnrotatedOverlap(colliderA, colliderB));
                colliderA.gameObject.transform.position += CollisionCalculator.UnrotatedOverlap(colliderA, colliderB);
            }
        }
    }
}