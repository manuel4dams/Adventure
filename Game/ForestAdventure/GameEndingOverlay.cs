using System.Drawing;
using ForestAdventure.GameCamera;
using Framework.Game;
using Framework.Interfaces;
using Framework.Render;
using Framework.Shapes;
using OpenTK;
using OpenTK.Input;

namespace ForestAdventure
{
    public class GameEndingOverlay : GameObject, IUpdateable
    {
        public GameEndingOverlay(bool gameWon)
        {
            Color color;
            transform.position = new Vector2(3f, 8f);
            var bounds = new RectangleBounds(new Vector2(15f, 5f));

            if (gameWon)
            {
                color = Color.FromArgb(255, Color.Green);
            }
            else
            {
                color = Color.FromArgb(255, Color.Red);
            }

            AddComponent(new RectangleColorRenderer(this, bounds, color));
            AddComponent(new CameraFollowObjectComponent(this));
        }

        public void Update(float deltaTime)
        {
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Key.Space))
            {
                ForestAdventure.RestartLevel();
            }
        }
    }
}