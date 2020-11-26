﻿using System;
using System.Collections.Generic;

namespace ForestAdventure.Interfaces
{
    public interface IGameObject
    {
        List<IComponent> ComponentList { get; }

        void AddComponent(IComponent component)
        {
            throw new NotImplementedException();
        }

        void RemoveComponent(IComponent component)
        {
            throw new NotImplementedException();
        }

        void Update()
        {
            foreach (var component in ComponentList)
            {
                if (component is IUpdateable) ((IUpdateable) component).Update();
                if (component is IMovable) ((IMovable) component).Move();
                if (component is ICollidable) ((ICollidable) component).CheckCollision();
            }
        }

        void Draw()
        {
            foreach (var component in ComponentList)
            {
                if (component is IDrawable)
                    ((IDrawable) component).Draw();
            }
        }
    }
}