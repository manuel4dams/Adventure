using System.Collections.Generic;
using ForestAdventure.Interfaces;
using ForestAdventure.Objects;

namespace ForestAdventure
{
    public class Game
    {
        private readonly List<IGameObject> gameObjectList = new List<IGameObject>();

        public Game()
        {
            AddPlatforms(0.026f);
            AddEnemies(0.075f, 0.075f);
            AddPlayer(0.1f, 0.1f);
        }

        internal void Resize(float width, float height)
        {
            // TODO implement
        }

        internal void Update()
        {
            foreach (var gameObject in gameObjectList) gameObject.Update();
        }

        internal void Draw()
        {
            foreach (var gameObject in gameObjectList) gameObject.Draw();
        }

        private void AddPlatforms(float platformThickness)
        {
            gameObjectList.Add(new Platform(-1f, -1f, 0.8f, platformThickness));
            gameObjectList.Add(new Platform(-0.25f, -0.8f, 0.4f, platformThickness));
            gameObjectList.Add(new Platform(0.4f, -0.6f, 0.4f, platformThickness));
            gameObjectList.Add(new Platform(-0.7f, -0.6f, 0.2f, platformThickness));
            gameObjectList.Add(new Platform(-0.25f, -0.4f, 0.4f, platformThickness));
            gameObjectList.Add(new Platform(0.5f, -0.2f, 0.4f, platformThickness));
            gameObjectList.Add(new Platform(-0.4f, 0f, 0.8f, platformThickness));
            gameObjectList.Add(new Platform(-0.2f, 0.2f, 0.2f, platformThickness));
            gameObjectList.Add(new Platform(-0.6f, 0.4f, 0.4f, platformThickness));
            gameObjectList.Add(new Platform(0f, 0.6f, 0.4f, platformThickness));
            gameObjectList.Add(new Platform(0.6f, 0.8f, 0.8f, platformThickness));
            gameObjectList.Add(new Platform(-0.6f, -0.8f, 0.3f, platformThickness));
            gameObjectList.Add(new Platform(1f, 1f, 2f, platformThickness));
            gameObjectList.Add(new Platform(2f, 0.8f, 1.5f, platformThickness));
            gameObjectList.Add(new Platform(1.5f, 0.6f, 1f, platformThickness));
            gameObjectList.Add(new Platform(1f, 0.4f, 0.5f, platformThickness));
            gameObjectList.Add(new Platform(3f, 1.2f, 0.4f, platformThickness));
            gameObjectList.Add(new Platform(3.5f, 1.4f, 0.3f, platformThickness));
        }

        private void AddPlayer(float height, float width)
        {
            gameObjectList.Add(new Player(-0.9f, -0.9f, 0.075f, 0.15f));
        }

        private void AddEnemies(float height, float width)
        {
            gameObjectList.Add(new Enemy(0.45f, -0.6f, width, height));
            gameObjectList.Add(new Enemy(-0.2f, 0f, width, height));
            gameObjectList.Add(new Enemy(0.15f, 0.6f, width, height));
        }
    }
}