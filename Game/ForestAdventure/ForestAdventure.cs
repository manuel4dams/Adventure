using ForestAdventure.Objects;
using Framework.Development.Objects;
using Framework.Objects;
using OpenTK;

namespace ForestAdventure
{
    public static class ForestAdventure
    {
        public static void Main()
        {
            // Game.instance.AddGameObject(new DebugGameObject());
            // Game.instance.AddGameObject(new DebugCollisionObjectMovable());
            // Game.instance.AddGameObject(new DebugCollisionObject());
            Game.instance.AddGameObject(new DebugMousePositionGameObject());
            AddBackground();
            AddPlatforms();
            AddClimbablePlatforms();
            Game.instance.AddGameObject(new Exit());
            Game.instance.AddGameObject(new Entrance());
            AddEnemies();
            Game.instance.AddGameObject(new Player());
            Game.instance.AddGameObject(new Camera(new Transform {scale = Vector2.One * 15f}, 1.6f));
            Game.instance.Run();
        }

        private static void AddBackground()
        {
            Game.instance.AddGameObject(new Background());
        }

        private static void AddPlatforms()
        {
            Game.instance.AddGameObject(new Platform(new Vector2(0f, -1f), 14.8f));
            Game.instance.AddGameObject(new Platform(new Vector2(10f, 2f), 4.4f));
            Game.instance.AddGameObject(new Platform(new Vector2(18f, 6), 4.4f));
            Game.instance.AddGameObject(new Platform(new Vector2(12f, 10f), 4.2f));
            Game.instance.AddGameObject(new Platform(new Vector2(16, 14f), 4.4f));
            Game.instance.AddGameObject(new Platform(new Vector2(35f, 15f), 14.4f));
            Game.instance.AddGameObject(new Platform(new Vector2(50f, 12f), 4.8f));
            Game.instance.AddGameObject(new Platform(new Vector2(57f, 6f), 4.2f));
            Game.instance.AddGameObject(new Platform(new Vector2(60f, 18f), 4.4f));
            Game.instance.AddGameObject(new Platform(new Vector2(62f, 25f), 4.4f));
            Game.instance.AddGameObject(new Platform(new Vector2(50f, 26f), 2f));
            Game.instance.AddGameObject(new Platform(new Vector2(36f, 27f), 14.3f));
            Game.instance.AddGameObject(new Platform(new Vector2(22f, 29f), 5.5f));
            Game.instance.AddGameObject(new Platform(new Vector2(16f, 35f), 4.1f));
            Game.instance.AddGameObject(new Platform(new Vector2(26f, 38f), 4.5f));
            Game.instance.AddGameObject(new Platform(new Vector2(40f, 40f), 4.8f));
        }

        private static void AddClimbablePlatforms()
        {
            Game.instance.AddGameObject(new ClimbablePlatform(new Vector2(15f, 5f), 12f));
        }

        private static void AddEnemies()
        {
            Game.instance.AddGameObject(new Enemy(new Vector2(35f, 16f), 28f, 42f));
            Game.instance.AddGameObject(new Enemy(new Vector2(36f, 28f), 29f, 43f));
        }
    }
}