using System.Reflection;
using ForestAdventure.View;
using OpenTK;
using OpenTK.Input;

namespace ForestAdventure
{
    public class Program
    {
        public static void Main()
        {
            GameWindow window = new GameWindow(1000, 1000);
            Camera camera = new Camera();
            Model.Model model = new Model.Model(camera);
            View.View view = new View.View(camera);
            window.WindowState = WindowState.Maximized;

            window.Title = Assembly.GetExecutingAssembly().GetName().Name;
            window.WindowState = WindowState.Normal;
            window.KeyDown += (s, a) =>
            {
                if (a.Key == Key.Escape)
                {
                    window.Close();
                }
            };

            window.UpdateFrame += (objectArgs, args) => model.Update((float) args.Time);
            window.Resize += (objectArgs, args) => view.Resize(window.Width, window.Height);
            window.RenderFrame += (objectArgs, frameEventArgs) => view.Draw(model);
            window.RenderFrame += (objectArgs, frameEventArgs) => window.SwapBuffers();

            // start the game loop with 60Hz
            window.Run(60);
        }
    }
}