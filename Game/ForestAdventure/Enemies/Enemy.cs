﻿using Framework.Collision.Collider;
using Framework.Development.Components;
using Framework.Game;
using Framework.Render;
using Framework.Shapes;
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

            var bodyBounds = new RectangleBounds(0.5f, 2f);
            AddComponent(new RectangleTextureRenderer(this, bodyBounds, Resources.EnemyRight));
            AddComponent(new RectangleColliderComponent(this, bodyBounds, true));
            AddComponent(new MovementNoInputComponent(this, movementBorderLeft, movementBorderRight));
#if DEBUG
            AddComponent(new DebugTransformPositionComponent(this, 0.1f));
            AddComponent(new DebugUnrotatedColliderEdgesComponent(this, bodyBounds));
#endif
        }
    }
}