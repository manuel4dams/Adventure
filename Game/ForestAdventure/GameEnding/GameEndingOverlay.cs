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
        public GameEndingOverlay(GameObject gameObject, Vector2 position, Bitmap textur, RectangleBounds textureBounds)
        {
            Game.instance.RemoveGameObject(gameObject);

            transform.position = position;
            AddComponent(new RectangleTextureRenderer(this, textureBounds, textur));
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