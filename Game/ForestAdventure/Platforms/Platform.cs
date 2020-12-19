using Framework.Collision.Collider;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Platforms
{
    public class Platform : GameObject
    {
        public Platform(Vector2 position, float length)
        {
            transform.position = position;

            var bounds = new RectangleBounds(length, 0.50f);
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.WoodenPlatform));
            AddComponent(new RectangleColliderComponent(this, bounds, false, true));
        }
    }
}