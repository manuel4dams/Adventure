using System;
using ForestAdventure.Helper;
using ForestAdventure.Interfaces;

namespace ForestAdventure.Components
{
    public class CMovementNoInput : IMovable
    {
        private readonly float movementBorderLeft;
        private readonly float movementBorderRight;
        private readonly Random random = new Random();
        private bool leftRight;
        private GameObjectBounds gameObjectBounds;

        public CMovementNoInput(float movementBorderLeft, float movementBorderRight, GameObjectBounds gameObjectBounds)
        {
            this.gameObjectBounds = gameObjectBounds;
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
                gameObjectBounds.MinX -= 0.001f;
                gameObjectBounds.MinX = Math.Max(gameObjectBounds.MinX, -1f);

                // turn when border reached
                if (gameObjectBounds.MinX < movementBorderLeft) leftRight = false;
            }
            else if (leftRight == false)
            {
                gameObjectBounds.MinX += 0.001f;
                gameObjectBounds.MinX = Math.Max(gameObjectBounds.MinX, -1f);

                // turn when border reached
                if (gameObjectBounds.MinX > movementBorderRight) leftRight = true;
            }
        }
    }
}