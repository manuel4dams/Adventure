using System.Collections.Generic;
using ForestAdventure.Components;
using ForestAdventure.Helper;
using ForestAdventure.Interfaces;

namespace ForestAdventure.Objects
{
    public class Player : GameObject
    {
        public Player(float minX, float minY, float sizeX, float sizeY)
        {
            Bounds bounds = new Bounds(minX, minY, sizeX, sizeY);
            AddComponent(new RectangleComponent(bounds));
            AddComponent(new PlayerMovementComponent(bounds));
        }
    }
}