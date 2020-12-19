using System;
using Framework.Game;
using Framework.Interfaces;

namespace Framework.Render
{
    public class TextRenderer : IComponent, IRender
    {
        // TODO maybe needed for rendering texts

        public TextRenderer()
        {
        }

        public GameObject gameObject { get; }

        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}