using System.Collections.Generic;
using ForestAdventure.Helper;
using ForestAdventure.Interfaces;

namespace ForestAdventure.Objects
{
    public class Platform : IGameObject
    {
        public List<IComponent> componentList { get; }

        public List<IComponent> ComponentList { get; }

        public Transform Tranform { get; }
    }
}