using System.Drawing;
using ForestAdventure.GameCamera;
using Framework.Game;
using Framework.Interfaces;
using Framework.Render;
using Framework.Shapes;
using OpenTK;
using OpenTK.Input;

namespace ForestAdventure.GameEnding
{
    public class GameEndingOverlay : GameObject, IUpdateable
    {
        public GameEndingOverlay(GameObject gameObject, Vector2 position)
        {
            Game.instance.RemoveGameObject(gameObject);

            var textureBoundsVictory = new RectangleBounds(0f, 5f,15f, 5f);
            var textureBoundsStartNewGame = new RectangleBounds(30f, 2.5f);
            var colorOverlayBounds = new RectangleBounds(new Vector2(200f, 200f));
            transform.position = position;
            AddComponent(new RectangleColorRenderer(this, colorOverlayBounds, Color.FromArgb(80, Color.Green)));
            AddComponent(new RectangleTextureRenderer(this, textureBoundsVictory, Resources.Resources.Victory));
            AddComponent(new RectangleTextureRenderer(this, textureBoundsStartNewGame, Resources.Resources.Endscreen));
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