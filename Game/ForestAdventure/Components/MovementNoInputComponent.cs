using System;
using ForestAdventure.Helper;
using ForestAdventure.Interfaces;

namespace ForestAdventure.Components
{
    public class MovementNoInputComponent : IMovable
    {
        private readonly float movementBorderLeft;
        private readonly float movementBorderRight;
        private readonly Random random = new Random();
        private bool leftRight;
        private Bounds bounds;

        public MovementNoInputComponent(float movementBorderLeft, float movementBorderRight, Bounds bounds)
        {
            this.bounds = bounds;
            this.movementBorderLeft = movementBorderLeft;
            this.movementBorderRight = movementBorderRight;

            // start moving on random position, btween given borders
            leftRight = random.Next(1, 3) == 2;
        }

        public void Move()
        {
            // let enemy move from left to right
            if (leftRight)
            {
                bounds.MinX -= 0.001f;
                bounds.MinX = Math.Max(bounds.MinX, -1f);

                // turn when border reached
                if (bounds.MinX < movementBorderLeft) leftRight = false;
            }
            else if (leftRight == false)
            {
                bounds.MinX += 0.001f;
                bounds.MinX = Math.Max(bounds.MinX, -1f);

                // turn when border reached
                if (bounds.MinX > movementBorderRight) leftRight = true;
            }
        }
    }
}