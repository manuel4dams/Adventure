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
        public GameEndingOverlay(Vector2 position, bool gameWon)
        {
            var textureBounds = new RectangleBounds(new Vector2(15f, 5f));
            var colorOverlayBounds = new RectangleBounds(new Vector2(200f, 200f));

            if (gameWon)
            {
                transform.position = position;
                AddComponent(new RectangleColorRenderer(this, colorOverlayBounds, Color.FromArgb(50, Color.Green)));
                AddComponent(new RectangleTextureRenderer(this, textureBounds, Resources.GameWon));
            }
            else
            {
                transform.position = position;
                AddComponent(new RectangleColorRenderer(this, colorOverlayBounds, Color.FromArgb(50, Color.Red)));
                AddComponent(new RectangleTextureRenderer(this, textureBounds, Resources.GameOver));
            }
            AddComponent(new CameraFollowObjectComponent(this));
        }

        public void Update(float deltaTime)
        {
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Key.Enter))
            {
                ForestAdventure.RestartLevel();
            }
        }
    }
}