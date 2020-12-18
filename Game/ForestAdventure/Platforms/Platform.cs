using Framework.Collision.Collider;
using Framework.Development.Components;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;
using OpenTK.Graphics;

namespace ForestAdventure.Platforms
{
    public class Platform : GameObject
    {
        public Platform(Vector2 position, float length)
        {
            transform.position = position;

            var bounds = new RectangleBounds(length, 0.50f);
            AddComponent(new QuadRenderer(this, bounds, new Color4(77, 39, 3, 255)));
            AddComponent(new RectangleColliderComponent(this, bounds, false, true));

#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bounds));
#endif
        }
    }
}