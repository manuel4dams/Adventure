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
                            return RectangleRectangleUnrotatedCalculator.Intersects(
                                firstRectangle,
                                secondRectangle);
                        case CircleCollider secondCircle:
                            return RectangleCircleUnrotatedCalculator.Intersects(secondCircle, firstRectangle);
                        default:
                            throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
                    }

                case CircleCollider firstCircle:
                    switch (second)
                    {
                        case RectangleCollider secondRectangle:
                            return RectangleCircleUnrotatedCalculator.Intersects(firstCircle, secondRectangle);
                        case CircleCollider secondCircle:
                            return CircleCircleUnrotatedCalculator.Intersects(firstCircle, secondCircle);
                        default:
                            throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
                    }

                default:
                    throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
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
                            return RectangleRectangleUnrotatedCalculator.CalculateOverlapOffset(
                                firstRectangle,
                                secondRectangle);
                        case CircleCollider secondCircle:
                            return RectangleCircleUnrotatedCalculator.CalculateOverlapOffset(firstRectangle,
                                secondCircle);
                        default:
                            throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
                    }

                case CircleCollider firstCircle:
                    switch (second)
                    {
                        case RectangleCollider secondRectangle:
                            return RectangleCircleUnrotatedCalculator.CalculateOverlapOffset(
                                firstCircle,
                                secondRectangle);
                        case CircleCollider secondCircle:
                            return CircleCircleUnrotatedCalculator.CalculateOverlapOffset(
                                firstCircle,
                                secondCircle);
                        default:
                            throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
                    }

                default:
                    throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
            }
        }
    }
}