using Framework.Interfaces;
using Framework.Objects;

namespace Framework.Components
{
    public class CollisionComponent : ICollidable
    {
        public CollisionComponent(GameObject gameObject, Bounds bounds)
        {
            this.gameObject = gameObject;
            this.bounds = bounds;
        }

        public GameObject gameObject { get; }
        private readonly Bounds bounds;

        public bool CheckCollision()
        {
            // bool noXintersect = (bounds.maxX <= obj.MinX) || (bounds.minX >= obj.MaxX);
            // bool noYintersect = (bounds.maxY <= obj.MinY) || (bounds.minY >= obj.MaxY);
            // return !(noXintersect || noYintersect);
            return true;
        }
    }
}