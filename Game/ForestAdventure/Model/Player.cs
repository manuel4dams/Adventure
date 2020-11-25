using System;
using ForestAdventure.View;
using OpenTK;
using OpenTK.Input;

namespace ForestAdventure.Model
{
    [Obsolete]
    public class Player : Object
    {
        private readonly Camera camera;
        private readonly float gravity = -0.025f;
        private readonly Model model;
        private float force = 0.025f;
        private bool intersect;
        private float jump;

        public Player(float minX, float minY, float sizeX, float sizeY, Model model, Camera camera)
            : base(minX, minY, sizeX, sizeY)
        {
            this.camera = camera;
            this.model = model;
        }

        public bool UpdatePlayer(float frameTime)
        {
            CheckEnemyCollision();

            // for now freeze when hitting the exit
            if (CheckWinCondition()) return true;

            CheckPlayerFallingOfTheMap();
            HandlePlayerPlatformAirBehavior();

            var keyboard = Keyboard.GetState();
            HandleJump(keyboard, frameTime);
            HandleMovement(keyboard, frameTime);
            camera.Center = new Vector2(MinX + (SizeX / 2), MinY + (SizeY / 2));
            camera.Draw();
            return false;
        }

        private void CheckEnemyCollision()
        {
            foreach (var enemy in model.Enemies)
            {
                if (IntersectCheck(enemy))
                {
                    MinY = -0.9f;
                    MinX = -0.9f;
                }
            }
        }

        private void CheckPlayerFallingOfTheMap()
        {
            if (MinY <= -1.5f)
            {
                MinY = -0.9f;
                MinX = -0.9f;
            }
        }

        private bool CheckWinCondition()
        {
            return IntersectCheck(model.Exit);
        }

        private void HandlePlayerPlatformAirBehavior()
        {
            foreach (var platform in model.Platform)
            {
                if (JumpIntersectCheck(platform))
                {
                    intersect = true;
                    break;
                }

                if (JumpIntersectCheck(platform, force))
                {
                    MinY = platform.MaxY;
                    intersect = true;
                    break;
                }
            }

            if (intersect)
            {
                force = 0;
                intersect = false;
            }
            else
            {
                force += gravity;
            }
        }

        private void HandleJump(KeyboardState keyboard, float frameTime)
        {
            var isJump = keyboard.IsKeyDown(Key.Up) || keyboard.IsKeyDown(Key.W);
            if (isJump && jump <= 0)
            {
                foreach (var platform in model.Platform)
                {
                    if (JumpIntersectCheck(platform))
                    {
                        Console.WriteLine(SizeX);
                        jump = 0.25f;
                        break;
                    }
                }
            }

            if (jump > 0f)
            {
                if (force < 1f) force += 0.025f;

                jump -= frameTime;
            }

            // handle gravity
            if (force < gravity) force = gravity;

            if (force < 1f) MinY += force;
        }

        private void HandleMovement(KeyboardState keyboard, float frameTime)
        {
            var leftRightAxis = keyboard.IsKeyDown(Key.Left) || keyboard.IsKeyDown(Key.A) ? -1f :
                keyboard.IsKeyDown(Key.Right) || keyboard.IsKeyDown(Key.D) ? 1f : 0f;
            MinX += frameTime * leftRightAxis;

            MinX = Math.Max(MinX, -1f);
        }
    }
}