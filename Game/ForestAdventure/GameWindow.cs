using System.Reflection;
using OpenTK;
using OpenTK.Input;

namespace ForestAdventure
{
    public class GameWindow : OpenTK.GameWindow
    {
        public static void Main()
        {
            var gameWindow = new GameWindow();
            var game = new Game();

            gameWindow.Title = Assembly.GetExecutingAssembly().GetName().Name;
            gameWindow.WindowState = WindowState.Maximized;

#if DEBUG
            gameWindow.WindowState = WindowState.Normal;
#endif

            gameWindow.UpdateFrame += (objectArgs, args) => game.Update();
            gameWindow.Resize += (objectArgs, args) => game.Resize(gameWindow.Width, gameWindow.Height);
            gameWindow.RenderFrame += (objectArgs, frameEventArgs) => game.Draw();
            gameWindow.RenderFrame += (objectArgs, frameEventArgs) => gameWindow.SwapBuffers();

            // start the game loop with 60Hz
            gameWindow.Run(60);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape)) Exit();

            base.OnUpdateFrame(e);
        }
    }
}