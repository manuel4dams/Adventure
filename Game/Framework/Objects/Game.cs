using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace Framework.Objects
{
    public class Game
    {
        private readonly List<GameObject> gameObjectList = new List<GameObject>();

        public void AddGameObject(GameObject gameObject)
        {
            gameObjectList.Add(gameObject);
        }

        internal void Resize(int width, int height)
        {
            Camera.Instance.Resize(width, height);
        }

        internal void Update(float deltaTime)
        {
            foreach (var gameObject in gameObjectList) gameObject.Update(deltaTime);
        }

        internal void Draw()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            foreach (var gameObject in gameObjectList) gameObject.Draw();
        }
    }
}