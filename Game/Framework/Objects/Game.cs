using System.Collections.Generic;
using System.Linq;
using Framework.Collision;
using Framework.Interfaces;
<<<<<<< HEAD
using Framework.Util;
=======
using Framework.Util.Extension;
>>>>>>> master
using OpenTK.Graphics.OpenGL;

namespace Framework.Objects
{
    public class Game
    {
<<<<<<< HEAD
        private static Game instanceInternal;

        public GameWindow gameWindow { get; private set; }
        private List<GameObject> gameObjectsClone => gameObjects.ToList();

        public readonly List<GameObject> gameObjects = new List<GameObject>();

        public static Game instance => instanceInternal ?? (instanceInternal = new Game());

        private Game()
        {
        }

        public void Run()
        {
            gameWindow = new GameWindow(this);

            // run the game loop with 60hz
            gameWindow.Run(60);
        }
=======
        private readonly List<GameObject> gameObjects = new List<GameObject>();
>>>>>>> master

        public void AddGameObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        internal void Resize(int width, int height)
        {
<<<<<<< HEAD
            gameObjectsClone
=======
            gameObjects
>>>>>>> master
                .AsEnumerable()
                .ForEach(gameObject => (gameObject as IResizable)?.Resize(width, height))
                .SelectMany(gameObject => gameObject.components)
                .ForEach(component => (component as IResizable)?.Resize(width, height))
                .Evaluate();
        }

        internal void Update(float deltaTime)
        {
<<<<<<< HEAD
            gameObjectsClone
=======
            gameObjects
>>>>>>> master
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

<<<<<<< HEAD
            gameObjectsClone
                .AsEnumerable()
                .ForEach(gameObject => (gameObject as IRender)?.Draw())
                .SelectMany(gameObject => gameObject.components)
                .ForEach(component => (component as IRender)?.Draw())
=======
            gameObjects
                .AsEnumerable()
                .ForEach(gameObject => (gameObject as IDrawable)?.Draw())
                .SelectMany(gameObject => gameObject.components)
                .ForEach(component => (component as IDrawable)?.Draw())
>>>>>>> master
                .Evaluate();
        }

        internal void CollisionCheck()
        {
<<<<<<< HEAD
            var colliders = gameObjectsClone
=======
            var colliders = gameObjects
>>>>>>> master
                .SelectMany(gameObject => gameObject.components)
                .Select(component => component as ICollider)
                .Where(collider => collider != null)
                .ToArray();
            foreach (var collider in colliders)
            {
                foreach (var secondCollider in colliders)
                {
                    if (collider == secondCollider)
                    {
                        continue;
                    }

                    // TODO catch collision with same gameObject?
                    CollisionHandler.HandleCollision(collider, secondCollider);
                }
            }
        }
    }
}