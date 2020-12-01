using System.Collections.Generic;
using Framework.Interfaces;

namespace Framework.Objects
{
    public abstract class GameObject
    {
        public readonly Transform transform;
        public readonly List<IComponent> components = new List<IComponent>();

        public GameObject()
            : this(new Transform())
        {
        }

        public GameObject(Transform transform)
        {
            this.transform = transform;
        }

        public void AddComponent(IComponent component)
        {
            components.Add(component);
        }

        public void RemoveComponent(IComponent component)
        {
            components.Remove(component);
        }

        public virtual void OnCollision(ICollider other)
        {
        }
    }
}