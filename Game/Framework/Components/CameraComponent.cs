using System;
using Framework.Interfaces;
using Framework.Objects;
using OpenTK;

namespace Framework.Components
{
    public class CameraComponent : ICameraUpdate
    {
        public CameraComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public void UpdateCamera()
        {
            Camera.Instance.centerPosition =
                new Vector2(gameObject.transform.position.X, gameObject.transform.position.Y);
        }

        public GameObject gameObject { get; }
    }
}