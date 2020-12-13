<<<<<<< HEAD
﻿using Framework.Interfaces;
=======
﻿using System;
using Framework.Interfaces;
>>>>>>> master

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

<<<<<<< HEAD
            var offset = CollisionCalculator.UnrotatedOverlap(colliderA, colliderB);
            (colliderA.gameObject as ICollision)?.OnCollision(colliderB, offset);
            colliderA.gameObject.components
                .ForEach(component => (component as ICollision)?.OnCollision(colliderB, offset));
=======
            (colliderA.gameObject as ICollision)?.OnCollision(colliderB);
            colliderA.gameObject.components
                .ForEach(component => (component as ICollision)?.OnCollision(colliderB));
>>>>>>> master

            if (colliderA.isTrigger || colliderB.isTrigger || colliderA.isStatic)
            {
                return;
            }

<<<<<<< HEAD
            colliderA.gameObject.transform.position += offset;
=======
            Console.WriteLine(CollisionCalculator.UnrotatedOverlap(colliderA, colliderB));
            colliderA.gameObject.transform.position += CollisionCalculator.UnrotatedOverlap(colliderA, colliderB);
>>>>>>> master
        }
    }
}