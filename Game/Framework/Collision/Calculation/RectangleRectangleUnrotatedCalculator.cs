using Framework.Components;
using Framework.Objects;
using OpenTK;

namespace Framework.Collision.Calculation
{
    public static class RectangleRectangleUnrotatedCalculator
    {
        public static bool Intersects(
            RectangleBounds rectangleBoundsA,
            Transform transformA,
            RectangleBounds rectangleBoundsB,
            Transform transformB)
        {
            return !(
                rectangleBoundsB.UnrotatedTransform(transformB).center.X +
                rectangleBoundsB.minX >
                rectangleBoundsA.UnrotatedTransform(transformA).center.X +
                rectangleBoundsA.maxX ||
                rectangleBoundsB.UnrotatedTransform(transformB).center.X +
                rectangleBoundsB.maxX <
                rectangleBoundsA.UnrotatedTransform(transformA).center.X +
                rectangleBoundsA.minX ||
                rectangleBoundsB.UnrotatedTransform(transformB).center.Y +
                rectangleBoundsB.maxY <
                rectangleBoundsA.UnrotatedTransform(transformA).center.Y +
                rectangleBoundsA.minY ||
                rectangleBoundsB.UnrotatedTransform(transformB).center.Y +
                rectangleBoundsB.minY >
                rectangleBoundsA.UnrotatedTransform(transformA).center.Y +
                rectangleBoundsA.maxY
            );
        }

        public static Vector2 CalculateOverlapOffset(
            RectangleBounds rectangleBoundsA,
            Transform transformA,
            RectangleBounds rectangleBoundsB,
            Transform transformB)
        {
            var rectangleATransformed = rectangleBoundsA.UnrotatedTransform(transformA);
            var rectangleBTransformed = rectangleBoundsB.UnrotatedTransform(transformB);
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