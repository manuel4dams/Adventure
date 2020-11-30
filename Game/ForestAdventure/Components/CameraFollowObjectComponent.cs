﻿using Framework.Interfaces;
using Framework.Objects;
using OpenTK;

namespace ForestAdventure.Components
{
    public class CameraFollowObjectComponent : IComponent, IUpdateable
    {
        public GameObject gameObject { get; }

        public CameraFollowObjectComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public void Update(float deltaTime)
        {
            Camera.Instance.transform.position =
                new Vector2(gameObject.transform.position.X, gameObject.transform.position.Y);
        }
    }
}