namespace Framework.Interfaces
{
    public interface IUpdateable : IComponent
    {
        void Update(float deltaTime);
    }
}