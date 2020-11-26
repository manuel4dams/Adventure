using System.Collections.Generic;
using ForestAdventure.Helper;
using ForestAdventure.Interfaces;

namespace ForestAdventure.Objects
{
    public class GameObject
    {
        private readonly List<IComponent> componentList = new List<IComponent>();
        private readonly Transform transform;

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

        public void Update()
        {
            foreach (var component in componentList)
            {
                if (component is IUpdateable) ((IUpdateable) component).Update();
                if (component is IMovable) ((IMovable) component).Move();
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