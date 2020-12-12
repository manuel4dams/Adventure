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
            return !(
                rectangleB.bounds.UnrotatedTransform(rectangleB.gameObject.transform).center.X +
                rectangleB.bounds.minX >
                rectangleA.bounds.UnrotatedTransform(rectangleA.gameObject.transform).center.X +
                rectangleA.bounds.maxX ||
                rectangleB.bounds.UnrotatedTransform(rectangleB.gameObject.transform).center.X +
                rectangleB.bounds.maxX <
                rectangleA.bounds.UnrotatedTransform(rectangleA.gameObject.transform).center.X +
                rectangleA.bounds.minX ||
                rectangleB.bounds.UnrotatedTransform(rectangleB.gameObject.transform).center.Y +
                rectangleB.bounds.maxY <
                rectangleA.bounds.UnrotatedTransform(rectangleA.gameObject.transform).center.Y +
                rectangleA.bounds.minY ||
                rectangleB.bounds.UnrotatedTransform(rectangleB.gameObject.transform).center.Y +
                rectangleB.bounds.minY >
                rectangleA.bounds.UnrotatedTransform(rectangleA.gameObject.transform).center.Y +
                rectangleA.bounds.maxY
            );
        }

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