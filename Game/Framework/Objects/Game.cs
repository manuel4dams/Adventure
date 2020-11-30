using System.Collections.Generic;
using System.Linq;
using Framework.Collision;
using Framework.Extension;
using Framework.Interfaces;
using OpenTK.Graphics.OpenGL;

namespace Framework.Objects
{
    public class Game
    {
        private readonly List<GameObject> gameObjects = new List<GameObject>();

        public void AddGameObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        internal void Resize(int width, int height)
        {
            gameObjects
                .AsEnumerable()
                .ForEach(gameObject => (gameObject as IResizable)?.Resize(width, height))
                .SelectMany(gameObject => gameObject.components)
                .ForEach(component => (component as IResizable)?.Resize(width, height))
                .Evaluate();
        }

        internal void Update(float deltaTime)
        {
            gameObjects
                .AsEnumerable()
                .ForEach(gameObject => (gameObject as IUpdateable)?.Update(deltaTime))
                .SelectMany(gameObject => gameObject.components)
                .ForEach(component => (component as IUpdateable)?.Update(deltaTime))
                .Evaluate();
        }

        internal void Draw()
        {
            // TODO might not be needed
            GL.Clear(ClearBufferMask.ColorBufferBit);

            gameObjects
                .AsEnumerable()
                .ForEach(gameObject => (gameObject as IDrawable)?.Draw())
                .SelectMany(gameObject => gameObject.components)
                .ForEach(component => (component as IDrawable)?.Draw())
                .Evaluate();
        }

        internal void CollisionCheck()
        {
            var colliders = gameObjects
                .SelectMany(gameObject => gameObject.components)
                .Select(component => component as ICollider)
                .Where(collider => collider != null)
                .ToArray();
            foreach (var collider in colliders)
            {
                foreach (var secondCollider in colliders)
                {
                    if (collider == secondCollider)
                        continue;

                    // TODO catch collision with same gameObject?
                    CollisionHandler.HandleCollision(collider, secondCollider);
                }
            }
        }
    }
}