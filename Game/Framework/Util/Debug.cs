namespace Framework.Util
{
    // prevent rider from deleting using statements when building in releasemode
    public static class Debug
    {
        public static bool enabled
        {
            get
            {
#if DEBUG
                return true;
#else
                return false;
#endif
            }
        }
    }
}