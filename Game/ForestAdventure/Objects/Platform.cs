﻿using System.Collections.Generic;
using ForestAdventure.Components;
using ForestAdventure.Interfaces;

namespace ForestAdventure.Objects
{
    public class Platform : IGameObject
    {
        public Platform(float minX, float minY, float sizeX, float sizeY)
        {
            ComponentList.Add(new RectangleComponent(minX, minY, sizeX, sizeY));
        }

        public List<IComponent> ComponentList { get; } = new List<IComponent>();
    }
}