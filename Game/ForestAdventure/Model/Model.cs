using System.Collections.Generic;

namespace ForestAdventure.Model
{
    public class Model : IModel
    {
        private readonly List<Object> platforms = new List<Object>();
        private readonly List<Enemy> enemies = new List<Enemy>();
        private readonly List<Object> arrows = new List<Object>();
        private readonly Player player;
        private readonly Object exit;

        public Model()
        {
            this.AddPlatforms();
            this.AddEnemies();
            this.exit = new Object(3.71f, 1.426f, 0.09f, 0.2f);
            this.player = new Player(-0.9f, -0.9f, 0.075f, 0.15f, this);
        }

        public IRectangle Player => this.player;

        public IEnumerable<IRectangle> Enemies => this.enemies;

        public IEnumerable<IRectangle> Platform => this.platforms;

        public IEnumerable<IRectangle> Arrows => this.arrows;

        public Object Exit => this.exit;

        public void Update(float frameTime)
        {
            if (player.UpdatePlayer(frameTime))
            {
                return;
            }

            foreach (var enemy in enemies)
            {
                enemy.UpdateEnemy(frameTime);
            }
        }

        internal void AddPlatforms()
        {
            const float platformThickness = 0.026f;
            this.platforms.Add(new Object(-1f, -1f, 0.8f, platformThickness));
            this.platforms.Add(new Object(-0.25f, -0.8f, 0.4f, platformThickness));
            this.platforms.Add(new Object(0.4f, -0.6f, 0.4f, platformThickness));
            this.platforms.Add(new Object(-0.7f, -0.6f, 0.2f, platformThickness));
            this.platforms.Add(new Object(-0.25f, -0.4f, 0.4f, platformThickness));
            this.platforms.Add(new Object(0.5f, -0.2f, 0.4f, platformThickness));
            this.platforms.Add(new Object(-0.4f, 0f, 0.8f, platformThickness));
            this.platforms.Add(new Object(-0.2f, 0.2f, 0.2f, platformThickness));
            this.platforms.Add(new Object(-0.6f, 0.4f, 0.4f, platformThickness));
            this.platforms.Add(new Object(0f, 0.6f, 0.4f, platformThickness));
            this.platforms.Add(new Object(0.6f, 0.8f, 0.8f, platformThickness));
            this.platforms.Add(new Object(-0.6f, -0.8f, 0.3f, platformThickness));
            this.platforms.Add(new Object(1f, 1f, 2f, platformThickness));
            this.platforms.Add(new Object(2f, 0.8f, 1.5f, platformThickness));
            this.platforms.Add(new Object(1.5f, 0.6f, 1f, platformThickness));
            this.platforms.Add(new Object(1f, 0.4f, 0.5f, platformThickness));
            this.platforms.Add(new Object(3f, 1.2f, 0.4f, platformThickness));
            this.platforms.Add(new Object(3.5f, 1.4f, 0.3f, platformThickness));
        }

        internal void AddEnemies()
        {
            // for now enemy movementBorderMinimal == <enemy platform> minX, movementBorderMaxmimal == <enemy platform> minX + <enemy platform> sizeX - <Enemy> sizeX
            this.enemies.Add(new Enemy(0.45f, -0.6f, 0.075f, 0.075f, 0.4f, 0.8f - 0.075f));
            this.enemies.Add(new Enemy(-0.2f, 0f, 0.075f, 0.075f, -0.4f, 0.4f - 0.075f));
            this.enemies.Add(new Enemy(0.15f, 0.6f, 0.075f, 0.075f, 0f, 0.4f - 0.075f));
        }
    }
}