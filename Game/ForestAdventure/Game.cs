using System.Collections.Generic;
using ForestAdventure.Interfaces;
using ForestAdventure.Objects;

namespace ForestAdventure
{
    public class Game
    {
        private List<IGameObject> gameObjectList = new List<IGameObject>();

        public Game()
        {
            // TODO WIP
            Platform platform = new Platform();
            addPlatform(platform);
        }

        internal void Resize(float width, float height)
        {
            // TODO implement
        }

        internal void Update()
        {
            foreach (var gameObject in gameObjectList)
            {
                gameObject.Update();
            }
        }

        internal void Draw()
        {
            foreach (var gameObject in gameObjectList)
            {
                gameObject.Draw();
            }
        }

        private void addPlatform(Platform platform)
        {
            gameObjectList.Add(platform);
        }
    }
}