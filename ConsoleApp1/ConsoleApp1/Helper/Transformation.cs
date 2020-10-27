using OpenTK;

namespace ConsoleApp1.Helper
{
    public static class Transformation
    {
        public static Matrix4 Combine(Matrix4 applyToCoordinatesFirst, Matrix4 applyToCoordinatesSecond) =>
            applyToCoordinatesFirst * applyToCoordinatesSecond;

        public static Matrix4 Combine(params Matrix4[] transformations)
        {
            var result = transformations[0];
            for (int i = 1; i < transformations.Length; ++i)
            {
                result = Combine(result, transformations[i]);
            }

            return result;
        }

        public static Matrix4 Rotation(float angleRadiant) => Matrix4.CreateRotationZ(angleRadiant);

        public static Matrix4 Scale(float sx, float sy) => Matrix4.CreateScale(sx, sy, 1f);

        public static Matrix4 Scale(Vector2 scale) => Scale(scale.X, scale.Y);

        public static Matrix4 Scale(float uniformScaleFactor) => Matrix4.CreateScale(uniformScaleFactor);

        public static Matrix4 Translate(float tx, float ty) => Matrix4.CreateTranslation(tx, ty, 0f);

        public static Matrix4 Translate(Vector2 translation) => Translate(translation.X, translation.Y);

        public static Vector2 Transform(this Vector2 input, Matrix4 transformation) =>
            Vector4.Transform(new Vector4(input.X, input.Y, 0f, 1f), transformation).Xy;
    }
}