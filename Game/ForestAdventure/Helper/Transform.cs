using OpenTK;

namespace ForestAdventure.Helper
{
    public class Transform
    {
        public static Matrix4 Combine(Matrix4 applyToCoordinatesFirst, Matrix4 applyToCoordinatesSecond)
        {
            return applyToCoordinatesFirst * applyToCoordinatesSecond;
        }

        public static Matrix4 Combine(params Matrix4[] transformations)
        {
            var result = transformations[0];
            for (var i = 1; i < transformations.Length; ++i) result = Combine(result, transformations[i]);

            return result;
        }

        public static Matrix4 Rotation(float angleRadiant)
        {
            return Matrix4.CreateRotationZ(angleRadiant);
        }

        public static Matrix4 Scale(float sx, float sy)
        {
            return Matrix4.CreateScale(sx, sy, 1f);
        }

        public static Matrix4 Scale(Vector2 scale)
        {
            return Scale(scale.X, scale.Y);
        }

        public static Matrix4 Scale(float uniformScaleFactor)
        {
            return Matrix4.CreateScale(uniformScaleFactor);
        }

        public static Matrix4 Translate(float translatex, float translatey)
        {
            return Matrix4.CreateTranslation(translatex, translatey, 0f);
        }

        public static Matrix4 Translate(Vector2 translation)
        {
            return Translate(translation.X, translation.Y);
        }

        public Vector2 Transformation(Vector2 input, Matrix4 transformation)
        {
            return Vector4.Transform(new Vector4(input.X, input.Y, 0f, 1f), transformation).Xy;
        }
    }
}