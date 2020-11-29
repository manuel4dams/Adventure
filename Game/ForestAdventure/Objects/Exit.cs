using Framework.Components;
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics;

namespace ForestAdventure.Objects
{
    public class Exit : GameObject
    {
        public Exit()
        {
            transform.position = new Vector2(3.605f, 1.5f);
            var bounds = new Bounds(0.09f, 0.2f);
            AddComponent(new RectangleDrawable(this, bounds, new Color4(13, 175, 184, 255)));
#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
            AddComponent(new DebugColliderEdges(this, bounds));
#endif
        }
    }
}