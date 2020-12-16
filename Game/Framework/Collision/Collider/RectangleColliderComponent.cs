using Framework.Game;
using Framework.Interfaces;
using Framework.Shapes;

namespace Framework.Collision.Collider
{
    public class RectangleColliderComponent : ICollider
    {
        public RectangleBounds bounds;

        public bool isTrigger { get; set; }
        public bool isStatic { get; set; }

        public GameObject gameObject { get; }

        public RectangleColliderComponent(GameObject gameObject, RectangleBounds bounds)
            : this(gameObject, bounds, false)
        {
        }

        public RectangleColliderComponent(GameObject gameObject, RectangleBounds bounds, bool isTrigger)
            : this(gameObject, bounds, isTrigger, false)
        {
        }

        public RectangleColliderComponent(GameObject gameObject, RectangleBounds bounds, bool isTrigger, bool isStatic)
        {
            this.gameObject = gameObject;
            this.bounds = bounds;
            this.isTrigger = isTrigger;
            this.isStatic = isStatic;
        }
    }
}