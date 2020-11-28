using System.Reflection;
using OpenTK;
using OpenTK.Input;

namespace Framework.Objects
{
    public class GameWindow : OpenTK.GameWindow
    {
        public GameWindow(Game game)
        {
            Title = Assembly.GetExecutingAssembly().GetName().Name;
            // TODO
            WindowState = WindowState.Maximized;
            UpdateFrame += (objectArgs, args) =>
            {
                game.Update((float) args.Time);
                game.CollisionCheck();
            };
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