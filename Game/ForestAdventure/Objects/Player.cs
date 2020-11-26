using System;
using System.Collections.Generic;
using ForestAdventure.Components;
using ForestAdventure.Helper;
using ForestAdventure.Interfaces;

namespace ForestAdventure.Objects
{
    public class Player : IGameObject
    {
        public Player(float minX, float minY, float sizeX, float sizeY)
        {
            ObjectData objectData = new ObjectData(minX, minY, sizeX, sizeY);
            AddComponent(new CRectangle(objectData));
            AddComponent(new CPlayerMovement(objectData));
        }

        public List<IComponent> ComponentList { get; } = new List<IComponent>();

        public void AddComponent(IComponent component)
        {
            ComponentList.Add(component);
        }
    }
}