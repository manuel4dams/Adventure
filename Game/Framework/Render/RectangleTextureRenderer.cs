using System;
using System.Drawing;
using System.Drawing.Imaging;
using Framework.Game;
using Framework.Interfaces;
using Framework.Shapes;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace Framework.Render
{
    // TODO fix black border on enemy and player
    public class RectangleTextureRenderer : IComponent, IRender, IDisposable
    {
        private readonly RectangleBounds rectangleBounds;
        private readonly Bitmap texture;
        private readonly RenderScaleType renderScaleType;
        private int? textureId;
        private Vector4 size;
        public GameObject gameObject { get; }

        public RectangleTextureRenderer(
            GameObject gameObject,
            RectangleBounds rectangleBounds,
            Bitmap texture,
            RenderScaleType renderScaleType = RenderScaleType.Deform,
            Vector4? size = null)
        {
            this.gameObject = gameObject;
            this.rectangleBounds = rectangleBounds;
            this.texture = texture;
            this.renderScaleType = renderScaleType;
            if (size == null)
            {
                size = new Vector4(0, 0, 1, 1);
            }

            this.size = (Vector4) size;
        }

        public void Draw()
        {
            var rectangle = rectangleBounds.Transform(gameObject.transform);
            rectangle.Translate(-Camera.Camera.instance.transform.position);

            GL.Enable(EnableCap.Texture2D);
            if (textureId == null)
                textureId = LoadTextureFromBitmap(texture);
            GL.BindTexture(TextureTarget.Texture2D, textureId.Value);

            switch (renderScaleType)
            {
                case RenderScaleType.Deform:
                    DeformTexture(rectangle);
                    break;
                case RenderScaleType.Crop:
                    CropTexture(rectangle, size);
                    break;
                case RenderScaleType.Tile:
                    TileTexture(rectangle, size);
                    break;
                default:
                    throw new ArgumentException("Invalid " + nameof(RenderScaleType));
            }

            GL.Disable(EnableCap.Texture2D);
        }

        public void Dispose()
        {
            texture.Dispose();
        }

        public void SetCropData(Vector4 size)
        {
            this.size = size;
        }

        private static int LoadTextureFromBitmap(Bitmap textureBitmap)
        {
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            // without flipping the textures are upside down
            textureBitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

            GL.GenTextures(1, out int tex);
            GL.BindTexture(TextureTarget.Texture2D, tex);

            var data = textureBitmap.LockBits(
                new Rectangle(
                    0,
                    0,
                    textureBitmap.Width,
                    textureBitmap.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            GL.TexImage2D(
                TextureTarget.Texture2D,
                0,
                PixelInternalFormat.Rgba,
                data.Width,
                data.Height,
                0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                PixelType.UnsignedByte,
                data.Scan0);
            textureBitmap.UnlockBits(data);

            GL.TexParameter(
                TextureTarget.Texture2D,
                TextureParameterName.TextureMinFilter,
                (int) TextureMinFilter.Linear);
            GL.TexParameter(
                TextureTarget.Texture2D,
                TextureParameterName.TextureMagFilter,
                (int) TextureMagFilter.Linear);
            GL.TexParameter(
                TextureTarget.Texture2D,
                TextureParameterName.TextureWrapS,
                (int) TextureWrapMode.Repeat);
            GL.TexParameter(
                TextureTarget.Texture2D,
                TextureParameterName.TextureWrapT,
                (int) TextureWrapMode.Repeat);

            return tex;
        }

        private static void DeformTexture(Quad rectangle)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(rectangle.vertex1);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(rectangle.vertex2);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(rectangle.vertex3);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(rectangle.vertex4);
            GL.End();
        }

        private static void CropTexture(Quad rectangle, Vector4 size)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(size.X, size.Y);
            GL.Vertex2(rectangle.vertex1);
            GL.TexCoord2(size.Z, size.Y);
            GL.Vertex2(rectangle.vertex2);
            GL.TexCoord2(size.Z, size.W);
            GL.Vertex2(rectangle.vertex3);
            GL.TexCoord2(size.X, size.W);
            GL.Vertex2(rectangle.vertex4);
            GL.End();
        }

        private static void TileTexture(Quad rectangle, Vector4 size)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(size.X, size.Y);
            GL.Vertex2(rectangle.vertex1);
            GL.TexCoord2(size.Z, size.Y);
            GL.Vertex2(rectangle.vertex2);
            GL.TexCoord2(size.Z, size.W);
            GL.Vertex2(rectangle.vertex3);
            GL.TexCoord2(size.X, size.W);
            GL.Vertex2(rectangle.vertex4);
            GL.End();
        }
    }
}