using System;
using Framework.Components;
using OpenTK;

namespace Framework.Collision.Calculation
{
    // TODO test calculation für correctness
    public static class RectangleCircleOverlapCalculator
    {
        // see BoxCircleCollisionCalculator
        // see https://stackoverflow.com/a/1879223
        public static Vector2 UnrotatedOverlap(CircleCollider circle, RectangleCollider rectangle)
        {
            // Find the closest point to the circle within the rectangle
            var closestX = MathHelper.Clamp(
                circle.gameObject.transform.position.X + circle.center.X,
                rectangle.gameObject.transform.position.X + rectangle.bounds.minX,
                rectangle.gameObject.transform.position.X + rectangle.bounds.maxX
            );
            var closestY = MathHelper.Clamp(
                circle.gameObject.transform.position.Y + circle.center.Y,
                rectangle.gameObject.transform.position.Y + rectangle.bounds.minY,
                rectangle.gameObject.transform.position.Y + rectangle.bounds.maxY
            );

            // Calculate the distance between the circle's center and this closest point
            var distanceX = circle.gameObject.transform.position.X + circle.center.X - closestX;
            var distanceY = circle.gameObject.transform.position.Y + circle.center.Y - closestY;

            // If the distance is less than the circle's radius, an intersection occurs
            var distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
            var distanceToMove = circle.radius - distance;
            if (distanceToMove > 0)
            {
                var distanceAngle = Math.Atan2(distanceY, distanceX);
                var distanceToMoveX = distanceToMove * Math.Cos(distanceAngle);
                var distanceToMoveY = distanceToMove * Math.Sin(distanceAngle);
                return new Vector2((float) distanceToMoveX, (float) distanceToMoveY);
            }

            return Vector2.Zero;
        }

        public static Vector2 UnrotatedOverlap(RectangleCollider rectangle, CircleCollider circle)
        {
            return -UnrotatedOverlap(circle, rectangle);
        }
    }
}