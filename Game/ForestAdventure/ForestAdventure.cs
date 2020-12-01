using ForestAdventure.Objects;
using Framework.Objects;
using OpenTK;
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
            game.AddGameObject(new Camera(new Transform {scale = Vector2.One * 10f}, 1.6f));
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
            game.AddGameObject(new Platform(new Vector2(0f, -1f), 14.8f));
            game.AddGameObject(new Platform(new Vector2(10f, 2f), 4.4f));
            game.AddGameObject(new Platform(new Vector2(18f, 6), 4.4f));
            game.AddGameObject(new Platform(new Vector2(12f, 10f), 4.2f));
            game.AddGameObject(new Platform(new Vector2(16, 14f), 4.4f));
            game.AddGameObject(new Platform(new Vector2(35f, 15f), 14.4f));
            game.AddGameObject(new Platform(new Vector2(50f, 12f), 4.8f));
            game.AddGameObject(new Platform(new Vector2(57f, 6f), 4.2f));
            game.AddGameObject(new Platform(new Vector2(60f, 18f), 4.4f));
            game.AddGameObject(new Platform(new Vector2(62f, 25f), 4.4f));
            game.AddGameObject(new Platform(new Vector2(50f, 26f), 2f));
            game.AddGameObject(new Platform(new Vector2(36f, 27f), 14.3f));
            game.AddGameObject(new Platform(new Vector2(22f, 29f), 5.5f));
            game.AddGameObject(new Platform(new Vector2(16f, 35f), 4.1f));
            game.AddGameObject(new Platform(new Vector2(26f, 38f), 4.5f));
            game.AddGameObject(new Platform(new Vector2(40f, 40f), 4.8f));
        }

        private void AddEnemies()
        {
            game.AddGameObject(new Enemy(new Vector2(35f, 16f), 28f, 42f));
            game.AddGameObject(new Enemy(new Vector2(36f, 28f), 29f, 43f));
        }
    }
}