using System;
using Framework.Interfaces;
using Framework.Objects;

namespace ForestAdventure.Components
{
    public class MovementNoInputComponent : IComponent, IUpdateable
    {
        private const float MOVEMENT_SPEED = 5f;

        private readonly float movementBorderLeft;
        private readonly float movementBorderRight;
        private readonly Random random = new Random();

        private bool leftRight;

        public GameObject gameObject { get; }

        public MovementNoInputComponent(
            GameObject gameObject,
            float movementBorderLeft,
            float movementBorderRight)
        {
            this.gameObject = gameObject;
            this.movementBorderLeft = movementBorderLeft;
            this.movementBorderRight = movementBorderRight;

            // start moving in random direction
            leftRight = random.Next(1, 3) == 2;
        }

        public void Update(float deltaTime)
        {
            // let enemy move from left to right
            if (leftRight)
            {
                gameObject.transform.position.X -= MOVEMENT_SPEED * deltaTime;
                gameObject.transform.position.X = Math.Max(gameObject.transform.position.X, -1f);

                // turn when border reached
                if (gameObject.transform.position.X < movementBorderLeft)
                {
                    leftRight = false;
                }
            }
            else
            {
                gameObject.transform.position.X += MOVEMENT_SPEED * deltaTime;
                gameObject.transform.position.X = Math.Max(gameObject.transform.position.X, -1f);

                // turn when border reached
                if (gameObject.transform.position.X > movementBorderRight)
                {
                    leftRight = true;
                }
            }
        }
    }
}