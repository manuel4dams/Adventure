using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Level
{
    public class ForestBackground : GameObject
    {
        public ForestBackground(System.Drawing.Bitmap texture, float parallaxFactor)
        {
            var bounds = new RectangleBounds(96f, 54f);
            AddComponent(new RectangleTextureRenderer(this, bounds, texture));
            AddComponent(new Parallax(this, parallaxFactor));
        }
    }
}