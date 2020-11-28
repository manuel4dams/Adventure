using ForestAdventure.Components;
using Framework.Components;
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics;

namespace ForestAdventure.Objects
{
    public class Player : GameObject
    {
        public Player()
        {
            transform.position = new Vector2(-0.9f, -0.9f);

            var bodyBounds = new Bounds(0.075f, 0.15f);
            AddComponent(new RectangleComponent(this, bodyBounds, new Color4(5, 128, 13, 255)));

            AddComponent(new PlayerMovementComponent(this));
            AddComponent(new CameraComponent(this));
#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
#endif
        }
    }
}