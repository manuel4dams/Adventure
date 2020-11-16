using OpenTK;

namespace ForestAdventure.View
{
    internal class Camera
    {
        private static Vector2 position = new Vector2(0, 0);

        public static Vector2 Position
        {
            get => position;
            set
            {
                // minimaler und maximaler X-Wert der Camera
                position.X = value.X <= 0 ? 0 : value.X >= 4 ? 4 : value.X;

                // minimaler und maximaler Y-Wert der Camera
                position.Y = value.Y <= 0 ? 0 : value.Y >= 2 ? 2 : value.Y;
            }
        }
    }
}