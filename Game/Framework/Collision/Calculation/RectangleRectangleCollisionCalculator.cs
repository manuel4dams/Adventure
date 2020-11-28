using Framework.Components;

namespace Framework.Collision.Calculation
{
    public static class RectangleRectangleCollisionCalculator
    {
        public static bool UnrotatedIntersects(RectangleCollider first, RectangleCollider second)
        {
            return first.UnrotatedIntersectsInternal(second);
        }

        private static bool UnrotatedIntersectsInternal(this RectangleCollider a, RectangleCollider b)
        {
            // bool noXintersect = (bounds.maxX <= obj.MinX) || (bounds.minX >= obj.MaxX);
            // bool noYintersect = (bounds.maxY <= obj.MinY) || (bounds.minY >= obj.MaxY);
            // return !(noXintersect || noYintersect);
            return !(
                b.gameObject.transform.position.X + b.bounds.minX > b.gameObject.transform.position.X + a.bounds.maxX ||
                b.gameObject.transform.position.X + b.bounds.maxX < b.gameObject.transform.position.X + a.bounds.minX ||
                b.gameObject.transform.position.Y + b.bounds.maxY < b.gameObject.transform.position.Y + a.bounds.minY ||
                b.gameObject.transform.position.Y + b.bounds.minY > b.gameObject.transform.position.Y + a.bounds.maxY
            );
        }
    }
}