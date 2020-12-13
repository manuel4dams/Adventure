using Framework.Components;
using Framework.Development.Components;
using Framework.Objects;
using OpenTK;

namespace ForestAdventure.Objects
{
    public class DebugCollisionObject : GameObject
    {
        public DebugCollisionObject()
        {
            transform.position = new Vector2(1f, 1f);

            var bodyBounds = new RectangleBounds(2f, 2f);
            AddComponent(new QuadRenderer(this, bodyBounds));
            AddComponent(new RectangleCollider(this, bodyBounds, false, true));
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bodyBounds));
            AddComponent(new DebugTransformPositionComponent(this));
        }
    }
}