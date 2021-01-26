using System.Drawing;
using Framework.Collision.Collider;
using Framework.Development.Components;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using Framework.Util;
using OpenTK;

namespace ForestAdventure.Enemies
{
    public class Enemy : GameObject
    {
        public Enemy(
            Vector2 position,
            float movementBorderLeft,
            float movementBorderRight)
        {
            transform.position = position;

            var bodyBounds = new RectangleBounds(4f, 4f);
            var colliderBounds = new RectangleBounds(0f, -0.4f, 1.6f, 3.5f);

            AddComponent(new RectangleTextureRenderer(
                this,
                bodyBounds,
                Resources.Resources.Enemy,
                RenderScaleType.Crop,
                size: new Vector4(0f, 0f, 0.25f, 1f)));
            AddComponent(new RectangleColliderComponent(this, colliderBounds, true));
            AddComponent(new MovementNoInputComponent(this, movementBorderLeft, movementBorderRight));
            if (Debug.enabled)
            {
                AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bodyBounds, Color.GreenYellow));
                AddComponent(new DebugUnrotatedColliderEdgesComponent(this, colliderBounds));
            }
        }
    }
}