using System.Reflection;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;

namespace ForestAdventure
{
    public class GameWindow : OpenTK.GameWindow
    {
        public static void Main()
        {
            GameWindow gameWindow = new GameWindow();
            Game game = new Game();

            gameWindow.Title = Assembly.GetExecutingAssembly().GetName().Name;
            gameWindow.WindowState = WindowState.Maximized;

            gameWindow.UpdateFrame += (objectArgs, args) => game.Update();
            gameWindow.Resize += (objectArgs, args) => game.Resize(gameWindow.Width, gameWindow.Height);
            gameWindow.RenderFrame += (objectArgs, frameEventArgs) => game.Draw();
            gameWindow.RenderFrame += (objectArgs, frameEventArgs) => gameWindow.SwapBuffers();

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