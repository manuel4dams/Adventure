﻿using System.Collections.Generic;

namespace ForestAdventure.Model
{
    public interface IModel
    {
        IRectangle Player { get; }

        IEnumerable<IRectangle> Enemies { get; }

        IEnumerable<IRectangle> Platform { get; }

        IEnumerable<IRectangle> Arrows { get; }

        Object Exit { get; }
    }
}