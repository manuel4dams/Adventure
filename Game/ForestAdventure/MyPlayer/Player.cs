﻿using System;
using ForestAdventure.Bow;
using ForestAdventure.Enemies;
using ForestAdventure.GameCamera;
using ForestAdventure.Level;
using Framework.Collision.Collider;
using Framework.Game;
using Framework.Interfaces;
using Framework.Render;
using Framework.Shapes;
using OpenTK;

namespace ForestAdventure.MyPlayer
{
    public class Player : GameObject, ICollision
    {
        public Player()
        {
            transform.position = new Vector2(2f, 2f);

            var bodyBounds = new RectangleBounds(2f, 3f);
            AddComponent(new RectangleTextureRenderer(this, bodyBounds, Resources.PlayerRight));
            AddComponent(new RectangleColliderComponent(this, bodyBounds));
            AddComponent(new PlayerMovementComponent(this));
            AddComponent(new CameraFollowObjectComponent(this));
            AddComponent(new BowComponent(this));
        }

        public void OnCollision(ICollider other, Vector2 touchOffset)
        {
            if (other.gameObject is Enemy)
            {
                // TODO handle death
                transform.position = new Vector2(2f, 2f);
            }
            else if (other.gameObject is Exit)
            {
                // TODO won status
                Console.WriteLine("Game Won");
            }
        }
    }
}