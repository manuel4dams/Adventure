using System.Reflection;
using OpenTK;

namespace ForestAdventure
{
    public class Program
    {
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
    }
}