namespace ForestAdventure.Interfaces
{
    public interface ICollidable : IComponent
    {
        void CheckCollision()
        {
            // throw no exception from base interface, because this method should be callable
        }
    }
}