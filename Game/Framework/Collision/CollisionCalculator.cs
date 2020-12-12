﻿using System;
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
                case RectangleCollider rectangleA:
                    switch (second)
                    {
                        case RectangleCollider rectangleB:
                            return RectangleRectangleUnrotatedCalculator.Intersects(
                                rectangleA.bounds,
                                rectangleA.gameObject.transform,
                                rectangleB.bounds,
                                rectangleB.gameObject.transform);
                        case CircleCollider circleB:
                            return RectangleCircleUnrotatedCalculator.Intersects(circleB, rectangleA);
                        default:
                            throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
                    }

                case CircleCollider circleA:
                    switch (second)
                    {
                        case RectangleCollider rectangleB:
                            return RectangleCircleUnrotatedCalculator.Intersects(circleA, rectangleB);
                        case CircleCollider circleB:
                            return CircleCircleUnrotatedCalculator.Intersects(circleA, circleB);
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
                case RectangleCollider rectangleA:
                    switch (second)
                    {
                        case RectangleCollider rectangleB:
                            return RectangleRectangleUnrotatedCalculator.CalculateOverlapOffset(
                                rectangleA,
                                rectangleB);
                        case CircleCollider circleB:
                            return RectangleCircleUnrotatedCalculator.CalculateOverlapOffset(
                                rectangleA,
                                circleB);
                        default:
                            throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
                    }

                case CircleCollider circleA:
                    switch (second)
                    {
                        case RectangleCollider rectangleB:
                            return RectangleCircleUnrotatedCalculator.CalculateOverlapOffset(
                                circleA,
                                rectangleB);
                        case CircleCollider circleB:
                            return CircleCircleUnrotatedCalculator.CalculateOverlapOffset(
                                circleA,
                                circleB);
                        default:
                            throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
                    }

                default:
                    throw new ArgumentOutOfRangeException("Invalid " + nameof(ICollider));
            }
        }
    }
}