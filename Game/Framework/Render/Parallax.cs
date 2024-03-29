﻿using Framework.Game;
using Framework.Interfaces;
using OpenTK;

namespace Framework.Render
{
    public class Parallax : IComponent, IUpdateable
    {
        public GameObject gameObject { get; }
        private Vector2 startPosition = new Vector2(0f, 15f);
        private Transform.Transform target;
        private float parallaxFactor;

        public Parallax(GameObject gameObject, float parallaxFactor)
        {
            this.gameObject = gameObject;
            target = Camera.Camera.instance.transform;
            this.parallaxFactor = parallaxFactor;
            gameObject.transform.position = new Vector2(target.position.X, target.position.Y);
        }

        private Vector2 travel => target.position - startPosition;

        public void Update(float deltaTime)
        {
            gameObject.transform.position = startPosition + travel * parallaxFactor;
        }
    }
}