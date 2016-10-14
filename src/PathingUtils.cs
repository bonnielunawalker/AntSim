using System;
using System.Collections.Generic;

namespace MyGame
{
    public static class PathingUtils
    {
        private const int MAX_INT = int.MaxValue;

        public static Node GetPriorityNode(List<Node> list, Location destination)
        {
            double score;
            double lowestScore = MAX_INT;
            Node bestNode = null;

            for (int i = 0; i < list.Count; i++)
            {
                score = GetFScore(destination, list[i]);

                if (score < lowestScore)
                {
                    lowestScore = score;
                    bestNode = list[i];
                }
            }

            return bestNode;
        }

        public static double GetFScore(Location destination, Node nodeToCheck)
        {
            double distance = nodeToCheck.GScore - nodeToCheck.Pheremone.Strength;
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
    }
}