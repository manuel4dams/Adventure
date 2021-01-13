using Framework.Collision.Collider;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Level
{
    public class Exit : GameObject
    {
        public Exit(Vector2 position)
        {
            transform.position = position;

            var bounds = new RectangleBounds(2f, 3f);
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.Resources.Portal));
            AddComponent(new RectangleColliderComponent(this, bounds, true));
        }
    }
}