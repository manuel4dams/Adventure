using Framework.Collision.Collider;
using Framework.Development.Components;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;
using OpenTK.Graphics;

namespace ForestAdventure.Objects
{
    public class Tower : GameObject
    {
        public Tower()
        {
            transform.position = new Vector2(-1f, -2f);

            var towerBottom = new RectangleBounds(new Vector2(33f, 1f), new Vector2(68f, 2f));
            AddComponent(new QuadRenderer(this, towerBottom, Color4.Gray));
            AddComponent(new RectangleColliderComponent(this, towerBottom, false, true));

            var leftWall = new RectangleBounds(new Vector2(0f, 52f), new Vector2(2f, 100f));
            AddComponent(new QuadRenderer(this, leftWall, Color4.Gray));
            AddComponent(new RectangleColliderComponent(this, leftWall, false, true));

            var rightWall = new RectangleBounds(new Vector2(66f, 52f), new Vector2(2f, 100f));
            AddComponent(new QuadRenderer(this, rightWall, Color4.Gray));
            AddComponent(new RectangleColliderComponent(this, rightWall, false, true));

            var towerRoof = new RectangleBounds(new Vector2(33f, 105), new Vector2(68f, 6f));
            AddComponent(new QuadRenderer(this, towerRoof, Color4.Gray));
            AddComponent(new RectangleColliderComponent(this, towerRoof, false, true));

#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this));
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, towerBottom));
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, leftWall));
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, rightWall));
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, towerRoof));
#endif
        }
    }
}