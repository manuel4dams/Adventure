using Framework.Interfaces;
using Framework.Objects;

namespace Framework.Components
{
    public class RectangleCollider : ICollider
    {
        public Bounds bounds;

        public bool isTrigger { get; set; }

        public GameObject gameObject { get; }

        public RectangleCollider(GameObject gameObject, Bounds bounds)
            : this(gameObject, bounds, false)
        {
        }

        public RectangleCollider(GameObject gameObject, Bounds bounds, bool isTrigger)
        {
            this.gameObject = gameObject;
            this.bounds = bounds;
            this.isTrigger = isTrigger;
        }
    }
}