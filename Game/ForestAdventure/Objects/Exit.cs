using Framework.Components;
using Framework.Objects;
using OpenTK;

namespace ForestAdventure.Objects
{
    public class Exit : GameObject
    {
        public Exit()
        {
            transform.position = new Vector2(3.71f, 1.426f);
            var bounds = new Bounds(0.09f, 0.2f);
            AddComponent(new RectangleComponent(this, bounds));
        }
    }
}