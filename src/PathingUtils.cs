using System;

namespace MyGame
{
    public static class PathingUtils
    {
        public static double GetFScore(Node destination, Node nodeToCheck)
        {
            double distance = nodeToCheck.GScore - nodeToCheck.PheremoneStrength * 100;
            int manhattan = Manhattan(nodeToCheck, destination);

            return distance + manhattan;
        }

        public static Location EstimateLocation(Location start, Location dest)
        {
            int dist = (int)DistanceBetween(start, dest);
            return new Location(dest.X + GameLogic.Random.Next(-dist, dist),
                dest.Y + GameLogic.Random.Next(-dist, dist));
        }

        public static double DistanceBetween(Location start, Location dest)
        {
            float startValue = (start.X - start.Y) ^ 2;
            float destValue = (dest.X - dest.Y) ^ 2;
            return Math.Sqrt(startValue + destValue);
        }

        public static int Manhattan(Location start, Location dest)
        {
            return Math.Abs(start.X - dest.X) +
                   Math.Abs(start.Y - dest.Y);
        }

        public static Node NodeAt(int x, int y)
        {
            return World.Instance.Grid.Nodes[x, y];
        }

        public static Node NodeAt(Location l)
        {
            return NodeAt(l.X, l.Y);
        }
    }
}