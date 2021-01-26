﻿using System;
using System.Drawing;
using ForestAdventure.Checkpoints;
using ForestAdventure.Enemies;
using ForestAdventure.Level;
using ForestAdventure.Platforms;
using ForestAdventure.PlayerComponents;
using ForestAdventure.Ropes;
using ForestAdventure.Traps;
using Framework.Collision.Collider;
using Framework.Development.Components;
using Framework.Game;
using Framework.Interfaces;
using Framework.Render;
using Framework.Shapes;
using Framework.Sound;
using Framework.Util;
using OpenTK;

namespace ForestAdventure.Bow
{
    public class Arrow : GameObject, IUpdateable, ICollision
    {
        private const float GRAVITY_CONSTANT = 9.81f;
        private const float FORCE_INITIAL_MULTIPLIER = 30f;
        private const float FORCE_DRAIN = 0.99f;

        private readonly float arrowNoCollisionTime;
        private float lifeTime = 5f;
        private float gravityVelocity;
        private bool gravityEnabled = true;
        private Vector2 force;
        private readonly Sound soundHit = new Sound(Resources.Resources.Arrow_hit);
        private readonly Sound soundEnemyHit = new Sound(Resources.Resources.Arrow_enemy_hit);
        private readonly Sound soundMiss = new Sound(Resources.Resources.Arrow_miss);

        public Arrow(Vector2 force)
        {
            arrowNoCollisionTime = lifeTime - 0.04f;
            this.force = force;
            transform.rotation = MathF.Atan2(force.Y, force.X);

            var arrowBounds = new RectangleBounds(2f, 0.5f);
            var colliderBounds = new RectangleBounds(0f, 0f, 0.5f, 0.5f);

            AddComponent(new RectangleTextureRenderer(this, arrowBounds, Resources.Resources.Arrow));
            AddComponent(new RectangleColliderComponent(this, colliderBounds, true));
            if (Debug.enabled)
            {
                AddComponent(new DebugUnrotatedColliderEdgesComponent(this, arrowBounds, Color.GreenYellow));
                AddComponent(new DebugUnrotatedColliderEdgesComponent(this, colliderBounds));
            }
        }

        public void OnCollision(ICollider other, Vector2 touchOffset)
        {
            switch (other.gameObject)
            {
                case Player _:
                    break;
                case VerticalRope _:
                    break;
                case Checkpoint _:
                    break;
                case Exit _:
                    break;
                case VerticalMovingTrap _:
                    if (lifeTime < arrowNoCollisionTime)
                    {
                        soundHit.Play();
                        Game.instance.RemoveGameObject(this);
                    }

                    break;
                case HorizontalMovingTrap _:
                    if (lifeTime < arrowNoCollisionTime)
                    {
                        soundHit.Play();
                        Game.instance.RemoveGameObject(this);
                    }

                    break;
                case Platform _:
                    if (lifeTime < arrowNoCollisionTime)
                    {
                        soundHit.Play();
                        Game.instance.RemoveGameObject(this);
                    }

                    break;
                case Arrow _:
                    soundHit.Play();
                    Game.instance.RemoveGameObject(other.gameObject);
                    Game.instance.RemoveGameObject(this);
                    break;
                case Enemy _:
                    soundEnemyHit.Play();
                    Game.instance.RemoveGameObject(other.gameObject);
                    Game.instance.RemoveGameObject(this);
                    break;
                default:
                    if (lifeTime < arrowNoCollisionTime)
                    {
                        Game.instance.RemoveGameObject(this);
                    }

                    break;
            }
        }

        public void Update(float deltaTime)
        {
            if ((lifeTime -= deltaTime) <= 0)
            {
                Game.instance.RemoveGameObject(this);
            }

            // Cache position
            var previousPosition = transform.position;

            deltaTime = MathF.Max(1f / 60f, deltaTime);

            // Apply force
            transform.position += FORCE_INITIAL_MULTIPLIER * deltaTime * force;
            force *= FORCE_DRAIN;

            // Apply gravity
            if (gravityEnabled)
            {
                gravityVelocity += deltaTime * deltaTime * GRAVITY_CONSTANT;
                transform.position += gravityVelocity * new Vector2(0f, -1f);
            }

            var deltaPosition = transform.position - previousPosition;
            transform.rotation = MathF.Atan2(deltaPosition.Y, deltaPosition.X);
        }
    }
}