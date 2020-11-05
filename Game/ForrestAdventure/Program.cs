using System;
using System.Reflection;
using OpenTK;
using OpenTK.Input;

namespace ForrestAdventure
{
    public class Program
    {
        public static void Main()
        {
            GameWindow window = new GameWindow();
            Model.Model model = new Model.Model();
            View.View view = new View.View();
            window.WindowState = WindowState.Maximized;

            window.Title = Assembly.GetExecutingAssembly().GetName().Name;
            window.KeyDown += (s, a) =>
            {
                if (a.Key == Key.Escape)
                {
                    window.Close();
                }
            };
#if DEBUG
            // DEBUG ONLY get mouse coords on click
            window.MouseDown += (s, e) => { Console.WriteLine("x:" + e.X + "y:" + e.Y); };
#endif
            window.UpdateFrame += (objectArgs, args) => model.Update((float) args.Time);
            window.Resize += (objectArgs, args) => view.Resize(window.Width, window.Height);
            window.RenderFrame += (objectArgs, frameEventArgs) => view.Draw(model);
            window.RenderFrame += (objectArgs, frameEventArgs) => window.SwapBuffers();

            // start the game loop
            window.Run();
        }
    }
}