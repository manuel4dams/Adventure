using Adventure.Bow;
using Adventure.Enemies;
using Adventure.Level;
using Adventure.Platforms;
using Adventure.Ropes;
using Adventure.Traps;
using Framework.Camera;
using Framework.Game;
using Framework.Interfaces;
using Framework.Render;
using Framework.Transform;
using OpenTK;
using OpenTK.Input;

namespace Adventure.PlayerComponents
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
        private const float ANIMATION_TIMER_RESET = 0.1f;
        private const float MAX_FALL_SPEED = -40f;

        private readonly RectangleTextureRenderer playerRenderer;

        private float jumpTimer = JUMP_COOLDOWN;
        private float graceJumpTimer;
        private bool jumpAllowed;
        private bool climbable;
        private Vector2 velocity;
        private int animationFrame;
        private float animationTimer;
        private Vector2 pos;
        private Transform rope;
        private BowComponent bow;
        public GameObject gameObject { get; }

        public PlayerMovementComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
            playerRenderer = gameObject.GetComponent<RectangleTextureRenderer>(0) as RectangleTextureRenderer;
            bow = gameObject.GetComponent<BowComponent>(0) as BowComponent;
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
                case VerticalRope _:
                    climbable = true;
                    rope = other.gameObject.transform;
                    break;
                case Enemy _:
                    climbable = false;
                    velocity = new Vector2(0, 0);
                    break;
                case HorizontalMovingTrap _:
                    climbable = false;
                    velocity = new Vector2(0, 0);
                    break;
                case VerticalMovingTrap _:
                    climbable = false;
                    velocity = new Vector2(0, 0);
                    break;
                case BottomLevelBorder _:
                    velocity = new Vector2(0, 0);
                    break;
            }
        }

        public void Update(float deltaTime)
        {
            bow.enabled = true;
            var keyboardState = Keyboard.GetState();
            var left = keyboardState.IsKeyDown(Key.A) ? -0.5f : 0f;
            var right = keyboardState.IsKeyDown(Key.D) ? 0.5f : 0f;
            var climbing = keyboardState.IsKeyDown(Key.Space);
            var down = keyboardState.IsKeyDown(Key.S) ? -0.2f : 0f;
            var up = 0f;
            if (velocity.Y <= MAX_FALL_SPEED)
            {
                velocity.Y = MAX_FALL_SPEED;
            }

            if (climbable && climbing)
            {
                left *= 0f;
                right *= 0f;

                bow.enabled = false;
                SetAnimation(deltaTime);

                if (keyboardState.IsKeyDown(Key.A))
                {
                    gameObject.transform.position.X = rope.position.X - 0.6f;
                }

                if (keyboardState.IsKeyDown(Key.D))
                {
                    gameObject.transform.position.X = rope.position.X + 0.6f;
                }

                velocity.Y = 0f;
            }

            if ((keyboardState.IsKeyDown(Key.W)) && climbing && climbable)
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

            if (climbing && climbable)
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
            var mousePosition = Camera.instance.MousePositionToWorld();
            pos = mousePosition - gameObject.transform.position;

            CheckIfJumpAllowed(deltaTime, climbing);
            SetStandingAnimation(climbing);
            climbable = false;
        }

        private void SetAnimation(float deltaTime)
        {
            if (velocity.Y != 0)
            {
                if (animationTimer <= 0)
                {
                    if (gameObject.transform.position.X < rope.position.X)
                    {
                        playerRenderer.SetCropData(new Vector4(animationFrame * 0.25f, 0.33333f,
                            (animationFrame + 1) * 0.25f, 0.66666f));
                    }
                    else
                    {
                        playerRenderer.SetCropData(new Vector4((animationFrame + 1) * 0.25f, 0.33333f,
                            animationFrame * 0.25f, 0.66666f));
                    }

                    animationFrame++;
                    if (animationFrame >= 4)
                    {
                        animationFrame = 0;
                    }

                    animationTimer = ANIMATION_TIMER_RESET;
                }

                animationTimer -= deltaTime;
            }
            else
            {
                if (gameObject.transform.position.X < rope.position.X)
                {
                    gameObject.transform.position.X = rope.position.X - 0.6f;
                    playerRenderer.SetCropData(new Vector4(0f, 0.33333f, 0.25f, 0.66666f));
                }
                else
                {
                    gameObject.transform.position.X = rope.position.X + 0.6f;
                    playerRenderer.SetCropData(new Vector4(0.25f, 0.33333f, 0f, 0.66666f));
                }
            }
        }

        private void SetStandingAnimation(bool climbing)
        {
            if (!(climbing && climbable) && velocity.X == 0 && jumpAllowed)
            {
                if (pos.X > 0)
                {
                    playerRenderer.SetCropData(new Vector4(0, 0.66666f, 0.25f, 1f));
                    animationTimer = 0;
                }
                else
                {
                    playerRenderer.SetCropData(new Vector4(0.25f, 0.66666f, 0f, 1f));
                    animationTimer = 0;
                }
            }
        }

        private void CheckIfJumpAllowed(float deltaTime, bool climbing)
        {
            switch (jumpAllowed)
            {
                case true:
                {
                    if (velocity.X != 0)
                    {
                        if (animationTimer <= 0)
                        {
                            if (pos.X > 0)
                            {
                                playerRenderer.SetCropData(new Vector4(animationFrame * 0.25f, 0.66666f,
                                    (animationFrame + 1) * 0.25f, 1f));
                            }
                            else
                            {
                                playerRenderer.SetCropData(new Vector4((animationFrame + 1) * 0.25f, 0.66666f,
                                    animationFrame * 0.25f, 1f));
                            }

                            animationFrame++;
                            if (animationFrame >= 4)
                            {
                                animationFrame = 0;
                            }

                            animationTimer = ANIMATION_TIMER_RESET;
                        }

                        animationTimer -= deltaTime;
                    }

                    break;
                }
                case false when !(climbable && climbing):
                {
                    playerRenderer.SetCropData(pos.X > 0
                        ? new Vector4(0f, 0f, 0.25f, 0.33333f)
                        : new Vector4(0.25f, 0f, 0f, 0.33333f));

                    break;
                }
            }
        }
    }
}