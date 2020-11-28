using Framework.Components;
using OpenTK;

namespace Framework.Collision.Calculation
{
    public static class RectangleRectangleOverlapCalculator
    {
        public static Vector2 UnrotatedOverlap(RectangleCollider first, RectangleCollider second)
        {
            var newFirst = new RectangleCollider(first.gameObject, first.bounds);
            newFirst.UndoOverlapInternal(second);
            return new Vector2(newFirst.bounds.minX - first.bounds.minX, newFirst.bounds.minY - first.bounds.minY);
        }

        private static void UndoOverlapInternal(this RectangleCollider rectangleA, RectangleCollider rectangleB)
        {
            if (!RectangleRectangleCollisionCalculator.UnrotatedIntersects(rectangleA, rectangleB))
                return;

            var directions = new[]
            {
                // push distance A in positive X-direction
                new Vector2(rectangleB.bounds.maxX - rectangleA.bounds.minX, 0),

                // push distance A in negative X-direction
                new Vector2(rectangleB.bounds.minX - rectangleA.bounds.maxX, 0),

                // push distance A in positive Y-direction
                new Vector2(0, rectangleB.bounds.maxY - rectangleA.bounds.minY),

                // push distance A in negative Y-direction
                new Vector2(0, rectangleB.bounds.minY - rectangleA.bounds.maxY),
            };
            var pushDistSqrd = new float[4];
            for (var i = 0; i < 4; ++i)
            {
                pushDistSqrd[i] = directions[i].LengthSquared;
            }

            // find minimal positive overlap amount
            var minId = 0;
            for (var i = 1; i < 4; ++i)
            {
                minId = pushDistSqrd[i] < pushDistSqrd[minId] ? i : minId;
            }

            rectangleA.bounds.minX += directions[minId].X;
            rectangleA.bounds.minY += directions[minId].Y;
        }
    }
}