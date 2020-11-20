using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;

namespace ForestAdventure
{
    public class GameWindow : OpenTK.GameWindow
    {
        public GameWindow(int width, int height, string title)
            : base(width, height, GraphicsMode.Default, title)
        {
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }

            base.OnUpdateFrame(e);
        }
    }
}