using System.Reflection;
using OpenTK;
using OpenTK.Input;

namespace Framework.Game
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
                // args.Time spikes on slower machines or when a lot of objects are spawned (lags),
                // this causes spikes in the deltaTime. when deltaTime spikes objects get boosted
                // to fast because the deltaTime is used to calculate the updating of objects,
                // which can cause clipping errors. To prevent this we skip the Frame when we get a deltaTime spike.
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