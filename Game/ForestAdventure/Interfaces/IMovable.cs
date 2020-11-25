namespace ForestAdventure.Interfaces
{
    public interface IMovable : IComponent
    {
        void Move()
        {
            // throw no exception from base interface, because this method should be callable
        }
    }
}