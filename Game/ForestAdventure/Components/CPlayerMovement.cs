using System;
using ForestAdventure.Helper;
using ForestAdventure.Interfaces;
using OpenTK.Input;

namespace ForestAdventure.Components
{
    public class CPlayerMovement : IMovable
    {
        private ObjectData objectData;

        public CPlayerMovement(ObjectData objectData)
        {
            this.objectData = objectData;
        }

        public void Move()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            float leftRightAxis = keyboardState.IsKeyDown(Key.Left) || keyboardState.IsKeyDown(Key.A) ? -0.1f :
                keyboardState.IsKeyDown(Key.Right) || keyboardState.IsKeyDown(Key.D) ? 0.1f : 0f;

            objectData.MinX += leftRightAxis;
            objectData.MinX = Math.Max(objectData.MinX, -1f);
        }
    }
}