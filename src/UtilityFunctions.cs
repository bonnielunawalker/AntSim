﻿using System.Collections.Generic;

namespace MyGame
{
    public class UtilityFunctions
    {
        public static bool InField(Drawable obj, Location topLeft, Location bottomRight)
        {
            return obj.X <= topLeft.X && obj.Y <= topLeft.Y && obj.X >= bottomRight.X && obj.Y >= bottomRight.Y;
        }
    }
}