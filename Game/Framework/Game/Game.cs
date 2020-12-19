using System.Collections.Generic;
using System.Linq;
using Framework.Collision;
using Framework.Interfaces;
using Framework.Util;

namespace Framework.Game
{
    public class Game
    {
        private static Game instanceInternal;

        public GameWindow gameWindow { get; private set; }
        public string title { get; set; }
        private List<GameObject> gameObjectsClone => gameObjects.ToList();

        public readonly List<GameObject> gameObjects = new List<GameObject>();

        public static Game instance => instanceInternal ?? (instanceInternal = new Game());

        private Game()
        {
        }

        public void Run()
        {
            gameWindow = new GameWindow(this, title);

            // run the game loop with 60hz
            gameWindow.Run(60);
        }

        public void AddGameObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public void RemoveGameObject(GameObject gameObject)
        {
            gameObjects.Remove(gameObject);
        }

        public void ClearGameObjects()
        {
            gameObjects.Clear();
        }

        internal void Resize(int width, int height)
        {
            gameObjectsClone
                .AsEnumerable()
                .ForEach(gameObject => (gameObject as IResizable)?.Resize(width, height))
                .SelectMany(gameObject => gameObject.components)
                .ForEach(component => (component as IResizable)?.Resize(width, height))
                .Evaluate();
        }

        internal void Update(float deltaTime)
        {
            gameObjectsClone
                .AsEnumerable()
                .ForEach(gameObject => (gameObject as IUpdateable)?.Update(deltaTime))
                .SelectMany(gameObject => gameObject.components)
                .ForEach(component => (component as IUpdateable)?.Update(deltaTime))
                .Evaluate();
        }

        internal void Draw()
        {
            gameObjectsClone
                .AsEnumerable()
                .ForEach(gameObject => (gameObject as IRender)?.Draw())
                .SelectMany(gameObject => gameObject.components)
                .ForEach(component => (component as IRender)?.Draw())
                .Evaluate();
        }

        internal void CollisionCheck()
        {
            var colliders = gameObjectsClone
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