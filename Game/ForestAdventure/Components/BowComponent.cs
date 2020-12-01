﻿using System;
using System.Collections.Generic;
using System.Linq;
using ForestAdventure.Objects;
using Framework.Interfaces;
using Framework.Objects;
using OpenTK;
using OpenTK.Input;

namespace ForestAdventure.Components
{
    public class BowComponent : IComponent, IUpdateable, IDrawable
    {
        private readonly List<Arrow> arrows = new List<Arrow>();

        public GameObject gameObject { get; }

        public BowComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public void Draw()
        {
            var drawables = arrows
                .SelectMany(arrow => arrow.components)
                .Select(component => component as IDrawable)
                .Where(drawable => drawable != null);
            foreach (var drawable in drawables)
                drawable.Draw();
        }

        public void Update(float deltaTime)
        {
            if (Mouse.GetState().IsButtonDown(MouseButton.Left)) ShootArow();

            var updateables = arrows
                .SelectMany(arrow => arrow.components)
                .Select(component => component as IUpdateable)
                .Where(updateable => updateable != null);
            foreach (var updateable in updateables) updateable.Update(deltaTime);
        }

        private void ShootArow()
        {
            // TODO get correct mouse position
            var dirX = Mouse.GetState().X / 1920f;
            var dirY = Mouse.GetState().Y / 1080f * -1f;
            // float dirX = OpenTK.Input.Mouse.GetState().X;
            // float dirY = OpenTK.Input.Mouse.GetState().Y * -1f;

            var magnitude = MathF.Sqrt(dirX * dirX + dirY * dirY);
            var arrow = new Arrow();
            var arrowComponent = new ArrowComponent(
                arrow,
                0.2f,
                new Vector2(dirX / magnitude, dirY / magnitude));

            arrow.transform.position = gameObject.transform.position;
            arrow.AddComponent(arrowComponent);
            arrows.Add(arrow);
        }
    }
}