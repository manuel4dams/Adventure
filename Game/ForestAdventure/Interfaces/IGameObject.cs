using System.Collections.Generic;
using ForestAdventure.Helper;

namespace ForestAdventure.Interfaces
{
    public interface IGameObject
    {
        public List<IComponent> ComponentList { get; }
        public Transform Tranform { get; }

        public void addComponent(IComponent component)
        {
            ComponentList.Add(component);
        }

        public void removeComponent(IComponent component)
        {
            ComponentList.Remove(component);
        }

        public void Updateable()
        {
        }

        public void Drawable()
        {
        }
    }
}