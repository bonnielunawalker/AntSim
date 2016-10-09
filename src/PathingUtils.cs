using System;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace MyGame
{
    public static class PathingUtils //TODO: Rename this (consider factory, manager or handler?)
    {
        private const int MAX_INT = int.MaxValue;

        public static void AddNeigbours(List<Node> list, Node n)
        {
            Node north = new Node(n.X, n.Y - 1, n.GScore + 1);
            Node south = new Node(n.X, n.Y + 1, n.GScore + 1);
            Node east = new Node(n.X - 1, n.Y, n.GScore + 1);
            Node west = new Node(n.X + 1, n.Y, n.GScore + 1);
            Node northeast = new Node(n.X + 1, n.Y - 1, n.GScore + 1);
            Node southeast = new Node(n.X + 1, n.Y + 1, n.GScore + 1);
            Node northwest = new Node(n.X - 1, n.Y - 1, n.GScore + 1);
            Node southwest = new Node(n.X - 1, n.Y + 1, n.GScore + 1);

            list.Add(north);
            list.Add(south);
            list.Add(east);
            list.Add(west);
            list.Add(northeast);
            list.Add(southeast);
            list.Add(northwest);
            list.Add(southwest);
        }

        public static Node GetPriorityNode(List<Node> list, Location destination)
        {
            int score;
            int lowestScore = MAX_INT;
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

        public static int GetFScore(Location destination, Node nodeToCheck)
        {
            int distance = nodeToCheck.GScore;
            int manhattan = Manhattan(new Location(nodeToCheck.X, nodeToCheck.Y), destination);
            return distance + manhattan;
        }

        public static Location EstimateLocation(Location start, Location dest)
        {
            int dist = (int)DistanceBetween(start, dest);
            return new Location(dest.X + GameLogic.Random.Next(-dist / 2, dist / 2),
                dest.Y + GameLogic.Random.Next(-dist / 2, dist / 2));
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
    }
}