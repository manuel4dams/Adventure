using System.Drawing;
using Framework.Collision.Collider;
using Framework.Development.Components;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using Framework.Util;
using OpenTK;

namespace ForestAdventure.Platforms
{
    public class Platform : GameObject
    {
        public Platform(Vector2 position, float length)
        {
            transform.position = position;

            var bounds = new RectangleBounds(length, 0.5f);
            var textureRenderer =
                new RectangleTextureRenderer(this, bounds, Resources.Resources.Platform, RenderScaleType.Tile);
            AddComponent(textureRenderer);
            AddComponent(new RectangleColliderComponent(this, bounds, false, true));
            textureRenderer.SetCropData(new Vector4(0f, 0.71875f, length / 2f, 1f));
            if (Debug.enabled)
            {
                AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bounds, Color.GreenYellow));
                AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bounds));
            }
        }
    }
}