using ForestAdventure.Components;
using Framework.Development.Components;
using Framework.Game;
using Framework.Interfaces;
using OpenTK;
using OpenTK.Input;

namespace ForestAdventure.Objects.Develop
{
    public class EditLevelMovable : GameObject, IUpdateable
    {
        public EditLevelMovable()
        {
            transform.position = new Vector2(0f,0f);

            AddComponent(new DebugTransformPositionComponent(this, 1f));
            AddComponent(new CameraFollowObjectComponent(this));
        }

        public void Update(float deltaTime)
        {
            var keyboardState = Keyboard.GetState();
            var left = keyboardState.IsKeyDown(Key.Left) || keyboardState.IsKeyDown(Key.A) ? -1f : 0f;
            var right = keyboardState.IsKeyDown(Key.Right) || keyboardState.IsKeyDown(Key.D) ? 1f : 0f;
            var up = keyboardState.IsKeyDown(Key.Up) || keyboardState.IsKeyDown(Key.W) ? 1f : 0f;
            var down = keyboardState.IsKeyDown(Key.Down) || keyboardState.IsKeyDown(Key.S) ? -1f : 0f;

            transform.position += 50f * deltaTime * new Vector2(
                left + right,
                up + down);
        }
    }
}