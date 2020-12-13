﻿using Framework.Interfaces;
using Framework.Objects;
using Framework.Util;
using OpenTK;

namespace ForestAdventure.Components
{
    public class CameraFollowObjectComponent : IComponent, IUpdateable
    {
        private const float SMOOTHNESS = 10f;

        public GameObject gameObject { get; }

        public CameraFollowObjectComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public void Update(float deltaTime)
        {
            Camera.instance.transform.position = Vector2.Lerp(
                Camera.instance.transform.position,
                gameObject.transform.position,
                LerpUtils.SmoothnessToLerp(SMOOTHNESS));
        }
    }
}