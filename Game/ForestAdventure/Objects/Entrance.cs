using Framework.Components;
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics;

namespace ForestAdventure.Objects
{
    public class Entrance : GameObject
    {
        public Entrance()
        {
            transform.position = new Vector2(-1.35f, -0.85f);
            var bounds = new Bounds(0.1f, 0.3f);
            AddComponent(new RectangleComponent(this, bounds, new Color4(40, 26, 13, 255)));
#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
#endif
        }
    }
}