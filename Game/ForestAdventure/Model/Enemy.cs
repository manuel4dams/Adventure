using System;

namespace ForestAdventure.Model
{
    public class Enemy : Object
    {
        private readonly Model model;

        public Enemy(float minX, float minY, float sizeX, float sizeY, Model model)
            : base(minX, minY, sizeX, sizeY)
        {
            this.model = model;
        }

        public void UpdateEnemy(float frameTime)
        {
            HandleMovement(frameTime);
        }

        private void HandleMovement(float frameTime)
        {
            this.MinX += frameTime * 1f;
            this.MinX = Math.Max(this.MinX, -1f);
        }
    }
}