namespace MyGame
{
    public class UtilityFunctions
    {
        public static bool InField(IDrawable obj, Location topLeft, Location bottomRight)
        {
            if (obj.X <= topLeft.X && obj.Y <= topLeft.Y && obj.X >= bottomRight.X && obj.Y >= bottomRight.Y)
                return true;

            return false;
        }
    }
}