using System.Collections.Generic;
using Framework.Interfaces;

namespace Framework.Objects
{
    public class GameObject
    {
        public readonly List<IComponent> components = new List<IComponent>();
        public readonly Transform transform;

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
    }
}