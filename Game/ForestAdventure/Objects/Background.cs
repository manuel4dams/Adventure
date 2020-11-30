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
#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 8f));
#endif
        }
    }
}