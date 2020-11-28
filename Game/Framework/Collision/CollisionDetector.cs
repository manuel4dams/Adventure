using Framework.Interfaces;

namespace Framework.Collision
{
    public static class CollisionDetector
    {
        public static void HandleCollision(ICollider colliderA, ICollider colliderB)
        {
            if (!CollisionCalculator.UnrotatedIntersects(colliderA, colliderB))
                return;

            colliderA.gameObject.OnCollision(colliderB);

            if (!colliderA.isTrigger && !colliderB.isTrigger)
            {
                var offset = CollisionCalculator.UnrotatedOverlap(colliderA, colliderB);
                colliderA.gameObject.transform.position += offset;
            }
        }
    }
}