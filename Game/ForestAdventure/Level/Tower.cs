using Framework.Collision.Collider;
using Framework.Development.Components;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;
using OpenTK.Graphics;

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
            var towerFloor = new RectangleBounds(new Vector2(33f, 52f), new Vector2(66f, 104f));
            AddComponent(new QuadRenderer(this, towerFloor, Color4.DarkGray));
        }

        private void AddTowerFloor()
        {
            var towerFloor = new RectangleBounds(new Vector2(33f, 1f), new Vector2(68f, 2f));
            AddComponent(new QuadRenderer(this, towerFloor, Color4.Gray));
            AddComponent(new RectangleColliderComponent(this, towerFloor, false, true));
#if DEBUG
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, towerFloor));
#endif
        }

        private void AddRightWall()
        {
            var leftWall = new RectangleBounds(new Vector2(0f, 52f), new Vector2(2f, 100f));
            AddComponent(new QuadRenderer(this, leftWall, Color4.Gray));
            AddComponent(new RectangleColliderComponent(this, leftWall, false, true));
#if DEBUG
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, leftWall));
#endif
        }

        private void AddLeftWall()
        {
            var rightWall = new RectangleBounds(new Vector2(66f, 52f), new Vector2(2f, 100f));
            AddComponent(new QuadRenderer(this, rightWall, Color4.Gray));
            AddComponent(new RectangleColliderComponent(this, rightWall, false, true));
#if DEBUG
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, rightWall));
#endif
        }

        private void AddTowerRoof()
        {
            var towerRoof = new RectangleBounds(new Vector2(33f, 105), new Vector2(68f, 6f));
            AddComponent(new QuadRenderer(this, towerRoof, Color4.Gray));
            AddComponent(new RectangleColliderComponent(this, towerRoof, false, true));
#if DEBUG
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, towerRoof));
#endif
        }
    }
}