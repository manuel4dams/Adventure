using Framework.Components;
using Framework.Development.Components;
using Framework.Interfaces;
using Framework.Objects;
using OpenTK;
using OpenTK.Input;

namespace ForestAdventure.Objects
{
    public class DebugCollisionObjectMovable : GameObject, IUpdateable
    {
        public DebugCollisionObjectMovable()
        {
            transform.position = new Vector2(-2f, 1f);

            var bodyBounds = new RectangleBounds(2f, 2f);
            AddComponent(new QuadRenderer(this, bodyBounds));
            AddComponent(new RectangleCollider(this, bodyBounds));
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bodyBounds));
            AddComponent(new DebugTransformPositionComponent(this));
        }

        public void Update(float deltaTime)
        {
            var keyboardState = Keyboard.GetState();
            var left = keyboardState.IsKeyDown(Key.Left) || keyboardState.IsKeyDown(Key.A) ? -1f : 0f;
            var right = keyboardState.IsKeyDown(Key.Right) || keyboardState.IsKeyDown(Key.D) ? 1f : 0f;
            var up = keyboardState.IsKeyDown(Key.Up) || keyboardState.IsKeyDown(Key.W) ? 1f : 0f;
            var down = keyboardState.IsKeyDown(Key.Down) || keyboardState.IsKeyDown(Key.S) ? -1f : 0f;

            transform.position += 10f * deltaTime * new Vector2(
                left + right,
                up + down);
        }
    }
}