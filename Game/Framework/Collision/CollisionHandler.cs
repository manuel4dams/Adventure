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
            // TODO ad method to get colliderA.gameObject as ICollision to remove reference
            // splitting tomethods does not change the reference occurance in vs
            (colliderA.gameObject as ICollision)?.OnCollision(colliderB, offset);
            // TODO ad method to get colliderA.gameObject.components as ICollision to remove reference
            // splitting tomethods does not change the reference occurance in vs
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