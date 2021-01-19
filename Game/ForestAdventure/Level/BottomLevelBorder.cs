using Framework.Collision.Collider;
using Framework.Game;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Level
{
    public class BottomLevelBorder : GameObject
    {
        public BottomLevelBorder(Vector2 position, float length)
        {
            transform.position = position;

            var bounds = new RectangleBounds(length, 1f);
            AddComponent(new RectangleColliderComponent(this, bounds, false, true));
#if DEBUG
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bounds));
#endif
        }
    }
}