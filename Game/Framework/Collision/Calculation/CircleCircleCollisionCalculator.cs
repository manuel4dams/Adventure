using Framework.Components;

namespace Framework.Collision.Calculation
{
    public class CircleCircleCollisionCalculator
    {
        public static bool Intersects(CircleCollider circleA, CircleCollider circleB)
        {
            var rSum = circleB.radius + circleA.radius;
            var diff = (circleB.gameObject.transform.position + circleB.center) - (circleA.gameObject.transform.position + circleA.center);
            return rSum * rSum > diff.LengthSquared;
        }
    }
}