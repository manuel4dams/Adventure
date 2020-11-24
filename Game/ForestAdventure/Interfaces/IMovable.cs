namespace ForestAdventure.Interfaces
{
    public interface IMovable : IComponent
    {
        void IComponent.Move()
        {
            // throw no exception from base interface, because this method should be callable
        }
    }
}