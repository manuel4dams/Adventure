using System.Drawing;
using Framework.Game;
using Framework.Interfaces;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Bow
{
    public class EnemyHitOverlay : GameObject, IUpdateable
    {
        private float lifeTime = 0.02f;

        // TODO add better enemy hit feedback
        public EnemyHitOverlay()
        {
            var colorOverlayBounds = new RectangleBounds(new Vector2(200f, 200f));

            transform.position = Vector2.Zero;
            AddComponent(new RectangleColorRenderer(this, colorOverlayBounds, Color.FromArgb(50, Color.Black)));
        }

        public void Update(float deltaTime)
        {
            lifeTime -= deltaTime;
            if (lifeTime <= 0)
            {
                Game.instance.RemoveGameObject(this);
            }
        }
    }
}