using ForestAdventure.Objects;
using Framework.Interfaces;
using Framework.Objects;
using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForestAdventure.Components
{
    public class BowComponent : IUpdateable, IDrawable
    {
        public BowComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public GameObject gameObject { get; }

        List<Arrow> arrows = new List<Arrow>();

        public void Update(float deltaTime)
        {
            if (OpenTK.Input.Mouse.GetState().IsButtonDown(MouseButton.Left))
            {
                ShootArow(deltaTime);
            }
            // TODO JAN
            // arrows.ForEach(X => X.Update(deltaTime));
            var updateables = arrows
                .SelectMany(arrows => arrows.components)
                .Select(component => component as IUpdateable)
                .Where(updateable => updateable != null);
            foreach (var updateable in updateables)
            {
                updateable.Update(deltaTime);
            }
        }

        private void ShootArow(float deltaTime)
        {
            float dirX = Mouse.GetState().X / 1920f;
            float dirY = (Mouse.GetState().Y / 1080f) * -1f;
            //float dirX = OpenTK.Input.Mouse.GetState().X;
            //float dirY = OpenTK.Input.Mouse.GetState().Y * -1f;
            float magnitude = MathF.Sqrt((dirX * dirX) + (dirY * dirY));
            Arrow arrow = new Arrow();
            ArrowComponent arrowComponent = new ArrowComponent(arrow, 0.2f, new Vector2(dirX / magnitude, dirY / magnitude));
            arrow.transform.position = gameObject.transform.position;
            arrow.AddComponent(arrowComponent);
            arrows.Add(arrow);
        }

        public void Draw()
        {
            //TODO JAN
            // arrows.ForEach(X => X.Draw());
            var drawables = arrows
                .SelectMany(arrows => arrows.components)
                .Select(component => component as IDrawable)
                .Where(drawable => drawable != null);
            foreach (var drawable in drawables)
                drawable.Draw();
        }
    }
}
