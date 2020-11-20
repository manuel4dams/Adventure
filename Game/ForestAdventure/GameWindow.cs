using System.Reflection;
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

        public static void Main()
        {
            GameWindow gameWindow = new GameWindow(1000, 1000, Assembly.GetExecutingAssembly().GetName().Name);

            gameWindow.WindowState = WindowState.Maximized;
            // gameWindow.UpdateFrame += (objectArgs, args) => model.Update((float) args.Time);
            // gameWindow.Resize += (objectArgs, args) => view.Resize(window.Width, window.Height);
            // gameWindow.RenderFrame += (objectArgs, frameEventArgs) => view.Draw(model);
            // gameWindow.RenderFrame += (objectArgs, frameEventArgs) => window.SwapBuffers();

            // start the game loop with 60Hz
            gameWindow.Run(60);
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