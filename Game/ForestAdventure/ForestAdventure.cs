using System.Reflection;
using ForestAdventure.Enemies;
using ForestAdventure.Level;
using ForestAdventure.Platforms;
using ForestAdventure.Ropes;
using Framework.Camera;
using Framework.Game;
using Framework.Transform;
using OpenTK;

namespace ForestAdventure
{
    public static class ForestAdventure
    {
        private static Camera camera = new Camera(new Transform {scale = Vector2.One * 15f}, 1.6f);

        public static void Main()
        {
            Game.instance.title = Assembly.GetExecutingAssembly().GetName().Name;
            InitLevel();
            Game.instance.AddGameObject(camera);
            Game.instance.Run();
        }

        public static void GameEnded(Vector2 position, bool gameWon = false)
        {
            Game.instance.AddGameObject(new GameEndingOverlay(position, gameWon));
        }

        public static void RestartLevel()
        {
            Game.instance.ClearGameObjects();
            InitLevel();
        }

        private static void InitLevel()
        {
            Game.instance.AddGameObject(new ForestBackground());
            Game.instance.AddGameObject(new Tower());
            AddPlatforms();
            AddRopes();
            Game.instance.AddGameObject(new Exit());
            AddEnemies();
            Game.instance.AddGameObject(new Player());
            Game.instance.AddGameObject(camera);
        }

        private static void AddPlatforms()
        {
            // tower floor for now
            Game.instance.AddGameObject(new Platform(new Vector2(32f, 0f), 64f));

            // floor 1
            Game.instance.AddGameObject(new Platform(new Vector2(3f, 6f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(48f, 6f), 6f));
            // floor 2
            Game.instance.AddGameObject(new Platform(new Vector2(61f, 12f), 6f));
            // floor 3
            Game.instance.AddGameObject(new Platform(new Vector2(24f, 18f), 14f));
            Game.instance.AddGameObject(new Platform(new Vector2(48f, 18f), 6f));
            // floor 4
            Game.instance.AddGameObject(new Platform(new Vector2(3f, 24f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(61f, 24f), 6f));
            // floor 5
            Game.instance.AddGameObject(new Platform(new Vector2(16f, 30f), 6f));
            // floor 6
            Game.instance.AddGameObject(new Platform(new Vector2(3f, 36f), 6f));
            // floor 7
            Game.instance.AddGameObject(new Platform(new Vector2(16f, 42f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(40f, 42f), 14f));
            // floor 8
            Game.instance.AddGameObject(new Platform(new Vector2(61f, 48f), 6f));
            // floor 9
            Game.instance.AddGameObject(new Platform(new Vector2(48f, 54f), 6f));
            // floor 10
            Game.instance.AddGameObject(new Platform(new Vector2(61f, 60f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(24f, 60f), 14f));
            // floor 11
            Game.instance.AddGameObject(new Platform(new Vector2(16f, 66f), 6f));
            // floor 12
            Game.instance.AddGameObject(new Platform(new Vector2(3f, 72f), 6f));
            // floor 13
            Game.instance.AddGameObject(new Platform(new Vector2(16f, 78f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(48f, 78f), 14f));
            // floor 14
            Game.instance.AddGameObject(new Platform(new Vector2(3f, 84f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(61f, 84f), 6f));
            // floor 15
            Game.instance.AddGameObject(new Platform(new Vector2(48f, 90f), 6f));
            // floor 16
            Game.instance.AddGameObject(new Platform(new Vector2(61f, 96f), 6f));
        }

        private static void AddRopes()
        {
            Game.instance.AddGameObject(new VerticalRope(new Vector2(7f, 16f), 20f));
            // floor 10
            Game.instance.AddGameObject(new HorizontalRope(new Vector2(44f, 63f), 30f));
            // floor 13
            Game.instance.AddGameObject(new HorizontalRope(new Vector2(32f, 81f), 30f));
        }

        private static void AddEnemies()
        {
            // Ground floor
            Game.instance.AddGameObject(new Enemy(new Vector2(20f, 1.8f), 1f, 63f));
            Game.instance.AddGameObject(new Enemy(new Vector2(30f, 1.8f), 1f, 63f));
            Game.instance.AddGameObject(new Enemy(new Vector2(40f, 1.8f), 1f, 63f));
            // floor 3
            Game.instance.AddGameObject(new Enemy(new Vector2(24f, 19.8f), 18f, 30f));
            // floor 7
            Game.instance.AddGameObject(new Enemy(new Vector2(40f, 43.8f), 34f, 46f));
            // floor 10
            Game.instance.AddGameObject(new Enemy(new Vector2(24f, 61.8f), 18f, 30f));
            // floor 13
            Game.instance.AddGameObject(new Enemy(new Vector2(48f, 79.8f), 42f, 54f));
        }
    }
}