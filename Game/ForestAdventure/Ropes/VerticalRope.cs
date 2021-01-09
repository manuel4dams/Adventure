using Framework.Collision.Collider;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Ropes
{
    public class VerticalRope : GameObject
    {
        public VerticalRope(Vector2 position, float height)
        {
            transform.position = position;

            var bounds = new RectangleBounds(0.1f, height);
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.Rope));
            AddComponent(new RectangleColliderComponent(this, bounds, true, true));
        }
    }
}