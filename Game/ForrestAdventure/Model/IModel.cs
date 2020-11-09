using System.Collections.Generic;

namespace ForrestAdventure.Model
{
    public interface IModel
    {
        IRectangle Player { get; }

        IEnumerable<IRectangle> Enemy { get; }

        IEnumerable<IRectangle> Platform { get; }

        IEnumerable<IRectangle> Arrows { get; }

        Object Exit { get; }
    }
}