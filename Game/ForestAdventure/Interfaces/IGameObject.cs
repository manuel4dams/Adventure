using System.Collections.Generic;

namespace ForestAdventure.Interfaces
{
    public interface IGameObject
    {
        public List<IComponent> ComponentList { get; }

        public void AddComponent(IComponent component)
        {
            ComponentList.Add(component);
        }

        public void RemoveComponent(IComponent component)
        {
            ComponentList.Remove(component);
        }

        public void Update()
        {
            // TODO check if component is updateable
            foreach (var component in ComponentList) component.Update();
        }

        public void Draw()
        {
            // TODO check if component is drawable
            foreach (var component in ComponentList) component.Draw();
        }
    }
}