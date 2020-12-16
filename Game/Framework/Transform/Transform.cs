using System;
using OpenTK;

namespace Framework.Transform
{
    public class Transform
    {
        public Vector2 position;
        public float rotation;
        public Vector2 scale = Vector2.One;

        public void Apply(Transform other)
        {
            position = other.position;
            rotation = other.rotation;
            scale = other.scale;
        }

        public void Translate(Vector2 position)
        {
            this.position += position;
        }

        public Vector2 TranslatePosition(Vector2 position)
        {
            return this.position + position;
        }

        public void Scale()
        {
            throw new NotImplementedException();
        }

        public void Rotate()
        {
            throw new NotImplementedException();
        }
    }
}