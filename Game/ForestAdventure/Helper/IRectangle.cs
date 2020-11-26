using System;

namespace ForestAdventure.Helper
{
    [Obsolete]
    public interface IRectangle
    {
        float MaxX { get; }

        float MaxY { get; }

        float MinX { get; }

        float MinY { get; }
    }
}