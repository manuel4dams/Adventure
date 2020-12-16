using System.Collections.Generic;
using Framework.Interfaces;

namespace Framework.Game
{
    public class GameObject
    {
        public readonly List<IComponent> components = new List<IComponent>();
        public readonly Transform.Transform transform;

        public GameObject()
        {
            transform = new Transform.Transform();
        }

        public GameObject(Transform.Transform transform)
            : this()
        {
            this.transform.Apply(transform);
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