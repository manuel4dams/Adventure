using System;
using Framework.Game;
using Framework.Interfaces;
using Framework.Render;
using OpenTK;

namespace ForestAdventure.Enemies
{
    public class MovementNoInputComponent : IComponent, IUpdateable
    {
        private const float MOVEMENT_SPEED = 5f;
        private const float ANIMATION_TIMER_RESET = 0.1f;

        private readonly float movementBorderLeft;
        private readonly float movementBorderRight;
        private readonly Random random = new Random();

        private RectangleTextureRenderer enemyRenderer;
        private int animationFrame;
        private float animationTimer = 0;

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
            enemyRenderer = gameObject.GetComponent<RectangleTextureRenderer>(0) as RectangleTextureRenderer;

            // start moving in random direction
            leftRight = random.Next(1, 3) == 2;
        }

        public void Update(float deltaTime)
        {
            // let enemy move from left to right
            if (leftRight)
            {
                gameObject.transform.position.X -= MOVEMENT_SPEED * deltaTime;

                // turn when border reached
                if (gameObject.transform.position.X < movementBorderLeft)
                {
                    leftRight = false;
                }

                if (animationTimer <= 0)
                {
                    enemyRenderer.SetCropData(new Vector4((animationFrame + 1) * 0.25f, 0f,
                        animationFrame * 0.25f, 1f));

                    animationFrame++;
                    if (animationFrame >= 4)
                    {
                        animationFrame = 0;
                    }

                    animationTimer = ANIMATION_TIMER_RESET;
                }
            }
            else
            {
                gameObject.transform.position.X += MOVEMENT_SPEED * deltaTime;

                // turn when border reached
                if (gameObject.transform.position.X > movementBorderRight)
                {
                    leftRight = true;
                }

                if (animationTimer <= 0)
                {
                    enemyRenderer.SetCropData(new Vector4(animationFrame * 0.25f, 0f,
                        (animationFrame + 1) * 0.25f, 1f));

                    animationFrame++;
                    if (animationFrame >= 4)
                    {
                        animationFrame = 0;
                    }

                    animationTimer = ANIMATION_TIMER_RESET;
                }
            }

            animationTimer -= deltaTime;
        }
    }
}