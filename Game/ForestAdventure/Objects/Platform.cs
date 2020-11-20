using System.Collections.Generic;
using ForestAdventure.Components;
using ForestAdventure.Helper;
using ForestAdventure.Interfaces;

namespace ForestAdventure.Objects
{
    public class Platform : IGameObject
    {
        private readonly List<IComponent> componentList = new List<IComponent>();

        public Transform Transform { get; }

        public Platform()
        {
            ComponentList.Add(new RectangleComponent(1, 1, 1, 1));
        }

        public List<IComponent> ComponentList => componentList;
    }
}