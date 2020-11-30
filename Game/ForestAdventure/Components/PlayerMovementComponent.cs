using ForestAdventure.Objects;
using Framework.Interfaces;
using Framework.Objects;
using OpenTK;
using OpenTK.Input;

namespace ForestAdventure.Components
{
    public class PlayerMovementComponent : IComponent, IUpdateable, ICollision
    {
        private const float MOVEMENT_SPEED = 1f;
        private const float GRAVITY_CONSTANT = 9.81f / 20f;

        public GameObject gameObject { get; }

        private float gravityVelocity;

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
                up + down);
            gravityVelocity += deltaTime * deltaTime * GRAVITY_CONSTANT;
            gameObject.transform.position += gravityVelocity * new Vector2(0f, -1f);
        }

        public void OnCollision(ICollider other)
        {
            if (other.gameObject is Platform)
                gravityVelocity = 0f;
        }
    }
}