using Framework.Components;
using OpenTK;

namespace Framework.Collision.Calculation
{
    public static class RectangleCircleCollisionCalculator
    {
        // see https://stackoverflow.com/a/1879223
        public static bool UnrotatedIntersects(CircleCollider circle, RectangleCollider rectangle)
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
            var distanceSquared = distanceX * distanceX + distanceY * distanceY;
            return distanceSquared < circle.radius * circle.radius;
        }
    }
}