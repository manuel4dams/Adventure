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

            // TODO fix warning
            WindowState = WindowState.Normal;
            UpdateFrame += (objectArgs, args) =>
            {
                // TODO explain magic constant 0.5, comment
                if (args.Time >= 0.2)
                    return;

                game.Update((float) args.Time);
                game.CollisionCheck();
            };
            game.Resize(Width, Height);
            Resize += (objectArgs, args) => game.Resize(Width, Height);
            RenderFrame += (objectArgs, frameEventArgs) =>
            {
                game.Draw();
                SwapBuffers();
            };
        }

        // TODO cannot be in framework, remove and add to ForestAdventure
        // handel game exit with escape
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            if (Keyboard.GetState().IsKeyDown(Key.Escape))
                Exit();
        }
    }
}