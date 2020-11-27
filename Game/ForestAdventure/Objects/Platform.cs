using Framework.Components;
using Framework.Objects;
using OpenTK;

namespace ForestAdventure.Objects
{
    public class Platform : GameObject
    {
        public Platform(Vector2 position, float length)
        {
            transform.position = position;
            var bounds = new Bounds(length, 0.026f);
            AddComponent(new RectangleComponent(this, bounds));
#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
#endif
        }
    }
}