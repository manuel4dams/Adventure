using Framework.Components;
using OpenTK;

namespace Framework.Collision.Calculation
{
    public static class RectangleRectangleOverlapCalculator
    {
        public static Vector2 UnrotatedOverlap(RectangleCollider rectangleA, RectangleCollider rectangleB)
        {
            var newRectangleA = new RectangleCollider(rectangleA.gameObject, rectangleA.bounds);
            newRectangleA.UndoOverlapInternal(rectangleB);
            return new Vector2(newRectangleA.bounds.minX - rectangleA.bounds.minX,
                newRectangleA.bounds.minY - rectangleA.bounds.minY);
        }

        private static void UndoOverlapInternal(this RectangleCollider rectangleA, RectangleCollider rectangleB)
        {
            if (!RectangleRectangleCollisionCalculator.UnrotatedIntersects(rectangleA, rectangleB))
                return;

            var directions = new[]
            {
                // push distance A in positive X-direction
                new Vector2(rectangleA.bounds.maxX - rectangleB.bounds.minX, 0),

                // push distance A in negative X-direction
                new Vector2(rectangleA.bounds.minX - rectangleB.bounds.maxX, 0),

                // push distance A in positive Y-direction
                new Vector2(0, rectangleA.bounds.maxY - rectangleB.bounds.minY),

                // push distance A in negative Y-direction
                new Vector2(0, rectangleA.bounds.minY - rectangleB.bounds.maxY),
            };
            var pushDistSqrd = new float[4];
            for (int i = 0; i < 4; ++i)
            {
                pushDistSqrd[i] = directions[i].LengthSquared;
            }

            // find minimal positive overlap amount
            var minId = 0;
            for (var i = 1; i < 4; ++i)
            {
                minId = pushDistSqrd[i] < pushDistSqrd[minId] ? i : minId;
            }

            // TODO which object should move in which direction?
            rectangleB.bounds.minX += directions[minId].X * 0.1f;
            rectangleB.bounds.minY += directions[minId].Y * 0.1f;
            // rectangleB.gameObject.transform.position += directions[minId] * new Vector2(0.1f, 0.1f);
        }
    }
}