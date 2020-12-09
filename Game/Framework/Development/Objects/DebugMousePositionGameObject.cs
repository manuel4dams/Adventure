using Framework.Development.Components;
using Framework.Interfaces;
using Framework.Objects;

namespace Framework.Development.Objects
{
    public class DebugMousePositionGameObject : GameObject, IUpdateable
    {
        public DebugMousePositionGameObject()
        {
            AddComponent(new DebugTransformPositionComponent(this, 0.5f));
        }

        public void Update(float deltaTime)
        {
            transform.position = Camera.instance.MousePositionToWorld();
        }
    }
}