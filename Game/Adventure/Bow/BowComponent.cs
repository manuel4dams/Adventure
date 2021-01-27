using System;
using Framework.Camera;
using Framework.Game;
using Framework.Interfaces;
using Framework.Render;
using Framework.Sound;
using OpenTK;
using OpenTK.Input;

namespace Adventure.Bow
{
    public class BowComponent : IComponent, IUpdateable
    {
        private const float SHOT_COOLDOWN = 1f;
        private const float SHOT_ANIMATION_COOLDOWN = 0.9f;

        private float shotTimer = SHOT_COOLDOWN;
        private RectangleTextureRenderer bowRenderer;
        private float y;
        private float w;
        private float angle;

        public GameObject gameObject { get; }
        public bool enabled;

        public BowComponent(GameObject gameObject)
        {
            this.gameObject = gameObject;
            bowRenderer = gameObject.GetComponent<RectangleTextureRenderer>(1) as RectangleTextureRenderer;
        }

        public void Update(float deltaTime)
        {
            if (!enabled)
            {
                bowRenderer.SetCropData(new Vector4(0, 0, 0, 0));
                return;
            }

            var keyboardState = Keyboard.GetState();
            shotTimer += deltaTime;
            var mousePosition = Camera.instance.MousePositionToWorld();
            var pos = mousePosition - gameObject.transform.position;
            pos /= MathF.Sqrt((pos.X * pos.X) + (pos.Y * pos.Y));
            angle = MathF.Atan2((pos.X), (pos.Y));

            if (Mouse.GetState().IsButtonDown(MouseButton.Left) && shotTimer >= SHOT_COOLDOWN &&
                // check that non of the climbing keys is pressed
                !(keyboardState.IsKeyDown(Key.ShiftLeft) ||
                  keyboardState.IsKeyDown(Key.E) ||
                  Mouse.GetState().IsButtonDown(MouseButton.Right)))
            {
                var bowShot = new Sound(Resources.Resources.Bow_shot);
                bowShot.Play();
                ShootArrow();
                shotTimer = 0f;
            }

            GetAimAngle();
            SetAnimation();
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

        private void GetAimAngle()
        {
            if (angle > Math.PI * (7f / 8) || angle <= Math.PI * (-7f / 8))
            {
                y = 0f;
                w = 0.2f;
            }
            else if (angle > Math.PI * (5f / 8))
            {
                y = 0.2f;
                w = 0.4f;
            }
            else if (angle > Math.PI * (3f / 8))
            {
                y = 0.8f;
                w = 1f;
            }
            else if (angle > Math.PI * (1f / 8))
            {
                y = 0.4f;
                w = 0.6f;
            }
            else if (angle > Math.PI * (-1f / 8))
            {
                y = 0.6f;
                w = 0.8f;
            }
            else if (angle > Math.PI * (-3f / 8))
            {
                y = 0.4f;
                w = 0.6f;
            }
            else if (angle > Math.PI * (-5f / 8))
            {
                y = 0.8f;
                w = 1f;
            }
            else if (angle > Math.PI * (-7f / 8))
            {
                y = 0.2f;
                w = 0.4f;
            }
        }

        private void SetAnimation()
        {
            if (angle >= 0)
            {
                if (shotTimer >= SHOT_ANIMATION_COOLDOWN)
                {
                    bowRenderer.SetCropData(new Vector4(0f, y, 0.33333f, w));
                }

                if (shotTimer >= 0 && shotTimer < (SHOT_ANIMATION_COOLDOWN / 2))
                {
                    bowRenderer.SetCropData(new Vector4(0.33333f, y, 0.66666f, w));
                }

                if (shotTimer >= (SHOT_ANIMATION_COOLDOWN / 2) && shotTimer < SHOT_ANIMATION_COOLDOWN)
                {
                    bowRenderer.SetCropData(new Vector4(0.66666f, y, 1f, w));
                }
            }
            else
            {
                if (shotTimer >= SHOT_ANIMATION_COOLDOWN)
                {
                    bowRenderer.SetCropData(new Vector4(0.33333f, y, 0f, w));
                }

                if (shotTimer >= 0 && shotTimer < (SHOT_ANIMATION_COOLDOWN / 2))
                {
                    bowRenderer.SetCropData(new Vector4(0.66666f, y, 0.33333f, w));
                }

                if (shotTimer >= (SHOT_ANIMATION_COOLDOWN / 2) && shotTimer < SHOT_ANIMATION_COOLDOWN)
                {
                    bowRenderer.SetCropData(new Vector4(1f, y, 0.66666f, w));
                }
            }
        }
    }
}