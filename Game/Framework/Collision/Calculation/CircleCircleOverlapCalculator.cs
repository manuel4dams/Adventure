using Framework.Components;
using OpenTK;

namespace Framework.Collision.Calculation
{
    // TODO test calculation für correctness
    public static class CircleCircleOverlapCalculator
    {
        public static Vector2 CalculateUnrotatedOverlapOffset(CircleCollider first, CircleCollider second)
        {
            var newFirst = new CircleCollider(first.gameObject, first.center, first.radius);
            newFirst.UndoOverlapInternal(second);
            return new Vector2(newFirst.center.X - first.center.X, newFirst.center.Y - first.center.Y);
        }

        private static void UndoOverlapInternal(this CircleCollider circleA, CircleCollider circleB)
        {
            // TODO maybe add positions?
            Vector2 cB = new Vector2(circleB.center.X, circleB.center.Y);
            Vector2 diff = new Vector2(circleA.center.X, circleA.center.Y);
            diff -= cB;
            diff /= diff.Length;
            diff *= circleA.radius + circleB.radius;
            var newA = cB + diff;
            circleA.center.X = newA.X;
            circleA.center.Y = newA.Y;
        }
    }
}