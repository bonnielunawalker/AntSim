using System.Collections.Generic;

namespace MyGame
{
    public interface HasPaths
    {
        List<Path> Paths
        {
            get;
            set;
        }
    }
}