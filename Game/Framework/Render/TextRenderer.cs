using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Net.Mime;
using Framework.Game;
using Framework.Interfaces;
using OpenTK.Graphics.OpenGL;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

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