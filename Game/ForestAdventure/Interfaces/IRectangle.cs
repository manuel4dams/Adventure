namespace ForestAdventure.Interfaces
{
    public interface IRectangle : IComponent
    {
        float MaxX { get; }

        float MaxY { get; }

        float MinX { get; }

        float MinY { get; }
    }
}