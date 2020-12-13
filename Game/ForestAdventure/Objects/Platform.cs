using Framework.Components;
<<<<<<< HEAD
using Framework.Development.Components;
=======
>>>>>>> master
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics;

namespace ForestAdventure.Objects
{
    public class Platform : GameObject
    {
        public Platform(Vector2 position, float length)
        {
            transform.position = position;
<<<<<<< HEAD

            var bounds = new RectangleBounds(length, 0.40f);
            AddComponent(new QuadRenderer(this, bounds, new Color4(77, 39, 3, 255)));
=======
            var bounds = new Bounds(length, 0.40f);
            AddComponent(new RectangleDrawable(this, bounds, new Color4(77, 39, 3, 255)));
>>>>>>> master
            AddComponent(new RectangleCollider(this, bounds, false, true));

#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
<<<<<<< HEAD
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bounds));
=======
            AddComponent(new DebugColliderEdges(this, bounds));
>>>>>>> master
#endif
        }
    }
}