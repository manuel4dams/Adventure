using System;
using Framework.Camera;
using Framework.Game;
using Framework.Interfaces;
using Framework.Render;
using OpenTK;
using OpenTK.Input;

namespace ForestAdventure.Bow
{
    public class BowComponent : IComponent, IUpdateable
    {
        private const float SHOT_COOLDOWN = 1f;
        private const float SHOT_ANIMATION_COOLDOWN = 0.9f;

        private float shotTimer = SHOT_COOLDOWN;
        private RectangleTextureRenderer bowRenderer;

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
                bowRenderer.setCropData(new Vector4(0, 0, 0, 0));
                return;
            }
            var keyboardState = Keyboard.GetState();
            shotTimer += deltaTime;
            var mousePosition = Camera.instance.MousePositionToWorld();
            var pos = mousePosition - gameObject.transform.position;
            pos /= MathF.Sqrt((pos.X * pos.X) + (pos.Y * pos.Y));
            var angle = MathF.Atan2((pos.X), (pos.Y));
            var Y = 0f;
            var W = 0f;
            if (Mouse.GetState().IsButtonDown(MouseButton.Left) && shotTimer >= SHOT_COOLDOWN &&
                // check that non of the climbing keys is pressed
                !(keyboardState.IsKeyDown(Key.ShiftLeft) ||
                  keyboardState.IsKeyDown(Key.E) ||
                  Mouse.GetState().IsButtonDown(MouseButton.Right)))
            {
                ShootArrow();
                shotTimer = 0f;
            }

            if (angle > Math.PI * (7f / 8) || angle <= Math.PI * (-7f / 8))
            {
                Y = 0f;
                W = 0.2f;
            }
            else if (angle > Math.PI * (5f / 8))
            {
                Y = 0.2f;
                W = 0.4f;
            }
            else if (angle > Math.PI * (3f / 8))
            {
                Y = 0.8f;
                W = 1f;
            }
            else if (angle > Math.PI * (1f / 8))
            {
                Y = 0.4f;
                W = 0.6f;
            }
            else if (angle > Math.PI * (-1f / 8))
            {
                Y = 0.6f;
                W = 0.8f;
            }
            else if (angle > Math.PI * (-3f / 8))
            {
                Y = 0.4f;
                W = 0.6f;
            }
            else if (angle > Math.PI * (-5f / 8))
            {
                Y = 0.8f;
                W = 1f;
            }
            else if (angle > Math.PI * (-7f / 8))
            {
                Y = 0.2f;
                W = 0.4f;
            }


            if (angle >= 0)
            {
                if (shotTimer >= SHOT_ANIMATION_COOLDOWN)
                {
                    bowRenderer.setCropData(new Vector4(0f, Y, 0.33333f, W));
                }

                if (shotTimer >= 0 && shotTimer < (SHOT_ANIMATION_COOLDOWN / 2))
                {
                    bowRenderer.setCropData(new Vector4(0.33333f, Y, 0.66666f, W));
                }

                if (shotTimer >= (SHOT_ANIMATION_COOLDOWN / 2) && shotTimer < SHOT_ANIMATION_COOLDOWN)
                {
                    bowRenderer.setCropData(new Vector4(0.66666f, Y, 1f, W));
                }
            }
            else
            {
                if (shotTimer >= SHOT_ANIMATION_COOLDOWN)
                {
                    bowRenderer.setCropData(new Vector4(0.33333f, Y, 0f, W));
                }

                if (shotTimer >= 0 && shotTimer < (SHOT_ANIMATION_COOLDOWN / 2))
                {
                    bowRenderer.setCropData(new Vector4(0.66666f, Y, 0.33333f, W));
                }

                if (shotTimer >= (SHOT_ANIMATION_COOLDOWN / 2) && shotTimer < SHOT_ANIMATION_COOLDOWN)
                {
                    bowRenderer.setCropData(new Vector4(1f, Y, 0.66666f, W));
                }
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