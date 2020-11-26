using System.Collections.Generic;
using ForestAdventure.Objects;
using Framework.Objects;
using OpenTK.Graphics.OpenGL;

namespace ForestAdventure
{
    public class ForestAdventure
    {
        private Game game;

        public ForestAdventure()
        {
            game = new Game();

            AddPlatforms(0.026f);
            game.AddGameObject(new Exit(3.71f, 1.426f, 0.09f, 0.2f));
            game.AddGameObject(new Entrance(-1f, -1f, 0.1f, 0.3f));
            AddEnemies(0.075f, 0.075f);
            game.AddGameObject(new Player());
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

        private void AddPlatforms(float platformThickness)
        {
            game.AddGameObject(new Platform(-1f, -1f, 0.8f, platformThickness));
            game.AddGameObject(new Platform(-0.25f, -0.8f, 0.4f, platformThickness));
            game.AddGameObject(new Platform(0.4f, -0.6f, 0.4f, platformThickness));
            game.AddGameObject(new Platform(-0.7f, -0.6f, 0.2f, platformThickness));
            game.AddGameObject(new Platform(-0.25f, -0.4f, 0.4f, platformThickness));
            game.AddGameObject(new Platform(0.5f, -0.2f, 0.4f, platformThickness));
            game.AddGameObject(new Platform(-0.4f, 0f, 0.8f, platformThickness));
            game.AddGameObject(new Platform(-0.2f, 0.2f, 0.2f, platformThickness));
            game.AddGameObject(new Platform(-0.6f, 0.4f, 0.4f, platformThickness));
            game.AddGameObject(new Platform(0f, 0.6f, 0.4f, platformThickness));
            game.AddGameObject(new Platform(0.6f, 0.8f, 0.8f, platformThickness));
            game.AddGameObject(new Platform(-0.6f, -0.8f, 0.3f, platformThickness));
            game.AddGameObject(new Platform(1f, 1f, 2f, platformThickness));
            game.AddGameObject(new Platform(2f, 0.8f, 1.5f, platformThickness));
            game.AddGameObject(new Platform(1.5f, 0.6f, 1f, platformThickness));
            game.AddGameObject(new Platform(1f, 0.4f, 0.5f, platformThickness));
            game.AddGameObject(new Platform(3f, 1.2f, 0.4f, platformThickness));
            game.AddGameObject(new Platform(3.5f, 1.4f, 0.3f, platformThickness));
        }

        private void AddEnemies(float height, float width)
        {
            // TODO for now enemy movementBorderMinimal == <enemy platform> minX, movementBorderMaxmimal == <enemy platform> minX + <enemy platform> sizeX - <Enemy> sizeX
            game.AddGameObject(new Enemy(0.45f, -0.6f, width, height, 0.4f, 0.8f - 0.075f));
            game.AddGameObject(new Enemy(-0.2f, 0f, width, height, -0.4f, 0.4f - 0.075f));
            game.AddGameObject(new Enemy(0.15f, 0.6f, width, height, 0f, 0.4f - 0.075f));
        }
    }
}