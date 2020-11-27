using Framework.Components;
using Framework.Objects;
using OpenTK;

namespace ForestAdventure.Objects
{
    public class Entrance : GameObject
    {
        public Entrance()
        {
            transform.position = new Vector2(-1f, -1f);
            var bounds = new Bounds(0.1f, 0.3f);
            AddComponent(new RectangleComponent(this, bounds));
#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
#endif
        }
    }
}