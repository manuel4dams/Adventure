using System;
using System.Reflection;
using ForestAdventure.View;
using OpenTK;
using OpenTK.Input;

namespace ForestAdventure
{
    [Obsolete]
    public class Program
    {
        // public static void Main()
        public static void bla()
        {
            var window = new OpenTK.GameWindow(1000, 1000);
            var camera = new Camera();
            var model = new Model.Model(camera);
            var view = new View.View(camera);
            window.WindowState = WindowState.Maximized;

            window.Title = Assembly.GetExecutingAssembly().GetName().Name;
            window.WindowState = WindowState.Normal;
            window.KeyDown += (s, a) =>
            {
                if (a.Key == Key.Escape) window.Close();
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