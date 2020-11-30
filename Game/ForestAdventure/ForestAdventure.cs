using ForestAdventure.Objects;
using Framework.Components;
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics;
using GameWindow = Framework.Objects.GameWindow;

namespace ForestAdventure
{
    public class ForestAdventure
    {
        private readonly Game game;

        public ForestAdventure()
        {
            game = new Game();
            AddBackground();
            AddPlatforms();
            game.AddGameObject(new Exit());
            game.AddGameObject(new Entrance());
            AddEnemies();
            game.AddGameObject(new Player());
            game.AddGameObject(new Camera(new Transform {scale = Vector2.One * 2f}, 1.6f));
        }

        public static void Main()
        {
            var forestAdventure = new ForestAdventure();
            forestAdventure.Run();
        }

        internal void Run()
        {
            new GameWindow(game);
        }

        private void AddBackground()
        {
            game.AddGameObject(new Background());
        }

        private void AddPlatforms()
        {
            game.AddGameObject(new Platform(new Vector2(-1f, -1f), 0.8f));
            game.AddGameObject(new Platform(new Vector2(-0.25f, -0.8f), 0.4f));
            game.AddGameObject(new Platform(new Vector2(0.4f, -0.6f), 0.4f));
            game.AddGameObject(new Platform(new Vector2(-0.7f, -0.6f), 0.2f));
            game.AddGameObject(new Platform(new Vector2(-0.25f, -0.4f), 0.4f));
            game.AddGameObject(new Platform(new Vector2(0.5f, -0.2f), 0.4f));
            game.AddGameObject(new Platform(new Vector2(-0.4f, 0f), 0.8f));
            game.AddGameObject(new Platform(new Vector2(-0.2f, 0.2f), 0.2f));
            game.AddGameObject(new Platform(new Vector2(-0.6f, 0.4f), 0.4f));
            game.AddGameObject(new Platform(new Vector2(0f, 0.6f), 0.4f));
            game.AddGameObject(new Platform(new Vector2(0.6f, 0.8f), 0.8f));
            game.AddGameObject(new Platform(new Vector2(-0.6f, -0.8f), 0.3f));
            game.AddGameObject(new Platform(new Vector2(1f, 1f), 2f));
            game.AddGameObject(new Platform(new Vector2(2f, 0.8f), 1.5f));
            game.AddGameObject(new Platform(new Vector2(1.5f, 0.6f), 1f));
            game.AddGameObject(new Platform(new Vector2(1f, 0.4f), 0.5f));
            game.AddGameObject(new Platform(new Vector2(3f, 1.2f), 0.4f));
            game.AddGameObject(new Platform(new Vector2(3.5f, 1.4f), 0.3f));
        }

        private void AddEnemies()
        {
            game.AddGameObject(new Enemy(new Vector2(0.45f, -0.6f), 0.22f, 0.58f));
            game.AddGameObject(new Enemy(new Vector2(-0.2f, 0f), -0.8f, 0f));
            game.AddGameObject(new Enemy(new Vector2(0.15f, 0.6f), -0.2f, 0.2f));
        }
    }
}