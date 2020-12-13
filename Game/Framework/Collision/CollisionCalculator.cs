using System;
using Framework.Collision.Calculation;
using Framework.Components;
using Framework.Interfaces;
using OpenTK;

namespace Framework.Collision
{
    public static class CollisionCalculator
    {
<<<<<<< HEAD
        public static bool UnrotatedIntersects(ICollider colliderA, ICollider colliderB)
        {
            switch (colliderA)
            {
                case RectangleCollider rectangleA:
                    switch (colliderB)
                    {
                        case RectangleCollider rectangleB:
                            return RectangleRectangleUnrotatedCalculator.Intersects(
                                rectangleA.bounds,
                                rectangleA.gameObject.transform,
                                rectangleB.bounds,
                                rectangleB.gameObject.transform);
                        case CircleCollider circleB:
                            return RectangleCircleUnrotatedCalculator.Intersects(circleB, rectangleA);
=======
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
>>>>>>> master
                        default:
                            throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
                    }

<<<<<<< HEAD
                case CircleCollider circleA:
                    switch (colliderB)
                    {
                        case RectangleCollider rectangleB:
                            return RectangleCircleUnrotatedCalculator.Intersects(circleA, rectangleB);
                        case CircleCollider circleB:
                            return CircleCircleUnrotatedCalculator.Intersects(circleA, circleB);
=======
                case CircleCollider firstCircle:
                    switch (second)
                    {
                        case RectangleCollider secondRectangle:
                            return RectangleCircleCollisionCalculator.UnrotatedIntersects(firstCircle, secondRectangle);
                        case CircleCollider secondCircle:
                            return CircleCircleCollisionCalculator.Intersects(firstCircle, secondCircle);
>>>>>>> master
                        default:
                            throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
                    }

                default:
                    throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
            }
        }

<<<<<<< HEAD
        public static Vector2 UnrotatedOverlap(ICollider colliderA, ICollider colliderB)
        {
            switch (colliderA)
            {
                case RectangleCollider rectangleA:
                    switch (colliderB)
                    {
                        case RectangleCollider rectangleB:
                            return RectangleRectangleUnrotatedCalculator.CalculateOverlapOffset(
                                rectangleA.bounds,
                                rectangleA.gameObject.transform,
                                rectangleB.bounds,
                                rectangleB.gameObject.transform);
                        case CircleCollider circleB:
                            return RectangleCircleUnrotatedCalculator.CalculateOverlapOffset(
                                rectangleA,
                                circleB);
=======
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
>>>>>>> master
                        default:
                            throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
                    }

<<<<<<< HEAD
                case CircleCollider circleA:
                    switch (colliderB)
                    {
                        case RectangleCollider rectangleB:
                            return RectangleCircleUnrotatedCalculator.CalculateOverlapOffset(
                                circleA,
                                rectangleB);
                        case CircleCollider circleB:
                            return CircleCircleUnrotatedCalculator.CalculateOverlapOffset(
                                circleA,
                                circleB);
=======
                case CircleCollider firstCircle:
                    switch (second)
                    {
                        case RectangleCollider secondRectangle:
                            return RectangleCircleOverlapCalculator.CalculateUnrotatedOverlapOffset(
                                firstCircle,
                                secondRectangle);
                        case CircleCollider secondCircle:
                            return CircleCircleOverlapCalculator.CalculateUnrotatedOverlapOffset(
                                firstCircle,
                                secondCircle);
>>>>>>> master
                        default:
                            throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
                    }

                default:
                    throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
            }
        }
    }
}