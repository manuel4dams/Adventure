using System;
using Framework.Collision.Calculation;
using Framework.Collision.Collider;
using Framework.Interfaces;
using OpenTK;

namespace Framework.Collision
{
    public static class CollisionCalculator
    {
        public static bool UnrotatedIntersects(ICollider colliderA, ICollider colliderB)
        {
            switch (colliderA)
            {
                case RectangleColliderComponent rectangleA:
                    switch (colliderB)
                    {
                        case RectangleColliderComponent rectangleB:
                            return RectangleRectangleUnrotatedCalculator.Intersects(
                                rectangleA.bounds,
                                rectangleA.gameObject.transform,
                                rectangleB.bounds,
                                rectangleB.gameObject.transform);
                        default:
                            throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
                    }

                default:
                    throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
            }
        }

        public static Vector2 UnrotatedOverlap(ICollider colliderA, ICollider colliderB)
        {
            switch (colliderA)
            {
                case RectangleColliderComponent rectangleA:
                    switch (colliderB)
                    {
                        case RectangleColliderComponent rectangleB:
                            return RectangleRectangleUnrotatedCalculator.CalculateOverlapOffset(
                                rectangleA.bounds,
                                rectangleA.gameObject.transform,
                                rectangleB.bounds,
                                rectangleB.gameObject.transform);
                        default:
                            throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
                    }

                default:
                    throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
            }
        }
    }
}