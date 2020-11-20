using System;
using System.Collections.Generic;
using ForestAdventure.Interfaces;
using ForestAdventure.Objects;

namespace ForestAdventure
{
    public class Game
    {
        private List<IGameObject> GameObjectList = new List<IGameObject>();

        public Game()
        {
            Platform platform = new Platform();
            addPlatforms(platform);
        }

        internal void Resize(float width, float height)
        {
        }

        internal void Update()
        {
        }

        internal void Draw()
        {
        }

        private void addPlatforms(Platform platform)
        {
            GameObjectList.Add(platform);
        }
    }
}