using System.Collections.Generic;
using System.Linq;
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

        // TODO change method to get specific component, this solution is ugly!!!
        public IComponent GetComponent<T>(int index)
        {
            return components.Where(c => c.GetType() == typeof(T)).ToList()[index];
        }
    }
}