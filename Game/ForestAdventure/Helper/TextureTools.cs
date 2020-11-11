using System;
using System.IO;
using System.Reflection;
using ImageMagick;
using OpenTK.Graphics.OpenGL4;

namespace ForestAdventure.Helper
{
    internal static class TextureTools
    {
        public static int Load(Stream stream)
        {
            using var image = new MagickImage(stream);
            var format = PixelFormat.Rgb;
            switch (image.ChannelCount)
            {
                case 3: break;
                case 4:
                    format = PixelFormat.Rgba;
                    break;
                default: throw new ArgumentOutOfRangeException("Unexpected image format");
            }

            image.Flip();
            var bytes = image.GetPixelsUnsafe().ToArray();
            var handle = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, handle);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS,
                (int) TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT,
                (int) TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                (int) TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                (int) TextureMinFilter.LinearMipmapLinear);

            GL.TexImage2D(TextureTarget.Texture2D, 0, (PixelInternalFormat) format, image.Width, image.Height, 0,
                format, PixelType.UnsignedByte, bytes);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.GenerateMipmap, 1);
            GL.BindTexture(TextureTarget.Texture2D, 0);
            return handle;
        }

        public static int LoadFromResource(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            name = $"{nameof(ForestAdventure)}.{name}";
            using var stream = assembly.GetManifestResourceStream(name);
            if (stream is null)
            {
                var names = string.Join('|', assembly.GetManifestResourceNames());
                throw new ArgumentException($"Could not find resource '{name}' in resources '{names}'");
            }

            return Load(stream);
        }
    }
}