using System;

namespace ForestAdventure.Interfaces
{
    public interface IComponent
    {
        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void CheckCollision()
        {
            throw new NotImplementedException();
        }
    }
}