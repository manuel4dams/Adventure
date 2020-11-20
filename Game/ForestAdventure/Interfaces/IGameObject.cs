using System.Collections.Generic;
using ForestAdventure.Helper;

namespace ForestAdventure.Interfaces
{
    public interface IGameObject
    {
        public List<IComponent> ComponentList { get; }

        public Transform Transform { get; }

        public void Update()
        {
            // TODO check if component is updateable
            foreach (var component in ComponentList)
            {
                component.Update();
            }
        }

        public void Draw()
        {
            // TODO check if component is drawable
            foreach (var component in ComponentList)
            {
                component.Draw();
            }
        }
    }
}