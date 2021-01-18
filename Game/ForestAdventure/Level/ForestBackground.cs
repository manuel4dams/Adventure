using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Level
{
    public class ForestBackground : GameObject
    {
        public ForestBackground()
        {
            transform.position = new Vector2(100f, 45f);

            var bounds = new RectangleBounds(300f, 150f);
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.Resources.BackGround_v2));
        }
    }
}