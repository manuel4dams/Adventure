using System;
using ForestAdventure.Interfaces;
using OpenTK.Input;

namespace ForestAdventure.Components
{
    public class CPlayerMovement : IMovable
    {
        private IGameObject gameObject;
        private KeyboardState keyboardState;

        public CPlayerMovement(IGameObject gameObject)
        {
            this.gameObject = gameObject;
            keyboardState = Keyboard.GetState();
        }

        public void Move()
        {
            var leftRightAxis = keyboardState.IsKeyDown(Key.Left) || keyboardState.IsKeyDown(Key.A) ? -1f :
                keyboardState.IsKeyDown(Key.Right) || keyboardState.IsKeyDown(Key.D) ? 1f : 0f;
            Console.WriteLine(leftRightAxis);
        }
    }
}