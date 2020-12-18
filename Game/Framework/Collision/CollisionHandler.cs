using Framework.Interfaces;
using Framework.References;

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
            GameReferences.GameObjectAsICollision(colliderA.gameObject)?.OnCollision(colliderB, offset);
            colliderA.gameObject.components
                .ForEach(component => GameReferences.ComponentAsICollision(component)?.OnCollision(colliderB, offset));

            if (colliderA.isTrigger || colliderB.isTrigger || colliderA.isStatic)
            {
                return;
            }

            colliderA.gameObject.transform.position += offset;
        }
    }
}