using System.Drawing;
using ForestAdventure.GameCamera;
using Framework.Development.Components;
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

            var textureBounds = new RectangleBounds(new Vector2(15f, 5f));
            var colorOverlayBounds = new RectangleBounds(new Vector2(200f, 200f));
            transform.position = position;
            AddComponent(new RectangleColorRenderer(this, colorOverlayBounds, Color.FromArgb(50, Color.Green)));
            AddComponent(new RectangleTextureRenderer(this, textureBounds, Resources.Resources.GameWon));
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