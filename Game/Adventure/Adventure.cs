using System.Reflection;
using Adventure.Checkpoints;
using Adventure.Develop;
using Adventure.Enemies;
using Adventure.Level;
using Adventure.Platforms;
using Adventure.Ropes;
using Adventure.Traps;
using Adventure.PlayerComponents;
using Framework.Camera;
using Framework.Game;
using Framework.Sound;
using Framework.Transform;
using OpenTK;

namespace Adventure
{
    // TODO
    // Partikel bei gegner tod
    //
    // beim klettern kann man daneben greifen, (eine textur wird zuspät upgedated?)
    //
    // Level muss größer werden!
    public static class Adventure
    {
        private static Camera camera = new Camera(new Transform {scale = Vector2.One * 20f}, 1.6f);

        public static void Main()
        {
            Game.instance.title = Assembly.GetExecutingAssembly().GetName().Name;
            InitLevel();
            var sound = new Sound(Resources.Resources.Ambient_DutchForest, true);
            sound.Play();

            Game.instance.Run();
        }

        public static void RestartLevel()
        {
            Game.instance.ClearGameObjects();
            InitLevel();
        }

        private static void InitLevel()
        {
            Game.instance.AddGameObject(camera);
            AddBackground();
            AddRopes();
            AddPlatforms();
            AddCheckpoints();
            Game.instance.AddGameObject(new Exit(new Vector2(214f, 62.2f)));
            AddTraps();
            AddEnemies();
            Game.instance.AddGameObject(new Player(new Vector2(0f, 0f)));
            AddLevelBorders();
        }

        private static void AddBackground()
        {
            Game.instance.AddGameObject(new ForestBackground(Resources.Resources.BackGround_v2_0, 1f));
            Game.instance.AddGameObject(new ForestBackground(Resources.Resources.BackGround_v2_1, 0.95f));
            Game.instance.AddGameObject(new ForestBackground(Resources.Resources.BackGround_v2_2, 0.9f));
            Game.instance.AddGameObject(new ForestBackground(Resources.Resources.BackGround_v2_3, 0.75f));
        }

        private static void AddPlatforms()
        {
            Game.instance.AddGameObject(new Platform(new Vector2(0f, -1.5f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(7f, 26f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(11f, 18f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(20f, 23f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(-4f, 41f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(11f, 58f), 14f));
            Game.instance.AddGameObject(new Platform(new Vector2(5f, 46f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(-4f, 52f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(-8f, 58f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(33f, 58f), 14f));
            Game.instance.AddGameObject(new Platform(new Vector2(54f, 58f), 14f));
            Game.instance.AddGameObject(new Platform(new Vector2(72f, 62f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(85f, 68f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(72f, 74f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(100f, 80f), 40f));
            Game.instance.AddGameObject(new Platform(new Vector2(100f, 90f), 40f));
            Game.instance.AddGameObject(new Platform(new Vector2(130f, 76f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(145f, 76f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(160f, 76f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(180f, 76f), 14f));
            Game.instance.AddGameObject(new Platform(new Vector2(195f, 90f), 6f));
            Game.instance.AddGameObject(new Platform(new Vector2(200f, 56f), 14f));
            Game.instance.AddGameObject(new Platform(new Vector2(214f, 60f), 6f));

            // Debug-Platform
            Game.instance.AddGameObject(new Platform(new Vector2(14f, 0f), 14f));
        }

        private static void AddRopes()
        {
            Game.instance.AddGameObject(new VerticalRope(new Vector2(7f, 13f), 26f));
            Game.instance.AddGameObject(new VerticalRope(new Vector2(-8f, 43f), 30f));
            Game.instance.AddGameObject(new VerticalRope(new Vector2(195f, 76f), 28f));
        }

        private static void AddCheckpoints()
        {
            // y = platformY + 2.2f
            Game.instance.AddGameObject(new Checkpoint(new Vector2(0f, 0.7f)));
            Game.instance.AddGameObject(new Checkpoint(new Vector2(-8f, 60.2f)));
            Game.instance.AddGameObject(new Checkpoint(new Vector2(72f, 76.2f)));
            Game.instance.AddGameObject(new Checkpoint(new Vector2(130f, 78.2f)));
        }

        private static void AddEnemies()
        {
            // values for 14f long Platform
            // enemyY = platformY +2.2f, movementBorderLeft = x - 6, movementBorderRight = x + 6
            Game.instance.AddGameObject(new Enemy(new Vector2(11f, 60.2f), 5f, 17f));
            Game.instance.AddGameObject(new Enemy(new Vector2(33f, 60.2f), 27f, 39f));
            Game.instance.AddGameObject(new Enemy(new Vector2(54f, 60.2f), 48f, 60f));
            Game.instance.AddGameObject(new Enemy(new Vector2(180f, 78.2f), 174f, 186f));
            Game.instance.AddGameObject(new Enemy(new Vector2(200f, 58.2f), 194f, 206f));

            // Debug-Enemy
            Game.instance.AddGameObject(new Enemy(new Vector2(14f, 2.2f), 8f, 20f));
        }

        private static void AddTraps()
        {
            Game.instance.AddGameObject(new HorizontalMovingTrap(new Vector2(86f, 80.5f), 84f, 90f));
            Game.instance.AddGameObject(new VerticalMovingTrap(new Vector2(92f, 87f), 80.5f, 89.5f));
            Game.instance.AddGameObject(new HorizontalMovingTrap(new Vector2(96f, 80.5f), 94f, 100f));
            Game.instance.AddGameObject(new VerticalMovingTrap(new Vector2(105f, 81f), 80.5f, 89.5f));
            Game.instance.AddGameObject(new HorizontalMovingTrap(new Vector2(116f, 80.5f), 114f, 118f));
            Game.instance.AddGameObject(new VerticalMovingTrap(new Vector2(153f, 88f), 74f, 88f));
            Game.instance.AddGameObject(new HorizontalMovingTrap(new Vector2(160f, 76.5f), 157f, 163f));
            Game.instance.AddGameObject(new VerticalMovingTrap(new Vector2(168f, 84f), 74f, 88f));
            Game.instance.AddGameObject(new HorizontalMovingTrap(new Vector2(194f, 74f), 190f, 198f));
            Game.instance.AddGameObject(new HorizontalMovingTrap(new Vector2(194f, 68f), 190f, 198f));
        }

        private static void AddLevelBorders()
        {
            Game.instance.AddGameObject(new BottomLevelBorder(new Vector2(107f, -12f), 500));
        }
    }
}