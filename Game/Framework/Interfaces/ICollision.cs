using OpenTK;

namespace Framework.Interfaces
{
    public interface ICollision
    {
        void OnCollision(ICollider other, Vector2 touchOffset);
    }
}