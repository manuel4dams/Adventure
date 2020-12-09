using ForestAdventure.Objects;
using Framework.Interfaces;
using Framework.Objects;
using OpenTK.Input;

namespace ForestAdventure.Components
{
    public class BowComponent : IComponent, IUpdateable
    {
        private const float COOLDOWN = 1f;
        private float shotTimer = COOLDOWN;

        public GameObject gameObject { get; }

        public BowComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public void Update(float deltaTime)
        {
            shotTimer += deltaTime;
            if (Mouse.GetState().IsButtonDown(MouseButton.Left) && shotTimer >= COOLDOWN)
            {
                ShootArrow();
                shotTimer = 0f;
            }
        }

        private void ShootArrow()
        {
            var mousePosition = Camera.instance.MousePositionToWorld();
            var force = mousePosition - gameObject.transform.position;
            var arrow = new Arrow(force);
            arrow.transform.position = gameObject.transform.position;
            Game.instance.AddGameObject(arrow);
        }
    }
}