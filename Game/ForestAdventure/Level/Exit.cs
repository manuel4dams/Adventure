using Framework.Collision.Collider;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Level
{
    public class Exit : GameObject
    {
        public Exit()
        {
            transform.position = new Vector2(65f, 97.8f);

            var bounds = new RectangleBounds(2f, 3f);
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.Portal));
            AddComponent(new RectangleColliderComponent(this, bounds, true));
        }
    }
}