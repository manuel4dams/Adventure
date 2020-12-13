using System;
<<<<<<< HEAD
using ForestAdventure.Objects;
using Framework.Interfaces;
using Framework.Objects;
=======
using System.Collections.Generic;
using System.Linq;
using ForestAdventure.Objects;
using Framework.Interfaces;
using Framework.Objects;
using OpenTK;
>>>>>>> master
using OpenTK.Input;

namespace ForestAdventure.Components
{
<<<<<<< HEAD
    public class BowComponent : IComponent, IUpdateable
    {
        private const float COOLDOWN = 1f;

        private float shotTimer = COOLDOWN;

        public GameObject gameObject { get; }

        public BowComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
=======
    public class BowComponent : IComponent, IUpdateable, IDrawable
    {
        private readonly List<Arrow> arrows = new List<Arrow>();

        public BowComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public GameObject gameObject { get; }

        public void Draw()
        {
            var drawables = arrows
                .SelectMany(arrow => arrow.components)
                .Select(component => component as IDrawable)
                .Where(drawable => drawable != null);
            foreach (var drawable in drawables)
            {
                drawable.Draw();
            }
>>>>>>> master
        }

        public void Update(float deltaTime)
        {
<<<<<<< HEAD
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
            force /= MathF.Sqrt((force.X * force.X) + (force.Y * force.Y));
            var arrow = new Arrow(force);
            arrow.transform.position = gameObject.transform.position;
            Game.instance.AddGameObject(arrow);
=======
            if (Mouse.GetState().IsButtonDown(MouseButton.Left))
            {
                ShootArow();
            }

            var updateables = arrows
                .SelectMany(arrow => arrow.components)
                .Select(component => component as IUpdateable)
                .Where(updateable => updateable != null);
            foreach (var updateable in updateables)
            {
                updateable.Update(deltaTime);
            }
        }

        private void ShootArow()
        {
            // TODO get correct mouse position
            // float dirX = OpenTK.Input.Mouse.GetState().X;
            // float dirY = OpenTK.Input.Mouse.GetState().Y * -1f;
            var dirX = Mouse.GetState().X / 1920f;
            var dirY = Mouse.GetState().Y / 1080f * -1f;

            var magnitude = MathF.Sqrt((dirX * dirX) + (dirY * dirY));
            var arrow = new Arrow();
#pragma warning disable 612
            var arrowComponent = new ArrowComponent(
#pragma warning restore 612
                arrow,
                2f,
                new Vector2(dirX / magnitude, dirY / magnitude));

            arrow.transform.position = gameObject.transform.position;
            arrow.AddComponent(arrowComponent);
            arrows.Add(arrow);
>>>>>>> master
        }
    }
}