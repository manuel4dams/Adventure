using Framework.Interfaces;
using Framework.Objects;
using Framework.Util;
using OpenTK;

namespace ForestAdventure.Components
{
    public class CameraFollowObjectComponent : IComponent, IUpdateable
    {
        private const float SMOOTHNESS = 10f;

        public CameraFollowObjectComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public GameObject gameObject { get; }

        public void Update(float deltaTime)
        {
            Camera.Instance.transform.position = Vector2.Lerp(
                Camera.Instance.transform.position,
                gameObject.transform.position,
                LerpUtils.SmoothnessToLerp(SMOOTHNESS));
        }
    }
}