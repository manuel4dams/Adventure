using System;
using Framework.Interfaces;
using Framework.Objects;

namespace ForestAdventure.Objects
{
    public class Arrow : GameObject, IUpdateable, ICollision, IDrawable
    {
        // TODO implement arrow as object, remove component

        public void Update(float deltaTime)
        {
            // TODO migrate from arrow component add updateable component?
            throw new NotImplementedException();
        }

        public void OnCollision(ICollider other)
        {
            // TODO add collision
            throw new NotImplementedException();
        }

        public void Draw()
        {
            // TODO migrate from arrow component or add rectangle component?
            throw new NotImplementedException();
        }
    }
}