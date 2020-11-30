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
            arrows.ForEach(X => X.Draw());
        }
    }
}
