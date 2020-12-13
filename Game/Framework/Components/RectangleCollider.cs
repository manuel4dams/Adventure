using Framework.Interfaces;
using Framework.Objects;

namespace Framework.Components
{
    public class RectangleCollider : ICollider
    {
        public RectangleBounds bounds;

        public bool isTrigger { get; set; }
        public bool isStatic { get; set; }

        public GameObject gameObject { get; }

        public RectangleCollider(GameObject gameObject, RectangleBounds bounds)
            : this(gameObject, bounds, false)
        {
        }

        public RectangleCollider(GameObject gameObject, RectangleBounds bounds, bool isTrigger)
            : this(gameObject, bounds, isTrigger, false)
        {
        }

        public RectangleCollider(GameObject gameObject, RectangleBounds bounds, bool isTrigger, bool isStatic)
        {
            this.gameObject = gameObject;
            this.bounds = bounds;
            this.isTrigger = isTrigger;
            this.isStatic = isStatic;
        }
    }
}