using System;
using OpenTK.Input;

namespace ForestAdventure.Model
{
    public class Player : Object
    {
        private readonly Model model;
        private readonly float gravity = -0.025f;
        private float jump = 0;
        private float force = 0.025f;
        private bool intersect;

        public Player(float minX, float minY, float sizeX, float sizeY, Model model)
            : base(minX, minY, sizeX, sizeY)
        {
            this.model = model;
        }

        public void UpdatePlayer(float frameTime)
        {
            CheckEnemyCollision();

            // for now freeze when hitting the exit
            if (CheckWinCondition())
            {
                return;
            }

            CheckPlayerFallingOfTheMap();
            HandlePlayerPlatformAirBehavior();

            KeyboardState keyboard = Keyboard.GetState();
            HandleJump(keyboard, frameTime);
            HandleMovement(keyboard, frameTime);
        }

        private void CheckEnemyCollision()
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

        private void CheckPlayerFallingOfTheMap()
        {
            if (this.MinY <= -1.5f)
            {
                this.MinY = -0.9f;
                this.MinX = -0.9f;
            }
        }

        private bool CheckWinCondition()
        {
            return this.IntersectCheck(this.model.Exit);
        }

        private void HandlePlayerPlatformAirBehavior()
        {
            foreach (IRectangle platform in this.model.Platform)
            {
                if (this.JumpIntersectCheck(platform))
                {
                    intersect = true;
                    break;
                }

                if (this.JumpIntersectCheck(platform, this.force))
                {
                    this.MinY = platform.MaxY;
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

        private void HandleJump(KeyboardState keyboard, float frameTime)
        {
            bool isJump = keyboard.IsKeyDown(Key.Up) || keyboard.IsKeyDown(Key.W);
            if (isJump && this.jump <= 0)
            {
                foreach (IRectangle platform in this.model.Platform)
                {
                    if (this.JumpIntersectCheck(platform))
                    {
                        Console.WriteLine(SizeX);
                        this.jump = 0.2f;
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

        private void HandleMovement(KeyboardState keyboard, float frameTime)
        {
            float leftRightAxis = keyboard.IsKeyDown(Key.Left) || keyboard.IsKeyDown(Key.A) ? -1f : keyboard.IsKeyDown(Key.Right) || keyboard.IsKeyDown(Key.D) ? 1f : 0f;
            this.MinX += frameTime * leftRightAxis;

            this.MinX = Math.Max(this.MinX, -1f);
        }
    }
}