namespace Framework.Interfaces
{
    public interface ICollider : IComponent
    {
        bool isTrigger { get; }
    }
}