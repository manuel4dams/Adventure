namespace ForestAdventure.Interfaces
{
    public interface ICollidable : IComponent
    {
        void IComponent.CheckCollision()
        {
            // throw no exception from base interface, because this method should be callable
        }
    }
}