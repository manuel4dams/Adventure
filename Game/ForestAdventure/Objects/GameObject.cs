using System.Collections.Generic;
using ForestAdventure.Interfaces;

namespace ForestAdventure.Objects
{
    public class GameObject : IGameObject
    {
        public List<IComponent> ComponentList { get; }
        
        void AddComponent(IComponent component)
        {
            ComponentList.Add(component);
        }

        void RemoveComponent(IComponent component)
        {
            ComponentList.Remove(component);
        }

        void Update()
        {
            foreach (var component in ComponentList)
            {
                if (component is IUpdateable) ((IUpdateable) component).Update();
                if (component is IMovable) ((IMovable) component).Move();
                if (component is ICollidable) ((ICollidable) component).CheckCollision();
            }
        }

        void Draw()
        {
            foreach (var component in ComponentList)
            {
                if (component is IDrawable)
                    ((IDrawable) component).Draw();
            }
        }
    }
}