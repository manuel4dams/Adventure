using System.Collections.Generic;
using ForestAdventure.Components;
using ForestAdventure.Helper;
using ForestAdventure.Interfaces;

namespace ForestAdventure.Objects
{
    public class Enemy : IGameObject
    {
        public Enemy(
            float minX,
            float minY,
            float sizeX,
            float sizeY,
            float movementBorderLeft,
            float movementBorderRight)
        {
            GameObjectBounds gameObjectBounds = new GameObjectBounds(minX, minY, sizeX, sizeY);
            AddComponent(new CRectangle(gameObjectBounds));
            AddComponent(new CMovementNoInput(movementBorderLeft, movementBorderRight, gameObjectBounds));
        }

        public void AddComponent(IComponent component)
        {
            ComponentList.Add(component);
        }

        public List<IComponent> ComponentList { get; } = new List<IComponent>();
    }
}