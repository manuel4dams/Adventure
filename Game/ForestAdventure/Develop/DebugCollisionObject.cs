using Framework.Collision.Collider;
using Framework.Development.Components;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Develop
{
    public class DebugCollisionObject : GameObject
    {
        public DebugCollisionObject()
        {
            transform.position = new Vector2(1f, 1f);
            var bodyBounds = new RectangleBounds(2f, 2f);
            AddComponent(new RectangleColorRenderer(this, bodyBounds));
            AddComponent(new RectangleColliderComponent(this, bodyBounds, false, true));
            AddComponent(new DebugColliderEdgesComponent(this, bodyBounds));
            AddComponent(new DebugTransformPositionComponent(this));
        }
    }
}