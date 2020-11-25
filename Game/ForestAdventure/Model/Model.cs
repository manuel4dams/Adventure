using System;
using System.Collections.Generic;
using ForestAdventure.Helper;
using ForestAdventure.View;

namespace ForestAdventure.Model
{
    [Obsolete]
    public class Model : IModel
    {
        private readonly List<Object> arrows = new List<Object>();
        private readonly List<Enemy> enemies = new List<Enemy>();
        private readonly List<Object> platforms = new List<Object>();
        private readonly Player player;
        private readonly Camera camera;

        public Model(Camera camera)
        {
            this.camera = camera;
            AddPlatforms(0.026f);
            AddEnemies(0.075f, 0.075f);
            Exit = new Object(3.71f, 1.426f, 0.09f, 0.2f);
            player = new Player(-0.9f, -0.9f, 0.075f, 0.15f, this, this.camera);
        }

        public IRectangle Player => player;

        public IEnumerable<IRectangle> Enemies => enemies;

        public IEnumerable<IRectangle> Platform => platforms;

        public IEnumerable<IRectangle> Arrows => arrows;

        public Object Exit { get; }

        public void Update(float frameTime)
        {
            if (player.UpdatePlayer(frameTime)) return;

            foreach (var enemy in enemies) enemy.UpdateEnemy(frameTime);
        }

        internal void AddPlatforms(float platformThickness)
        {
            platforms.Add(new Object(-1f, -1f, 0.8f, platformThickness));
            platforms.Add(new Object(-0.25f, -0.8f, 0.4f, platformThickness));
            platforms.Add(new Object(0.4f, -0.6f, 0.4f, platformThickness));
            platforms.Add(new Object(-0.7f, -0.6f, 0.2f, platformThickness));
            platforms.Add(new Object(-0.25f, -0.4f, 0.4f, platformThickness));
            platforms.Add(new Object(0.5f, -0.2f, 0.4f, platformThickness));
            platforms.Add(new Object(-0.4f, 0f, 0.8f, platformThickness));
            platforms.Add(new Object(-0.2f, 0.2f, 0.2f, platformThickness));
            platforms.Add(new Object(-0.6f, 0.4f, 0.4f, platformThickness));
            platforms.Add(new Object(0f, 0.6f, 0.4f, platformThickness));
            platforms.Add(new Object(0.6f, 0.8f, 0.8f, platformThickness));
            platforms.Add(new Object(-0.6f, -0.8f, 0.3f, platformThickness));
            platforms.Add(new Object(1f, 1f, 2f, platformThickness));
            platforms.Add(new Object(2f, 0.8f, 1.5f, platformThickness));
            platforms.Add(new Object(1.5f, 0.6f, 1f, platformThickness));
            platforms.Add(new Object(1f, 0.4f, 0.5f, platformThickness));
            platforms.Add(new Object(3f, 1.2f, 0.4f, platformThickness));
            platforms.Add(new Object(3.5f, 1.4f, 0.3f, platformThickness));
        }

        private void AddEnemies(float height, float width)
        {
            // for now enemy movementBorderMinimal == <enemy platform> minX, movementBorderMaxmimal == <enemy platform> minX + <enemy platform> sizeX - <Enemy> sizeX
            enemies.Add(new Enemy(0.45f, -0.6f, width, height, 0.4f, 0.8f - 0.075f));
            enemies.Add(new Enemy(-0.2f, 0f, width, height, -0.4f, 0.4f - 0.075f));
            enemies.Add(new Enemy(0.15f, 0.6f, width, height, 0f, 0.4f - 0.075f));
        }
    }
}