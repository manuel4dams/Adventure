using Framework.Collision.Collider;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Level
{
    public class Tower : GameObject
    {
        public Tower()
        {
            transform.position = new Vector2(-1f, -2f);

            AddTowerBackground();
            AddTowerFloor();
            AddLeftWall();
            AddRightWall();
            AddTowerRoof();
        }

        private void AddTowerBackground()
        {
            var bounds = new RectangleBounds(new Vector2(33f, 52f), new Vector2(66f, 104f));
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.Resources.TowerBackground));
        }

        private void AddTowerFloor()
        {
            var bounds = new RectangleBounds(new Vector2(33f, 1f), new Vector2(68f, 2f));
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.Resources.BrickWall));
            AddComponent(new RectangleColliderComponent(this, bounds, false, true));
        }

        private void AddRightWall()
        {
            var bounds = new RectangleBounds(new Vector2(0f, 52f), new Vector2(2f, 100f));
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.Resources.BrickWall));
            AddComponent(new RectangleColliderComponent(this, bounds, false, true));
        }

        private void AddLeftWall()
        {
            var bounds = new RectangleBounds(new Vector2(66f, 52f), new Vector2(2f, 100f));
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.Resources.BrickWall));
            AddComponent(new RectangleColliderComponent(this, bounds, false, true));
        }

        private void AddTowerRoof()
        {
            var bounds = new RectangleBounds(new Vector2(33f, 105), new Vector2(68f, 6f));
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.Resources.BrickWall));
            AddComponent(new RectangleColliderComponent(this, bounds, false, true));
        }
    }
}