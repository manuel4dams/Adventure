using ForestAdventure.Objects;
using Framework.Interfaces;
using Framework.Objects;
using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
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
            arrows.ForEach(X => X.Update(deltaTime));
        }

        private void ShootArow(float deltaTime)
        {
            float dirX = (OpenTK.Input.Mouse.GetCursorState().X / 1920f) - Camera.Instance.centerPosition.X - gameObject.transform.position.X;
            float dirY = (OpenTK.Input.Mouse.GetCursorState().Y / 1080f) - Camera.Instance.centerPosition.Y - gameObject.transform.position.Y;
            float magnitude = MathF.Sqrt((dirX * dirX) + (dirY * dirY));
            Arrow arrow = new Arrow();
            ArrowComponent arrowComponent = new ArrowComponent(arrow, 0.2f, new Vector2(dirX / magnitude, dirY / magnitude));
            arrow.transform.position = gameObject.transform.position;
            arrow.AddComponent(arrowComponent);
            arrows.Add(arrow);
        }

        public void Draw()
        {
            arrows.ForEach(X => X.Draw());
        }
    }
}
