using System;
using ForestAdventure.Enemies;
using ForestAdventure.Platforms;
using ForestAdventure.Ropes;
using Framework.Game;
using Framework.Interfaces;
using OpenTK;
using OpenTK.Input;

namespace ForestAdventure.PlayerComponents
{
    public class PlayerMovementComponent : IComponent, IUpdateable, ICollision
    {
        private const float MOVEMENT_SPEED = 15f;
        private const float CLIMB_SPEED = 7f;
        private const float GRAVITY_CONSTANT = -22f;
        private const float JUMP_MULTIPLIER = 0.3f;
        private const float JUMP_COOLDOWN = 1f;
        private const float FALL_MULTIPLIER = 3.5f;
        private const float LOW_JUMP_MULTIPLIER = 2.25f;

        private float jumpTimer = JUMP_COOLDOWN;
        private float graceJumpTimer;
        private bool jumpAllowed;
        private bool climbableH;
        private bool climbableV;
        private Vector2 velocity;

        // TODO fix jumping, the jump height varies 
        public GameObject gameObject { get; }

        public PlayerMovementComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public void OnCollision(ICollider other, Vector2 touchOffset)
        {
            switch (other.gameObject)
            {
                case Platform _:
                    if (touchOffset.Y > 0f)
                    {
                        velocity.Y = 0f;
                        jumpAllowed = true;
                        graceJumpTimer = 0f;
                    }

                    break;
                case HorizontalRope _:
                    climbableH = true;
                    break;
                case VerticalRope _:
                    climbableV = true;
                    break;
            }

            if (other.gameObject is Enemy)
            {
                velocity = new Vector2(0, 0);
            }
        }

        public void Update(float deltaTime)
        {
            var keyboardState = Keyboard.GetState();
            var left = keyboardState.IsKeyDown(Key.Left) || keyboardState.IsKeyDown(Key.A) ? -0.5f : 0f;
            var right = keyboardState.IsKeyDown(Key.Right) || keyboardState.IsKeyDown(Key.D) ? 0.5f : 0f;
            var climbing = keyboardState.IsKeyDown(Key.ShiftLeft);
            var down = keyboardState.IsKeyDown(Key.Down) || keyboardState.IsKeyDown(Key.S) ? -0.2f : 0f;
            var up = 0f;
            if ((climbableH || climbableV) && climbing)
            {
                velocity.Y = 0f;
                if (climbableV)
                {
                    left *= 0.1f;
                    right *= 0.1f;
                }
            }

            if ((keyboardState.IsKeyDown(Key.Up) || keyboardState.IsKeyDown(Key.W)) && climbing &&
                (climbableH || climbableV))
            {
                up = 0.2f;
            }
            
            jumpTimer += deltaTime;
            if (keyboardState.IsKeyDown(Key.Space) && jumpTimer >= JUMP_COOLDOWN && jumpAllowed)
            {
                velocity.Y = JUMP_MULTIPLIER;
                jumpTimer = 0f;
                jumpAllowed = false;
            }

            velocity.X = (CLIMB_SPEED + MOVEMENT_SPEED) * deltaTime * (left + right);

            if (climbing && (climbableH || climbableV))
            {
                velocity = (CLIMB_SPEED + MOVEMENT_SPEED) * deltaTime * new Vector2(
                    left + right,
                    up + down);
            }
            else
            {
                if (velocity.Y < 0)
                {
                    velocity += new Vector2(0f, 1f) * (deltaTime * GRAVITY_CONSTANT) * (FALL_MULTIPLIER - 1f) *
                                deltaTime;
                }
                else if (velocity.Y > 0 && !keyboardState.IsKeyDown(Key.Space))
                {
                    velocity += new Vector2(0f, 1f) * (deltaTime * GRAVITY_CONSTANT) * (LOW_JUMP_MULTIPLIER - 1f) *
                                deltaTime;
                }

                velocity.Y += deltaTime * deltaTime * GRAVITY_CONSTANT;
            }

            graceJumpTimer += deltaTime;
            if (velocity.Y < 0 && graceJumpTimer > 0.1f)
            {
                jumpAllowed = false;
            }

            gameObject.transform.position += velocity;

            climbableH = false;
            climbableV = false;
        }
    }
}