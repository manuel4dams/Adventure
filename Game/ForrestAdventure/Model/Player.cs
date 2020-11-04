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

        public Player(float minX, float minY, float sizeX, float sizeY, IModel model)
            : base(minX, minY, sizeX, sizeY)
        {
            this.model = model;
        }

        public void PlayerUpdate(float frameTime)
        {
            bool intersect = false;
            var keyboard = Keyboard.GetState();
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
            }
            else
            {
                this.force += this.gravity;
            }

            float leftRightAxis = keyboard.IsKeyDown(Key.Left) ? -1f : keyboard.IsKeyDown(Key.Right) ? 1f : 0f;
            this.MinX += frameTime * leftRightAxis;
            this.MinX = Math.Max(this.MinX, -1f);
            if (this.MaxX > 1f)
            {
                this.MinX = 1f - this.SizeX;
            }

            if (keyboard.IsKeyDown(Key.Up) && this.jump <= 0)
            {
                this.jump = .5f;
            }

            if (this.jump > 0)
            {
                this.force += .025f;
                this.jump -= frameTime;
            }

            if (this.force < this.gravity)
            {
                this.force = this.gravity;
            }

            this.MinY += this.force;
            if (this.MinY <= -1.5f)
            {
                this.MinY = -0.9f;
                this.MinX = -0.9f;
            }
        }
    }
}