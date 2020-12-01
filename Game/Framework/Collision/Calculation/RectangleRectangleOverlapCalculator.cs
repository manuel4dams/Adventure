using Framework.Components;
using Framework.Objects;
using OpenTK;

namespace Framework.Collision.Calculation
{
    public static class RectangleRectangleOverlapCalculator
    {
        // TODO refactor remove additional newRectangleA
        // TODO calculation is still shit
        public static Vector2 CalculateUnrotatedOverlapOffset(
            RectangleCollider rectangleA,
            RectangleCollider rectangleB)
        {
            var newRectangleAGameObject = new GameObject
            {
                transform =
                {
                    position = rectangleA.gameObject.transform.position,
                    scale = rectangleA.gameObject.transform.scale,
                    rotation = rectangleA.gameObject.transform.rotation
                }
            };
            var newRectangleA = new RectangleCollider(newRectangleAGameObject, rectangleA.bounds);

            var newRectangleBGameObject = new GameObject
            {
                transform =
                {
                    position = rectangleB.gameObject.transform.position,
                    scale = rectangleB.gameObject.transform.scale,
                    rotation = rectangleB.gameObject.transform.rotation
                }
            };
            var newRectangleB = new RectangleCollider(newRectangleBGameObject, rectangleB.bounds);

            newRectangleA.UndoOverlapInternal(newRectangleB);
            return new Vector2(
                newRectangleA.gameObject.transform.position.X - rectangleA.gameObject.transform.position.X,
                newRectangleA.gameObject.transform.position.Y - rectangleA.gameObject.transform.position.Y);
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
                new Vector2(0, rectangleA.bounds.minY - rectangleB.bounds.maxY)
            };
            var pushDistSqrd = new float[4];
            for (var i = 0; i < 4; ++i) pushDistSqrd[i] = directions[i].LengthSquared;

            // find minimal positive overlap amount
            var minId = 0;
            for (var i = 1; i < 4; ++i) minId = pushDistSqrd[i] < pushDistSqrd[minId] ? i : minId;

            rectangleA.gameObject.transform.position += directions[minId];
        }
    }
}