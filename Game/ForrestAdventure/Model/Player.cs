using OpenTK.Input;
using System;

namespace ForrestAdventure.Model
{
    public class Player : Object
    {
        private readonly IModel model;
        private readonly float gravity = -0.025f;
        private float jump = 0;
        private float force = 0.025f;
        private bool intersect;

        public Player(float minX, float minY, float sizeX, float sizeY, IModel model)
            : base(minX, minY, sizeX, sizeY)
        {
            this.model = model;
        }

        public void updatePlayer(float frameTime)
        {
            checkEnemyCollision();
            // for now freeze when hitting the exit
            if (checkWinCondition())
            {
                return;
            }

            checkPlayerFallingOfTheMap();
            handlePlayerPlatformAirBehavior();

            KeyboardState keyboard = Keyboard.GetState();
            handleJump(keyboard, frameTime);
            handleMovement(keyboard, frameTime);
        }

        private void checkEnemyCollision()
        {
            foreach (IRectangle enemy in this.model.Enemies)
            {
                if (this.IntersectCheck(enemy))
                {
                    this.MinY = -0.9f;
                    this.MinX = -0.9f;
                }
            }
        }

        private void checkPlayerFallingOfTheMap()
        {
            if (this.MinY <= -1.5f)
            {
                this.MinY = -0.9f;
                this.MinX = -0.9f;
            }
        }

        private bool checkWinCondition()
        {
            return this.IntersectCheck(this.model.Exit);
        }

        private void handlePlayerPlatformAirBehavior()
        {
            foreach (IRectangle platform in this.model.Platform)
            {
                if (this.IntersectCheck(platform))
                {
                    intersect = true;
                    break;
                }
            }

            if (intersect)
            {
                this.force = 0;
                intersect = false;
            }
            else
            {
                this.force += this.gravity;
            }
        }

        private void handleJump(KeyboardState keyboard, float frameTime)
        {
            if (keyboard.IsKeyDown(Key.Up) && this.jump <= 0)
            {
                foreach (IRectangle platform in this.model.Platform)
                {
                    if (this.BoxCheck(new Object(this.MinX, this.MinY - 0.0375f, 0.075f, 0.075f),platform))
                    {
                        this.jump = 0.5f;
                        break;
                    }
                }
            }

            if (this.jump > 0f)
            {
                if (this.force < 1f)
                {
                    this.force += 0.025f;
                }

                this.jump -= frameTime;
                Console.WriteLine(jump);
            }

            // handle gravity
            if (this.force < this.gravity)
            {
                this.force = this.gravity;
            }

            if (this.force < 1f)
            {
                this.MinY += this.force;
            }
        }

        private void handleMovement(KeyboardState keyboard, float frameTime)
        {
            float leftRightAxis = keyboard.IsKeyDown(Key.Left) ? -1f : keyboard.IsKeyDown(Key.Right) ? 1f : 0f;
            this.MinX += frameTime * leftRightAxis;

            this.MinX = Math.Max(this.MinX, -1f);
        }
    }
}