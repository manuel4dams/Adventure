using System.Collections.Generic;

namespace ForestAdventure.Interfaces
{
    public interface IGameObject
    {
        public List<IComponent> ComponentList { get; }

        public void AddComponent(IComponent component)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveComponent(IComponent component)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            // TODO check if component is updateable
            foreach (var component in ComponentList)
            {
                if (component is IUpdateable)
                {
                    component.Update();
                }
                if (component is IMovable)
                {
                    component.Move();
                }
            }
        }

        public void Draw()
        {
            foreach (var component in ComponentList)
            {
                if (component is IDrawable)
                {
                    component.Draw();
                }
            }
        }
    }
}