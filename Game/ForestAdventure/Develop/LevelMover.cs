using System;
using ForestAdventure.GameCamera;
using Framework.Development.Components;
using Framework.Game;
using Framework.Interfaces;
using OpenTK;
using OpenTK.Input;

namespace ForestAdventure.Develop
{
    public class LevelMover : GameObject, IUpdateable
    {
        public LevelMover()
        {
            transform.position = new Vector2(0, 0);
            AddComponent(new DebugTransformPositionComponent(this));
            AddComponent(new CameraFollowObjectComponent(this));
        }

        public void Update(float deltaTime)
        {
            var keyboardState = Keyboard.GetState();
            var left = keyboardState.IsKeyDown(Key.Left) || keyboardState.IsKeyDown(Key.A) ? -2f : 0f;
            var right = keyboardState.IsKeyDown(Key.Right) || keyboardState.IsKeyDown(Key.D) ? 2f : 0f;
            var up = keyboardState.IsKeyDown(Key.Up) || keyboardState.IsKeyDown(Key.W) ? 2f : 0f;
            var down = keyboardState.IsKeyDown(Key.Down) || keyboardState.IsKeyDown(Key.S) ? -2f : 0f;

            transform.position += 10f * deltaTime * new Vector2(
                left + right,
                up + down);
            Console.WriteLine(transform.position);
        }
    }
}