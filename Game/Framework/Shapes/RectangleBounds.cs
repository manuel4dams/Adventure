using System;
using OpenTK;

namespace Framework.Shapes
{
    public struct RectangleBounds
    {
        public Vector2 center;
        public Vector2 size;

        public float minX
        {
            get => center.X - (size.X / 2f);
            set => center.X = value + (size.X / 2f);
        }

        public float maxX
        {
            get => center.X + (size.X / 2f);
            set => center.X = value - (size.X / 2f);
        }

        public float minY
        {
            get => center.Y - (size.Y / 2f);
            set => center.Y = value + (size.Y / 2f);
        }

        public float maxY
        {
            get => center.Y + (size.Y / 2f);
            set => center.Y = value - (size.Y / 2f);
        }

        public RectangleBounds(Vector2 size)
            : this(Vector2.Zero, size)
        {
            this.size = size;
        }

        public RectangleBounds(Vector2 center, Vector2 size)
        {
            this.center = center;
            this.size = size;
        }

        public RectangleBounds(float sizeX, float sizeY)
            : this(new Vector2(sizeX, sizeY))
        {
        }

        public RectangleBounds(float centerX, float centerY, float sizeX, float sizeY)
            : this(new Vector2(centerX, centerY), new Vector2(sizeX, sizeY))
        {
        }
    }

    public static class BoundsExtension
    {
        public static RectangleBounds UnrotatedTransform(
            this RectangleBounds rectangleBounds,
            Transform.Transform transform)
        {
            return new RectangleBounds(
                transform.position + rectangleBounds.center,
                transform.scale * rectangleBounds.size);
        }

        public static Quad Transform(this RectangleBounds rectangleBounds, Transform.Transform transform)
        {
            var tmp = new RectangleBounds(rectangleBounds.size * transform.scale);
#pragma warning disable
            return new Quad
            {
                vertex1 = rectangleBounds.center + transform.position + new Vector2(
                    tmp.minX * MathF.Cos(transform.rotation) - tmp.minY * MathF.Sin(transform.rotation),
                    tmp.minX * MathF.Sin(transform.rotation) + tmp.minY * MathF.Cos(transform.rotation)),
                vertex2 = rectangleBounds.center + transform.position + new Vector2(
                    tmp.maxX * MathF.Cos(transform.rotation) - tmp.minY * MathF.Sin(transform.rotation),
                    tmp.maxX * MathF.Sin(transform.rotation) + tmp.minY * MathF.Cos(transform.rotation)),
                vertex3 = rectangleBounds.center + transform.position + new Vector2(
                    tmp.maxX * MathF.Cos(transform.rotation) - tmp.maxY * MathF.Sin(transform.rotation),
                    tmp.maxX * MathF.Sin(transform.rotation) + tmp.maxY * MathF.Cos(transform.rotation)),
                vertex4 = rectangleBounds.center + transform.position + new Vector2(
                    tmp.minX * MathF.Cos(transform.rotation) - tmp.maxY * MathF.Sin(transform.rotation),
                    tmp.minX * MathF.Sin(transform.rotation) + tmp.maxY * MathF.Cos(transform.rotation)),
            };
#pragma warning restore
        }
    }
}