namespace Framework.Objects
{
    public sealed class Camera
    {
        private static Camera instance = null;
        private static readonly object padlock = new object();

        private Camera()
        {
        }

        public static Camera Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Camera();
                    }

                    return instance;
                }
            }
        }
    }
}