using Framework.Collision.Collider;
using Framework.Development.Components;
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

#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this));
#endif
        }

        private void AddTowerBackground()
        {
            var bounds = new RectangleBounds(new Vector2(33f, 52f), new Vector2(66f, 104f));
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.TowerBackground));
        }

        private void AddTowerFloor()
        {
            var bounds = new RectangleBounds(new Vector2(33f, 1f), new Vector2(68f, 2f));
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.BrickWall));
            AddComponent(new RectangleColliderComponent(this, bounds, false, true));
#if DEBUG
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bounds));
#endif
        }

        private void AddRightWall()
        {
            var bounds = new RectangleBounds(new Vector2(0f, 52f), new Vector2(2f, 100f));
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.BrickWall));
            AddComponent(new RectangleColliderComponent(this, bounds, false, true));
#if DEBUG
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bounds));
#endif
        }

        private void AddLeftWall()
        {
            var bounds = new RectangleBounds(new Vector2(66f, 52f), new Vector2(2f, 100f));
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.BrickWall));
            AddComponent(new RectangleColliderComponent(this, bounds, false, true));
#if DEBUG
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bounds));
#endif
        }

        private void AddTowerRoof()
        {
            var bounds = new RectangleBounds(new Vector2(33f, 105), new Vector2(68f, 6f));
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.BrickWall));
            AddComponent(new RectangleColliderComponent(this, bounds, false, true));
#if DEBUG
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bounds));
#endif
        }
    }
}