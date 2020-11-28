namespace Framework.Interfaces
{
    public interface ICollidable : IComponent
    {
        bool CheckCollision();
    }
}