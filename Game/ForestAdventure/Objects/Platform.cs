using Framework.Components;
using Framework.Development.Components;
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics;

namespace ForestAdventure.Objects
{
    public class Platform : GameObject
    {
        public Platform(Vector2 position, float length)
        {
            transform.position = position;
            var bounds = new RectangleBounds(length, 0.40f);
            AddComponent(new QuadRenderer(this, bounds, new Color4(77, 39, 3, 255)));
            AddComponent(new RectangleCollider(this, bounds, false, true));

#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bounds));
#endif
        }
    }
}