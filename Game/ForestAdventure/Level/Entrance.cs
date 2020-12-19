using Framework.Collision.Collider;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Level
{
    public class Entrance : GameObject
    {
        public Entrance()
        {
            transform.position = new Vector2(-1f, 1.8f);

            var bounds = new RectangleBounds(2f, 3f);
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.WoodenDoor));
            AddComponent(new RectangleColliderComponent(this, bounds, true));
        }
    }
}