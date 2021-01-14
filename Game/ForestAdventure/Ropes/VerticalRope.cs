using Framework.Collision.Collider;
using Framework.Development.Components;
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

            var bounds = new RectangleBounds(0.30f, height);
            var textureRenderer = new RectangleTextureRenderer(this, bounds, Resources.Resources.Rope, RenderScaleType.Tile);
            AddComponent(textureRenderer);
            AddComponent(new RectangleColliderComponent(this, bounds, true, true));
            textureRenderer.setCropData(new Vector4(0, 0f, 1f, height / 2f));
        }
    }
}