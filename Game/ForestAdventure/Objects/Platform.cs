using System.Collections.Generic;
using ForestAdventure.Components;
using ForestAdventure.Helper;
using ForestAdventure.Interfaces;

namespace ForestAdventure.Objects
{
    public class Platform : IGameObject
    {
        public Platform(float minX, float minY, float sizeX, float sizeY)
        {
            GameObjectBounds gameObjectBounds = new GameObjectBounds(minX, minY, sizeX, sizeY);
            AddComponent(new CRectangle(gameObjectBounds));
        }

        public List<IComponent> ComponentList { get; } = new List<IComponent>();

        public void AddComponent(IComponent component)
        {
            ComponentList.Add(component);
        }
    }
}