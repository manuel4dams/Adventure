using Framework.Collision.Collider;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Checkpoints
{
    public class Checkpoint: GameObject
    {
        public Checkpoint(Vector2 position)
        {
            transform.position = position;

            var bounds = new RectangleBounds(4f, 4f);
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.Resources.Checkpoint, RenderScaleType.Crop));
            AddComponent(new RectangleColliderComponent(this, bounds, true));
            AddComponent(new CheckpointAnimation(this));
        }
    }
}