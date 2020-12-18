using Framework.Collision.Collider;
using Framework.Development.Components;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;
using OpenTK.Graphics;

namespace ForestAdventure.Ropes
{
    public class HorizontalRope : GameObject
    {
        // TODO should player be able to jump from climbing?
        // TODO if climbing player should clipp to fixed position in platform
        public HorizontalRope(Vector2 position, float length)
        {
            transform.position = position;

            var bounds = new RectangleBounds(length, 0.40f);
            AddComponent(new QuadRenderer(this, bounds, new Color4(170, 80, 10, 255)));
            AddComponent(new RectangleColliderComponent(this, bounds, true, true));

#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
            AddComponent(new DebugColliderEdgesComponent(this, bounds));
#endif
        }
    }
}