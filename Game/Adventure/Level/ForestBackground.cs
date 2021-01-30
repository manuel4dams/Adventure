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
            var bounds = new RectangleBounds(384f, 54f);    // x-Wert ist vielfaches von 96
            RectangleTextureRenderer renderer = new RectangleTextureRenderer(this, bounds, texture, RenderScaleType.Tile);
            renderer.SetCropData(new OpenTK.Vector4(0f, 0f, 4f, 0.99f));    //der z-Wert ist die Zahl, mit der 96 multipliziert wurde
            AddComponent(renderer);
            AddComponent(new Parallax(this, parallaxFactor));
        }
    }
}