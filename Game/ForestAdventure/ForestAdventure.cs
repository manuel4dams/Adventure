using System.Reflection;
using ForestAdventure.Checkpoints;
using ForestAdventure.Develop;
using ForestAdventure.Enemies;
using ForestAdventure.Level;
using ForestAdventure.Platforms;
using ForestAdventure.PlayerComponents;
using ForestAdventure.Ropes;
using Framework.Camera;
using Framework.Game;
using Framework.Transform;
using OpenTK;

namespace ForestAdventure
{
    // TODO maybe add traps?
    // TODO add bigger and cooler level when hitboxes and textures are finished and all features are implemented
    public static class ForestAdventure
    {
        private static Camera camera = new Camera(new Transform {scale = Vector2.One * 20f}, 1.6f);

        public static void Main()
        {
            Game.instance.title = Assembly.GetExecutingAssembly().GetName().Name;
            InitLevel();
            Game.instance.AddGameObject(camera);
            Game.instance.Run();
        }

        public static void RestartLevel()
        {
            Game.instance.ClearGameObjects();
            InitLevel();
        }

        private static void InitLevel()
        {
            // Game.instance.AddGameObject(new ForestBackground());
            AddPlatforms();
            AddRopes();
            AddCheckpoints();
            Game.instance.AddGameObject(new Exit(new Vector2(60f, 97.8f)));
            AddEnemies();
            // Game.instance.AddGameObject(new Player(new Vector2(0f, 0f)));
            Game.instance.AddGameObject(new LevelMover());
            Game.instance.AddGameObject(camera);
            Game.instance.AddGameObject(new BottomLevelBorder(new Vector2(0f, -20f), 500));
        }

        private static void AddPlatforms()
        {
            Game.instance.AddGameObject(new Platform(new Vector2(0f, -1.5f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(12f, 2f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(24f, 3f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(36f, 4f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(48f, 6f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(61f, 12f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(24f, 18f), 14f));
            Game.instance.AddGameObject(new Platform(new Vector2(48f, 18f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(3f, 24f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(61f, 24f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(16f, 30f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(3f, 36f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(16f, 42f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(40f, 42f), 14f));
            Game.instance.AddGameObject(new Platform(new Vector2(61f, 48f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(48f, 54f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(61f, 60f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(24f, 60f), 14f));
            Game.instance.AddGameObject(new Platform(new Vector2(40f, 60f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(16f, 66f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(3f, 72f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(16f, 78f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(48f, 78f), 14f));
            Game.instance.AddGameObject(new Platform(new Vector2(29f, 82f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(3f, 84f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(61f, 84f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(48f, 90f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(61f, 96f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(72f, 74f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(81f, 80f), 14f));
            Game.instance.AddGameObject(new Platform(new Vector2(79f, 95), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(71f, 102), 14f));
        }

        private static void AddRopes()
        {
            Game.instance.AddGameObject(new VerticalRope(new Vector2(7f, 16f), 20f));
        }

        private static void AddCheckpoints()
        {
            // y = platformY + 1.5f
            Game.instance.AddGameObject(new Checkpoint(new Vector2(0f, 0f)));
        }

        private static void AddEnemies()
        {
            // values for 14f long Platform
            // enemyY = platformY +1.8f, movementBorderLeft = x - 6, movementBorderRight = x + 6
            Game.instance.AddGameObject(new Enemy(new Vector2(24f, 19.8f), 18f, 30f));
            Game.instance.AddGameObject(new Enemy(new Vector2(40f, 43.8f), 34f, 46f));
            Game.instance.AddGameObject(new Enemy(new Vector2(24f, 61.8f), 18f, 30f));
            Game.instance.AddGameObject(new Enemy(new Vector2(48f, 79.8f), 42f, 54f));
            Game.instance.AddGameObject(new Enemy(new Vector2(81f, 81.8f), 75f, 87f));
            Game.instance.AddGameObject(new Enemy(new Vector2(71f, 103.8f), 65f, 77f));
        }
    }
}