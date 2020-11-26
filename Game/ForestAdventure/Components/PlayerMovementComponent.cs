using Framework.Interfaces;
using Framework.Objects;
using OpenTK;
using OpenTK.Input;

namespace ForestAdventure.Components
{
    public class PlayerMovementComponent : IUpdateable
    {
        private const float MOVEMENT_SPEED = 1f;

        public GameObject gameObject { get; }

        public PlayerMovementComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public void Update(float deltaTime)
        {
            var keyboardState = Keyboard.GetState();
            var left = keyboardState.IsKeyDown(Key.Left) || keyboardState.IsKeyDown(Key.A) ? -1f : 0f;
            var right = keyboardState.IsKeyDown(Key.Right) || keyboardState.IsKeyDown(Key.D) ? 1f : 0f;
            var up = keyboardState.IsKeyDown(Key.Up) || keyboardState.IsKeyDown(Key.W) ? 1f : 0f;
            var down = keyboardState.IsKeyDown(Key.Down) || keyboardState.IsKeyDown(Key.S) ? -1f : 0f;

            gameObject.transform.position += MOVEMENT_SPEED * deltaTime * new Vector2(
                left + right,
                up + down
            );
        }
    }
}