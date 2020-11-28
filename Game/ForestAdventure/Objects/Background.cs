using Framework.Components;
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics;

namespace ForestAdventure.Objects
{
    public class Background : GameObject
    {
        public Background()
        {
            transform.position = new Vector2(0f, 0f);
            var bounds = new Bounds(8f, 4f);
            AddComponent(new RectangleComponent(this, bounds, new Color4(34, 139, 34, 255)));
#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 8f));
#endif
        }
    }
}