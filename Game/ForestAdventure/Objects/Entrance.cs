﻿using Framework.Components;
<<<<<<< HEAD
using Framework.Development.Components;
=======
>>>>>>> master
using Framework.Objects;
using OpenTK;
using OpenTK.Graphics;

namespace ForestAdventure.Objects
{
    public class Entrance : GameObject
    {
        public Entrance()
        {
            transform.position = new Vector2(0f, 4f);
<<<<<<< HEAD

            var bounds = new RectangleBounds(1.4f, 2.1f);
            AddComponent(new QuadRenderer(this, bounds, new Color4(13, 175, 184, 255)));
            AddComponent(new RectangleCollider(this, bounds, true));
#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bounds));
=======
            var bounds = new Bounds(1.4f, 2.1f);
            AddComponent(new RectangleDrawable(this, bounds, new Color4(13, 175, 184, 255)));
            AddComponent(new RectangleCollider(this, bounds, true));
#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
            AddComponent(new DebugColliderEdges(this, bounds));
>>>>>>> master
#endif
        }
    }
}