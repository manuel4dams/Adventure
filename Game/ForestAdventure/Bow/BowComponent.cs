using System;
using Framework.Camera;
using Framework.Game;
using Framework.Interfaces;
using OpenTK.Input;

namespace ForestAdventure.Bow
{
    public class BowComponent : IComponent, IUpdateable
    {
        private const float SHOT_COOLDOWN = 3f;

        private float shotTimer = SHOT_COOLDOWN;

        public GameObject gameObject { get; }

        public BowComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public void Update(float deltaTime)
        {
            shotTimer += deltaTime;
            if (Mouse.GetState().IsButtonDown(MouseButton.Left) && shotTimer >= SHOT_COOLDOWN)
            {
                ShootArrow();
                shotTimer = 0f;
            }
        }

        private void ShootArrow()
        {
            var mousePosition = Camera.instance.MousePositionToWorld();
            var force = mousePosition - gameObject.transform.position;
            force /= MathF.Sqrt((force.X * force.X) + (force.Y * force.Y));
            var arrow = new Arrow(force);
            arrow.transform.position = gameObject.transform.position;
            Game.instance.AddGameObject(arrow);
        }
    }
}