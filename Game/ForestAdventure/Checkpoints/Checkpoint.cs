using System.Drawing;
using Framework.Collision.Collider;
using Framework.Development.Components;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Checkpoints
{
    public class Checkpoint : GameObject
    {
        public Checkpoint(Vector2 position)
        {
            transform.position = position;

            var bounds = new RectangleBounds(2f, 2f);
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.Resources.Checkpoint));
            AddComponent(new RectangleColliderComponent(this, bounds, true));
#if DEBUG
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bounds, Color.GreenYellow));
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bounds));
#endif
        }
    }
}