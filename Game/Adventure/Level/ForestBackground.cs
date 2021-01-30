using System.Drawing;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;

namespace Adventure.Level
{
    public class ForestBackground : GameObject
    {
        public ForestBackground(Bitmap texture, float parallaxFactor)
        {
            // x-Wert ist vielfaches von 96
            var bounds = new RectangleBounds(384f, 54f);
            var renderer = new RectangleTextureRenderer(this, bounds, texture, RenderScaleType.Tile);
            // der z-Wert ist die Zahl, mit der 96 multipliziert wurde
            renderer.SetCropData(new OpenTK.Vector4(0f, 0f, 4f, 0.99f));
            AddComponent(renderer);
            AddComponent(new Parallax(this, parallaxFactor));
        }
    }
}