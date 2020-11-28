using Framework.Interfaces;
using Framework.Objects;
using OpenTK;

namespace Framework.Components
{
    public class CircleCollider : ICollider
    {
        public Vector2 center;
        public float radius;

        public GameObject gameObject { get; }
        public bool isTrigger { get; set; }

        public CircleCollider(GameObject gameObject, Vector2 center, float radius)
            : this(gameObject, center, radius, false)
        {
        }

        public CircleCollider(GameObject gameObject, Vector2 center, float radius, bool isTrigger)
        {
            this.gameObject = gameObject;
            this.center = center;
            this.radius = radius;
            this.isTrigger = isTrigger;
        }
    }
}