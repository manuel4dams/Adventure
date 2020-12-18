using Framework.Game;
using Framework.Interfaces;

namespace Framework.References
{
    public static class GameReferences
    {
        public static ICollision GameObjectAsICollision(GameObject gameObject)
        {
            return gameObject as ICollision;
        }

        public static ICollision ComponentAsICollision(IComponent component)
        {
            return component as ICollision;
        }
    }
}