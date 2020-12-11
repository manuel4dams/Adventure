using ForestAdventure.Objects;
using Framework.Interfaces;
using Framework.Objects;
using OpenTK;
using OpenTK.Input;

namespace ForestAdventure.Components
{
    public class PlayerMovementComponent : IComponent, IUpdateable, ICollision
    {
        private const float MOVEMENT_SPEED = 10f;
        private const float CLIMB_SPEED = 7f;
        private const float GRAVITY_CONSTANT = 9.81f;
        private float gravityVelocity;
        private bool climbing = false;

        public GameObject gameObject { get; }

        public PlayerMovementComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public void OnCollision(ICollider other, Vector2 touchOffset)
        {

            if (other.gameObject is Platform && touchOffset.Y > 0f)
            {
                gravityVelocity = 0f;
            }
            else if (other.gameObject is ClimbablePlatform && touchOffset.Y > 0f)
            {
                gravityVelocity = -0.004f;
            }
            else if (other.gameObject is ClimbablePlatform && touchOffset.Y < 0f)
            {
                if (Keyboard.GetState().IsKeyDown(Key.Up) || Keyboard.GetState().IsKeyDown(Key.W))
                {
                    climbing = true;
                }
            }
        }

        public void Update(float deltaTime)
        {
            // TODO Jumping needs improvement to feel more natural
            var keyboardState = Keyboard.GetState();
            var left = keyboardState.IsKeyDown(Key.Left) || keyboardState.IsKeyDown(Key.A) ? -1f : 0f;
            var right = keyboardState.IsKeyDown(Key.Right) || keyboardState.IsKeyDown(Key.D) ? 1f : 0f;
            var up = keyboardState.IsKeyDown(Key.Up) || keyboardState.IsKeyDown(Key.W) ? 1.5f : 0f;
            var down = keyboardState.IsKeyDown(Key.Down) || keyboardState.IsKeyDown(Key.S) ? -1f : 0f;

            gameObject.transform.position += MOVEMENT_SPEED * deltaTime * new Vector2(
                left + right,
                up + down);
            if (climbing == true)
            {
                gameObject.transform.position += CLIMB_SPEED * deltaTime * new Vector2(
                                left + right,
                                up + down);
                climbing = false;
            }

            gravityVelocity += deltaTime * deltaTime * GRAVITY_CONSTANT;
            gameObject.transform.position += gravityVelocity * new Vector2(0f, -1f);
        }
    }
}