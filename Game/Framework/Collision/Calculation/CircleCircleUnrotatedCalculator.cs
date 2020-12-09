using System;
using Framework.Components;
using OpenTK;

namespace Framework.Collision.Calculation
{
    // TODO test calculation für correctness
    public static class CircleCircleUnrotatedCalculator
    {
        public static bool Intersects(CircleCollider circleA, CircleCollider circleB)
        {
            throw new NotImplementedException();
            var rSum = circleB.radius + circleA.radius;
            var diff = circleB.gameObject.transform.position + circleB.center -
                       (circleA.gameObject.transform.position + circleA.center);
            return rSum * rSum > diff.LengthSquared;
        }

        public static Vector2 CalculateOverlapOffset(CircleCollider first, CircleCollider second)
        {
            throw new NotImplementedException();
            var newFirst = new CircleCollider(first.gameObject, first.center, first.radius);
            newFirst.UndoOverlapInternal(second);
            return new Vector2(newFirst.center.X - first.center.X, newFirst.center.Y - first.center.Y);
        }

        private static void UndoOverlapInternal(this CircleCollider circleA, CircleCollider circleB)
        {
            throw new NotImplementedException();
            // TODO maybe add positions?
            var cB = new Vector2(circleB.center.X, circleB.center.Y);
            var diff = new Vector2(circleA.center.X, circleA.center.Y);
            diff -= cB;
            diff /= diff.Length;
            diff *= circleA.radius + circleB.radius;
            var newA = cB + diff;
            circleA.center.X = newA.X;
            circleA.center.Y = newA.Y;
        }
    }
}