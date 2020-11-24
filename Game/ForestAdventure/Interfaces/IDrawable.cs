namespace ForestAdventure.Interfaces
{
    public interface IDrawable : IComponent
    {
        void IComponent.Draw()
        {
            // throw no exception from base interface, because this method should be callable
        }
    }
}