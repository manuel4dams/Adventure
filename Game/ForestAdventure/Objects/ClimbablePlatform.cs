using Framework.Components;
using Framework.Development.Components;
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics;

namespace ForestAdventure.Objects
{
    public class ClimbablePlatform : GameObject
    {
        public ClimbablePlatform(Vector2 position, float length)
        {
            transform.position = position;
            var bounds = new RectangleBounds(length, 0.40f);
            AddComponent(new QuadRenderer(this, bounds, new Color4(170, 80, 10, 255)));
            AddComponent(new RectangleCollider(this, bounds, true, true));

#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
            AddComponent(new DebugColliderEdgesComponent(this, bounds));
#endif
        }
    }
}
