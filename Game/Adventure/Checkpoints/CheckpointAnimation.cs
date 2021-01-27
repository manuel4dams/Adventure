using Framework.Game;
using Framework.Interfaces;
using Framework.Render;
using OpenTK;

namespace Adventure.Checkpoints
{
    class CheckpointAnimation : IComponent, IUpdateable
    {
        private const float ANIMATION_TIMER_RESET = 0.1f;

        private RectangleTextureRenderer checkpointRenderer;
        private int animationFrame = 1;
        private float animationTimer = 0;
        private bool active;
        public GameObject gameObject { get; }

        public CheckpointAnimation(GameObject gameObject)
        {
            this.gameObject = gameObject;
            checkpointRenderer = gameObject.GetComponent<RectangleTextureRenderer>(0) as RectangleTextureRenderer;
        }

        public void Update(float deltaTime)
        {
            if (!active)
            {
                if (animationFrame != 0)
                {
                    checkpointRenderer.SetCropData(new Vector4(0f, 0f, 0.2f, 0.99f));
                    animationFrame = 0;
                }
            }
            else
            {
                if (animationFrame != 5)
                {
                    if (animationTimer <= 0)
                    {
                        checkpointRenderer.SetCropData(new Vector4(0.2f * animationFrame, 0f,
                            0.2f * (animationFrame + 1f), 0.99f));
                        animationFrame++;
                        animationTimer = ANIMATION_TIMER_RESET;
                    }

                    animationTimer -= deltaTime;
                }
            }
        }

        public void setActive(bool active)
        {
            this.active = active;
        }
    }
}