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
                            return RectangleRectangleCollisionCalculator.UnrotatedIntersects(firstRectangle,
                                secondRectangle);
                        case CircleCollider secondCircle:
                            return RectangleCircleCollisionCalculator.UnrotatedIntersects(secondCircle, firstRectangle);
                    }

                    break;
                case CircleCollider firstCircle:
                    switch (second)
                    {
                        case RectangleCollider secondRectangle:
                            return RectangleCircleCollisionCalculator.UnrotatedIntersects(firstCircle, secondRectangle);
                        case CircleCollider secondCircle:
                            return CircleCircleCollisionCalculator.Intersects(firstCircle, secondCircle);
                    }

                    break;
            }

            throw new ArgumentException("Collision between " + first.GetType().Name + " and " +
                                        second.GetType().Name + " not implemented yet!");
        }

        public static Vector2 UnrotatedOverlap(ICollider first, ICollider second)
        {
            switch (first)
            {
                case RectangleCollider firstRectangle:
                    switch (second)
                    {
                        case RectangleCollider secondRectangle:
                            return RectangleRectangleOverlapCalculator.UnrotatedOverlap(firstRectangle,
                                secondRectangle);
                        case CircleCollider secondCircle:
                            return RectangleCircleOverlapCalculator.UnrotatedOverlap(firstRectangle, secondCircle);
                    }

                    break;
                case CircleCollider firstCircle:
                    switch (second)
                    {
                        case RectangleCollider secondRectangle:
                            return RectangleCircleOverlapCalculator.UnrotatedOverlap(firstCircle, secondRectangle);
                        case CircleCollider secondCircle:
                            return CircleCircleOverlapCalculator.UnrotatedOverlap(firstCircle, secondCircle);
                    }

                    break;
            }

            throw new ArgumentException("UndoOverlap between " + first.GetType().Name + " and " +
                                        second.GetType().Name + " not implemented yet!");
        }
    }
}