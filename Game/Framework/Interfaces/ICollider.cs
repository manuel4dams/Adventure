namespace Framework.Interfaces
{
    public interface ICollider : IComponent
    {
        bool isTrigger { get; }
        bool isStatic { get; }
    }
}