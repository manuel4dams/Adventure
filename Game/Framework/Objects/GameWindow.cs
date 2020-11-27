using System.Reflection;
using OpenTK;
using OpenTK.Input;

namespace Framework.Objects
{
    public class GameWindow : OpenTK.GameWindow
    {
        public GameWindow(Game game)
        {
            // TODO implement deltaTime
            Title = Assembly.GetExecutingAssembly().GetName().Name;
            WindowState = WindowState.Maximized;
            UpdateFrame += (objectArgs, args) => game.Update((float) args.Time);
            Resize += (objectArgs, args) => game.Resize(Width, Height);
            RenderFrame += (objectArgs, frameEventArgs) => game.Draw();
            RenderFrame += (objectArgs, frameEventArgs) => SwapBuffers();

            // start the game loop with 60Hz
            Run(60);
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