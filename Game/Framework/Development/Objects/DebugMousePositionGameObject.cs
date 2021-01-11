using Framework.Development.Components;
using Framework.Game;
using Framework.Interfaces;

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
            transform.position = Camera.Camera.instance.MousePositionToWorld();
        }
    }
}