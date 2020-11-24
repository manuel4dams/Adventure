using System;

namespace ForestAdventure.Interfaces
{
    public interface IUpdateable : IComponent
    {
        void IComponent.Update()
        {
            // throw no exception from base interface, because this method should be callable
        }
    }
}