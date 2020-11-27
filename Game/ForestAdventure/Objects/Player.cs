using ForestAdventure.Components;
using Framework.Components;
using Framework.Objects;
using OpenTK;

namespace ForestAdventure.Objects
{
    public class Player : GameObject
    {
        public Player()
        {
            transform.position = new Vector2(-0.9f, -0.9f);

            var bodyBounds = new Bounds(0.075f, 0.15f);
            AddComponent(new RectangleComponent(this, bodyBounds, Color.Aqua));

            var headBounds = new Bounds(0f, 0.08f, 0.1f, 0.1f);
            AddComponent(new RectangleComponent(this, headBounds, Color.Red));

            AddComponent(new PlayerMovementComponent(this));
            AddComponent(new CameraComponent(this));
#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
#endif
        }
    }
}