using System.Collections.Generic;
using System.Linq;
using Framework.Collision;
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
            Camera.Instance.Resize(width, height);
        }

        internal void Update(float deltaTime)
        {
            var updateables = gameObjects
                .SelectMany(gameObject => gameObject.components)
                .Select(component => component as IUpdateable)
                .Where(updateable => updateable != null);
            foreach (var updateable in updateables)
            {
                updateable.Update(deltaTime);
            }
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
                    CollisionDetector.HandleCollision(collider, secondCollider);
                }
            }
        }

        internal void Draw()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            var drawables = gameObjects
                .SelectMany(gameObject => gameObject.components)
                .Select(component => component as IDrawable)
                .Where(drawable => drawable != null);
            foreach (var drawable in drawables)
                drawable.Draw();
        }
    }
}