using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;
// using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace Framework.Render.Helper
{
    public static class TextureHelper
    {
        // TODO
        // public static int LoadTextureFromBitmap(Bitmap textureBitmap)
        // {
        //     GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
        //
        //     GL.GenTextures(1, out int texture);
        //     GL.BindTexture(TextureTarget.Texture2D, texture);
        //
        //     var data = textureBitmap.LockBits(
        //         new Rectangle(0, 0, textureBitmap.Width, textureBitmap.Height),
        //         ImageLockMode.ReadOnly,
        //         PixelFormat.Format32bppArgb);
        //
        //     GL.TexImage2D(
        //         TextureTarget.Texture2D,
        //         0,
        //         PixelInternalFormat.Rgba,
        //         data.Width,
        //         data.Height,
        //         0,
        //         OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
        //         PixelType.UnsignedByte,
        //         data.Scan0);
        //     textureBitmap.UnlockBits(data);
        //
        //
        //     // GL.TexParameter(
        //     //     TextureTarget.Texture2D,
        //     //     TextureParameterName.TextureMinFilter,
        //     //     (int) TextureMinFilter.Linear);
        //     // GL.TexParameter(
        //     //     TextureTarget.Texture2D,
        //     //     TextureParameterName.TextureMagFilter,
        //     //     (int) TextureMagFilter.Linear);
        //     // GL.TexParameter(
        //     //     TextureTarget.Texture2D,
        //     //     TextureParameterName.TextureWrapS,
        //     //     (int) TextureWrapMode.Repeat);
        //     // GL.TexParameter(
        //     //     TextureTarget.Texture2D,
        //     //     TextureParameterName.TextureWrapT,
        //     //     (int) TextureWrapMode.Repeat);
        //
        //     return texture;
        // }
    }
}