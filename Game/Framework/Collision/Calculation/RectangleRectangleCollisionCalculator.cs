using Framework.Components;

namespace Framework.Collision.Calculation
{
    // TODO test calculation für correctness
    public static class RectangleRectangleCollisionCalculator
    {
        public static bool UnrotatedIntersects(RectangleCollider first, RectangleCollider second)
        {
            return first.UnrotatedIntersectsInternal(second);
        }

        private static bool UnrotatedIntersectsInternal(this RectangleCollider a, RectangleCollider b)
        {
            return !(
                b.gameObject.transform.position.X + b.bounds.minX > a.gameObject.transform.position.X + a.bounds.maxX ||
                b.gameObject.transform.position.X + b.bounds.maxX < a.gameObject.transform.position.X + a.bounds.minX ||
                b.gameObject.transform.position.Y + b.bounds.maxY < a.gameObject.transform.position.Y + a.bounds.minY ||
                b.gameObject.transform.position.Y + b.bounds.minY > a.gameObject.transform.position.Y + a.bounds.maxY
            );
        }
    }
}