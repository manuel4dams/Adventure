using Framework.Interfaces;
using Framework.Objects;

namespace Framework.Components
{
    public class RectangleCollider : ICollider
    {
<<<<<<< HEAD
        public RectangleBounds bounds;

        public bool isTrigger { get; set; }
        public bool isStatic { get; set; }

        public GameObject gameObject { get; }

        public RectangleCollider(GameObject gameObject, RectangleBounds bounds)
=======
        public Bounds bounds;

        public RectangleCollider(GameObject gameObject, Bounds bounds)
>>>>>>> master
            : this(gameObject, bounds, false)
        {
        }

<<<<<<< HEAD
        public RectangleCollider(GameObject gameObject, RectangleBounds bounds, bool isTrigger)
=======
        public RectangleCollider(GameObject gameObject, Bounds bounds, bool isTrigger)
>>>>>>> master
            : this(gameObject, bounds, isTrigger, false)
        {
        }

<<<<<<< HEAD
        public RectangleCollider(GameObject gameObject, RectangleBounds bounds, bool isTrigger, bool isStatic)
=======
        public RectangleCollider(GameObject gameObject, Bounds bounds, bool isTrigger, bool isStatic)
>>>>>>> master
        {
            this.gameObject = gameObject;
            this.bounds = bounds;
            this.isTrigger = isTrigger;
            this.isStatic = isStatic;
        }
<<<<<<< HEAD
=======

        public bool isTrigger { get; set; }

        public bool isStatic { get; set; }

        public GameObject gameObject { get; }
>>>>>>> master
    }
}