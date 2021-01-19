using Framework.Game;
using Framework.Interfaces;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Render
{
    public class Parallax : IComponent, IUpdateable
    {
        public GameObject gameObject { get; }
        private Vector2 startPosition = new Vector2(0f, 0f);
        private Transform.Transform target;
        private float parallaxFactor;

        public Parallax(GameObject gameObject, float parallaxFactor)
        {
            this.gameObject = gameObject;
            this.target = Camera.Camera.instance.transform;
            this.parallaxFactor = parallaxFactor;
            gameObject.transform.position = new Vector2(target.position.X, target.position.Y + 15f);
        }

        private Vector2 travel => target.position - startPosition;

        public void Update(float deltaTime)
        {
            gameObject.transform.position = startPosition + travel * parallaxFactor;
        }
    }
}
