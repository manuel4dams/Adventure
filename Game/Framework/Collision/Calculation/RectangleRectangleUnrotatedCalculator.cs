using System;
using System.Linq;
using Framework.Components;
using OpenTK;

namespace Framework.Collision.Calculation
{
    public static class RectangleRectangleUnrotatedCalculator
    {
        public static bool Intersects(RectangleCollider rectangleA, RectangleCollider rectangleB)
        {
            // TODO use bounds.UnrotatedTransform to also apply scaling
            return !(
                rectangleB.gameObject.transform.position.X + rectangleB.bounds.minX >
                rectangleA.gameObject.transform.position.X + rectangleA.bounds.maxX ||
                rectangleB.gameObject.transform.position.X + rectangleB.bounds.maxX <
                rectangleA.gameObject.transform.position.X + rectangleA.bounds.minX ||
                rectangleB.gameObject.transform.position.Y + rectangleB.bounds.maxY <
                rectangleA.gameObject.transform.position.Y + rectangleA.bounds.minY ||
                rectangleB.gameObject.transform.position.Y + rectangleB.bounds.minY >
                rectangleA.gameObject.transform.position.Y + rectangleA.bounds.maxY
            );
        }

        // TODO calculation is still shit
        public static Vector2 CalculateOverlapOffset(
            RectangleCollider rectangleA,
            RectangleCollider rectangleB)
        {
            var rectangleATransformed = rectangleA.bounds.UnrotatedTransform(rectangleA.gameObject.transform);
            var rectangleBTransformed = rectangleB.bounds.UnrotatedTransform(rectangleB.gameObject.transform);
            var directions = new[]
            {
                // push distance A in positive X-direction
                new Vector2(rectangleBTransformed.maxX - rectangleATransformed.minX, 0),

                // push distance A in negative X-direction
                new Vector2(rectangleBTransformed.minX - rectangleATransformed.maxX, 0),

                // push distance A in positive Y-direction
                new Vector2(0, rectangleBTransformed.maxY - rectangleATransformed.minY),

                // push distance A in negative Y-direction
                new Vector2(0, rectangleBTransformed.minY - rectangleATransformed.maxY),
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

            return directions[minId];
        }
    }
}