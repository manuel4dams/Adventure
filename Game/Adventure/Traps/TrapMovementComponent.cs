using System;
using Framework.Game;
using Framework.Interfaces;

namespace Adventure.Traps
{
    public class TrapMovementComponent : IComponent, IUpdateable
    {
        public enum MovementDirection
        {
            Horizontal,
            Vertical,
        }

        private const float MOVEMENT_SPEED = 3f;

        private readonly MovementDirection movementDirection;
        private readonly float movementBorderLeft;
        private readonly float movementBorderRight;
        private readonly Random random = new Random();
        private bool switchDirection;

        public GameObject gameObject { get; }

        public TrapMovementComponent(
            GameObject gameObject,
            float movementBorderLeft,
            float movementBorderRight,
            MovementDirection movementDirection = MovementDirection.Horizontal)
        {
            this.gameObject = gameObject;
            this.movementBorderLeft = movementBorderLeft;
            this.movementBorderRight = movementBorderRight;
            this.movementDirection = movementDirection;

            // start moving in random direction
            switchDirection = random.Next(1, 3) == 2;
        }

        public void Update(float deltaTime)
        {
            switch (movementDirection)
            {
                case MovementDirection.Horizontal:
                    MoveHorizontal(deltaTime);
                    break;
                case MovementDirection.Vertical:
                    MoveVertical(deltaTime);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MoveHorizontal(float deltaTime)
        {
            {
                // let enemy move from left to right
                if (switchDirection)
                {
                    gameObject.transform.position.X -= MOVEMENT_SPEED * deltaTime;

                    // turn when border reached
                    if (gameObject.transform.position.X < movementBorderLeft)
                    {
                        switchDirection = false;
                    }
                }
                else
                {
                    gameObject.transform.position.X += MOVEMENT_SPEED * deltaTime;

                    // turn when border reached
                    if (gameObject.transform.position.X > movementBorderRight)
                    {
                        switchDirection = true;
                    }
                }
            }
        }

        private void MoveVertical(float deltaTime)
        {
            if (switchDirection)
            {
                gameObject.transform.position.Y -= MOVEMENT_SPEED * deltaTime;

                // turn when border reached
                if (gameObject.transform.position.Y < movementBorderLeft)
                {
                    switchDirection = false;
                }
            }
            else
            {
                gameObject.transform.position.Y += MOVEMENT_SPEED * deltaTime;

                // turn when border reached
                if (gameObject.transform.position.Y > movementBorderRight)
                {
                    switchDirection = true;
                }
            }
        }
    }
}