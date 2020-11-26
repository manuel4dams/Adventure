using System.Reflection;
using OpenTK;
using OpenTK.Input;

namespace Framework.Objects
{
    public class GameWindow : OpenTK.GameWindow
    {
        public static void Main()
        {
            var gameWindow = new GameWindow();
            var game = new Game();

            // TODO implement deltaTime
            gameWindow.Title = Assembly.GetExecutingAssembly().GetName().Name;
            gameWindow.WindowState = WindowState.Maximized;
            gameWindow.UpdateFrame += (objectArgs, args) => game.Update();
            gameWindow.Resize += (objectArgs, args) => game.Resize(gameWindow.Width, gameWindow.Height);
            gameWindow.RenderFrame += (objectArgs, frameEventArgs) => game.Draw();
            gameWindow.RenderFrame += (objectArgs, frameEventArgs) => gameWindow.SwapBuffers();

            // start the game loop with 60Hz
            gameWindow.Run(60);
        }

        // handel game exit with escape
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape)) Exit();

            base.OnUpdateFrame(e);
        }
    }
}