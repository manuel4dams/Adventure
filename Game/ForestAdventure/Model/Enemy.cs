using System;

namespace ForestAdventure.Model
{
    public class Enemy : Object
    {
        private Random random = new Random();
        private String leftright;
        private float movementBorderminimal;
        private float movementBorderMaximal;

        public Enemy(
            float minX,
            float minY,
            float sizeX,
            float sizeY,
            float movementBorderminimal,
            float movementBorderMaximal)
            : base(minX, minY, sizeX, sizeY)
        {
            // enemy start direction will be random
            leftright = random.Next(1, 3) == 2 ? "left" : "right";
            this.movementBorderminimal = movementBorderminimal;
            this.movementBorderMaximal = movementBorderMaximal;
        }

        public void UpdateEnemy(float frameTime)
        {
            HandleMovement(frameTime);
        }

        private void HandleMovement(float frameTime)
        {
            switch (leftright)
            {
                case "left":
                    MinX -= frameTime * 0.1f;
                    MinX = Math.Max(MinX, -1f);
                    if (MinX < movementBorderminimal)
                    {
                        leftright = "right";
                    }

                    break;
                case "right":
                    MinX += frameTime * 0.1f;
                    MinX = Math.Max(MinX, -1f);
                    if (MinX > movementBorderMaximal)
                    {
                        leftright = "left";
                    }

                    break;
                default:
                    Console.WriteLine("Error: enemy movement out of bound");
                    break;
            }
        }
    }
}