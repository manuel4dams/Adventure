using Framework.Development.Components;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;
using OpenTK.Graphics;

namespace ForestAdventure.Level
{
    public class ForestBackground : GameObject
    {
        public ForestBackground()
        {
            transform.position = new Vector2(30f, 50f);

            var bounds = new RectangleBounds(200f, 200f);
            AddComponent(new QuadRenderer(this, bounds, Color4.LightGreen));
#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this));
#endif
        }
    }
}