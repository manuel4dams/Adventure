using System.Collections.Generic;
using Framework.Interfaces;

namespace Framework.Objects
{
    public class GameObject
    {
        private readonly List<IComponent> componentList = new List<IComponent>();
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
            componentList.Add(component);
        }

        public void RemoveComponent(IComponent component)
        {
            componentList.Remove(component);
        }

        public void Update(float deltaTime)
        {
            foreach (var component in componentList)
            {
                if (component is IUpdateable) ((IUpdateable) component).Update(deltaTime);
                if (component is ICollidable) ((ICollidable) component).CheckCollision();
            }
        }

        public void Draw()
        {
            foreach (var component in componentList)
            {
                if (component is IDrawable)
                    ((IDrawable) component).Draw();
            }
        }
    }
}