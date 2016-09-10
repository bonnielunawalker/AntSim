using System.Collections.Generic;

namespace MyGame
{
    public interface IHasPaths
    {
        List<Path> Paths
        {
            get;
            set;
        }
    }
}