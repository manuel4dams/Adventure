using System.Collections.Generic;
using System.Threading;

namespace ForrestAdventure.Model
{
    public class Model : IModel
    {
        private readonly List<Object> platforms = new List<Object>();
        private readonly List<Object> enemies = new List<Object>();
        private readonly List<Object> arrows = new List<Object>();
        private readonly Player player;

        public Model()
        {
            this.AddPlatforms();
            this.player = new Player(-0.9f, -0.9f, 0.075f, 0.15f, this);
        }

        public IRectangle Player => this.player;

        public IEnumerable<IRectangle> Enemy => this.enemies;

        public IEnumerable<IRectangle> Platform => this.platforms;

        public IEnumerable<IRectangle> Arrows => this.arrows;

        public void Update(float frameTime)
        {
            player.PlayerUpdate(frameTime);
        }

        internal void AddPlatforms()
        {
            this.platforms.Add(new Object(-1f, -1f, 0.8f, 0.05f));
            this.platforms.Add(new Object(-0.25f, -0.8f, 0.4f, 0.05f));
            this.platforms.Add(new Object(0.4f, -0.6f, 0.4f, 0.05f));
            this.platforms.Add(new Object(-0.7f, -0.6f, 0.2f, 0.05f));
            this.platforms.Add(new Object(-0.25f, -0.4f, 0.4f, 0.05f));
            this.platforms.Add(new Object(0.5f, -0.2f, 0.4f, 0.05f));
            this.platforms.Add(new Object(-0.4f, 0f, 0.8f, 0.05f));
            this.platforms.Add(new Object(-0.2f, 0.2f, 0.2f, 0.05f));
            this.platforms.Add(new Object(-0.6f, 0.4f, 0.4f, 0.05f));
            this.platforms.Add(new Object(0f, 0.6f, 0.4f, 0.05f));
            this.platforms.Add(new Object(0.6f, 0.8f, 0.8f, 0.05f));
        }
    }
}