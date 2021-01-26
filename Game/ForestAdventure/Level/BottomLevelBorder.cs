using Framework.Collision.Collider;
using Framework.Development.Components;
using Framework.Game;
using Framework.Shapes;
using Framework.Util;
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
            if (Debug.enabled)
            {
                AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bounds));
            }
        }
    }
}