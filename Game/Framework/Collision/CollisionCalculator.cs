using System;
using Framework.Collision.Calculation;
using Framework.Components;
using Framework.Interfaces;
using OpenTK;

namespace Framework.Collision
{
    public static class CollisionCalculator
    {
        public static bool UnrotatedIntersects(ICollider first, ICollider second)
        {
            switch (first)
            {
                case RectangleCollider firstRectangle:
                    switch (second)
                    {
                        case RectangleCollider secondRectangle:
                            return RectangleRectangleCollisionCalculator.UnrotatedIntersects(
                                firstRectangle,
                                secondRectangle);
                        case CircleCollider secondCircle:
                            return RectangleCircleCollisionCalculator.UnrotatedIntersects(secondCircle, firstRectangle);
                        default:
                            // TODO throw new ArgumentException("Invalid " + typeof(VierportAnchor).Name);
                            throw new ArgumentOutOfRangeException(second.GetType().ToString());
                    }

                case CircleCollider firstCircle:
                    switch (second)
                    {
                        case RectangleCollider secondRectangle:
                            return RectangleCircleCollisionCalculator.UnrotatedIntersects(firstCircle, secondRectangle);
                        case CircleCollider secondCircle:
                            return CircleCircleCollisionCalculator.Intersects(firstCircle, secondCircle);
                        default:
                            throw new ArgumentOutOfRangeException(second.GetType().ToString());
                    }

                default:
                    throw new ArgumentOutOfRangeException(first.GetType().ToString());
            }
        }

        public static Vector2 UnrotatedOverlap(ICollider first, ICollider second)
        {
            switch (first)
            {
                case RectangleCollider firstRectangle:
                    switch (second)
                    {
                        case RectangleCollider secondRectangle:
                            return RectangleRectangleOverlapCalculator.CalculateUnrotatedOverlapOffset(
                                firstRectangle,
                                secondRectangle);
                        case CircleCollider secondCircle:
                            return RectangleCircleOverlapCalculator.UnrotatedOverlap(firstRectangle, secondCircle);
                        default:
                            throw new ArgumentOutOfRangeException(second.GetType().ToString());
                    }

                case CircleCollider firstCircle:
                    switch (second)
                    {
                        case RectangleCollider secondRectangle:
                            return RectangleCircleOverlapCalculator.CalculateUnrotatedOverlapOffset(firstCircle, secondRectangle);
                        case CircleCollider secondCircle:
                            return CircleCircleOverlapCalculator.CalculateUnrotatedOverlapOffset(firstCircle, secondCircle);
                        default:
                            throw new ArgumentOutOfRangeException(second.GetType().ToString());
                    }

                default:
                    throw new ArgumentOutOfRangeException(first.GetType().ToString());
            }
        }
    }
}