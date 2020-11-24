using System;
using ForestAdventure.Interfaces;
using OpenTK.Input;

namespace ForestAdventure.Components
{
    public class CPlayerMovement : IMovable
    {
        private KeyboardState keyboardState;

        public CPlayerMovement()
        {
            keyboardState = Keyboard.GetState();
        }

        public void Move()
        {
            float leftRightAxis = keyboardState.IsKeyDown(Key.Left) || keyboardState.IsKeyDown(Key.A) ? -1f :
                keyboardState.IsKeyDown(Key.Right) || keyboardState.IsKeyDown(Key.D) ? 1f : 0f;
            // this.MinX += leftRightAxis;

            // this.MinX = Math.Max(this.MinX, -1f);
        }
    }
}