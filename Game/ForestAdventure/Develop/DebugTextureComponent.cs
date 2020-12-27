using Framework.Development.Components;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Develop
{
    public class DebugTextureComponent : GameObject
    {
        public DebugTextureComponent(Vector2 bounds, Vector2 position)
        {
            transform.position = position;

            var bound = new RectangleBounds(bounds);
            AddComponent(new RectangleTextureRenderer(this, bound, Resources.EnemyRight, RenderScaleType.Crop));
            AddComponent(new DebugColliderEdgesComponent(this, bound));
            AddComponent(new DebugTransformPositionComponent(this));
        }
    }
}