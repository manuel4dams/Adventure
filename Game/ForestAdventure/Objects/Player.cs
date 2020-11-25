using System.Collections.Generic;
using ForestAdventure.Components;
using ForestAdventure.Interfaces;

namespace ForestAdventure.Objects
{
    public class Player : IGameObject
    {
        public Player(float minX, float minY, float sizeX, float sizeY)
        {
            AddComponent(new CRectangle(minX, minY, sizeX, sizeY));
            AddComponent(new CPlayerMovement(this));
        }

        public void AddComponent(IComponent component)
        {
            ComponentList.Add(component);
        }

        public List<IComponent> ComponentList { get; } = new List<IComponent>();
    }
}