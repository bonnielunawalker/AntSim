using System;

namespace AntSim
{
    public static class PathingUtils
    {
        public static int GetHScore(Location start, Location dest)
        {
            return Math.Abs(start.X - dest.X) +
                   Math.Abs(start.Y - dest.Y);
        }

        public static Node NodeAt(int x, int y)
        {
            return World.Instance.Grid[x, y];
        }

        public static Node NodeAt(Location l)
        {
            return NodeAt(l.X, l.Y);
        }

		public static bool CompareScores (double a, double b)
		{
			return a < b;
		}
    }
}