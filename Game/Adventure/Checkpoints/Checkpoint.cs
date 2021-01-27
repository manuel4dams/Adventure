using System.Drawing;
using Framework.Collision.Collider;
using Framework.Development.Components;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using Framework.Util;
using OpenTK;

namespace Adventure.Checkpoints
{
    public class Checkpoint : GameObject
    {
        public Checkpoint(Vector2 position)
        {
            transform.position = position;

            var bounds = new RectangleBounds(4f, 4f);
            AddComponent(new RectangleTextureRenderer(
                this,
                bounds,
                Resources.Resources.Checkpoint,
                RenderScaleType.Crop));
            AddComponent(new RectangleColliderComponent(this, bounds, true));
            AddComponent(new CheckpointAnimation(this));
            if (Debug.enabled)
            {
                AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bounds, Color.GreenYellow));
                AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bounds));
            }
        }
    }
}