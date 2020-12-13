using Framework.Interfaces;
using Framework.Objects;
using Framework.Util;
using OpenTK;

namespace ForestAdventure.Components
{
    public class CameraFollowObjectComponent : IComponent, IUpdateable
    {
        private const float SMOOTHNESS = 10f;

<<<<<<< HEAD
        public GameObject gameObject { get; }

=======
>>>>>>> master
        public CameraFollowObjectComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

<<<<<<< HEAD
        public void Update(float deltaTime)
        {
            Camera.instance.transform.position = Vector2.Lerp(
                Camera.instance.transform.position,
=======
        public GameObject gameObject { get; }

        public void Update(float deltaTime)
        {
            Camera.Instance.transform.position = Vector2.Lerp(
                Camera.Instance.transform.position,
>>>>>>> master
                gameObject.transform.position,
                LerpUtils.SmoothnessToLerp(SMOOTHNESS));
        }
    }
}