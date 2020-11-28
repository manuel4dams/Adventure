using Framework.Interfaces;
using Framework.Objects;

namespace Framework.Components
{
    public class RectangleCollider : ICollider
    {
        public Bounds bounds;

        public GameObject gameObject { get; }

        public RectangleCollider(GameObject gameObject, Bounds bounds)
        {
            this.gameObject = gameObject;
            this.bounds = bounds;
        }

        public bool isTrigger { get; }
    }
}