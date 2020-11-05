using System.Collections.Generic;

namespace ForrestAdventure.Model
{
    internal interface IModel
    {
        IRectangle Player { get; }

        IEnumerable<IRectangle> Enemy { get; }

        IEnumerable<IRectangle> Platform { get; }

        IEnumerable<IRectangle> Arrows { get; }
    }
}