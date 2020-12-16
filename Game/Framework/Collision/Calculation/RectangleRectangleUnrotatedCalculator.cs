using Framework.Shapes;
using OpenTK;

namespace Framework.Collision.Calculation
{
    public static class RectangleRectangleUnrotatedCalculator
    {
        public static bool Intersects(
            RectangleBounds rectangleBoundsA,
            Transform.Transform transformA,
            RectangleBounds rectangleBoundsB,
            Transform.Transform transformB)
        {
            var transformedRectangleBoundsA = rectangleBoundsA.UnrotatedTransform(transformA);
            var transformedRectangleBoundsB = rectangleBoundsB.UnrotatedTransform(transformB);
            return !(
                transformedRectangleBoundsB.minX >
                transformedRectangleBoundsA.maxX ||
                transformedRectangleBoundsB.maxX <
                transformedRectangleBoundsA.minX ||
                transformedRectangleBoundsB.maxY <
                transformedRectangleBoundsA.minY ||
                transformedRectangleBoundsB.minY >
                transformedRectangleBoundsA.maxY);
        }

        public static Vector2 CalculateOverlapOffset(
            RectangleBounds rectangleBoundsA,
            Transform.Transform transformA,
            RectangleBounds rectangleBoundsB,
            Transform.Transform transformB)
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