using Framework.Development.Components;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Develop
{
    public class DebugTextureTilingComponent : GameObject
    {
        public DebugTextureTilingComponent()
        {
            transform.position = Vector2.Zero;

            var bounds1 = new RectangleBounds(new Vector2(-4f, -6f), new Vector2(16f, 2f));
            AddComponent(new RectangleTextureRenderer(
                this,
                bounds1,
                Resources.Resources.BrickWall,
                RenderScaleType.Deform,
                RenderTileableType.TileableX));
            AddComponent(new DebugColliderEdgesComponent(this, bounds1));

            var bounds2 = new RectangleBounds(new Vector2(8f, 0f), new Vector2(2f, 16f));
            AddComponent(new RectangleTextureRenderer(
                this,
                bounds2,
                Resources.Resources.BrickWall,
                RenderScaleType.Deform,
                RenderTileableType.TileableY));
            AddComponent(new DebugColliderEdgesComponent(this, bounds2));

            var bounds3 = new RectangleBounds(new Vector2(-4f, 4f), new Vector2(8f, 8f));
            AddComponent(new RectangleTextureRenderer(
                this,
                bounds3,
                Resources.Resources.BrickWall,
                RenderScaleType.Deform,
                RenderTileableType.TileableXY));
            AddComponent(new DebugColliderEdgesComponent(this, bounds3));

            AddComponent(new DebugTransformPositionComponent(this));
        }
    }
}