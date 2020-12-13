namespace Framework.Util
{
<<<<<<< HEAD
    public static class LerpUtils
    {
        public static float Lerp(float a, float b, float percentage)
        {
            return a * (1 - percentage) + b * percentage;
        }

=======
    public class LerpUtils
    {
>>>>>>> master
        public static float SmoothnessToLerp(float smoothness)
        {
            return 1f / (smoothness + 1f);
        }
    }
}