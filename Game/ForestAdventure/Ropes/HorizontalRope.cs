﻿using Framework.Collision.Collider;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.Ropes
{
    public class HorizontalRope : GameObject
    {
        public HorizontalRope(Vector2 position, float length)
        {
            transform.position = position;

            var bounds = new RectangleBounds(length, 0.1f);
            AddComponent(new RectangleTextureRenderer(this, bounds, Resources.Rope));
            AddComponent(new RectangleColliderComponent(this, bounds, true, true));
        }
    }
}