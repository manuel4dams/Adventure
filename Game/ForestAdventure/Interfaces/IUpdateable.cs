namespace ForestAdventure.Interfaces
{
    public interface IUpdateable : IComponent
    {
        void Update()
        {
            // throw no exception from base interface, because this method should be callable
        }
    }
}