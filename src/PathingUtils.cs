using System;
using System.Collections.Generic;

namespace MyGame
{
    public static class PathingUtils
    {
        private const int MAX_INT = int.MaxValue;

        public static void AddNeigbours(List<Node> open, LinkedList<Node> closed, Node n)
        {
            List<Node> newNodes = new List<Node>();

            newNodes.Add(new Node(n.X, n.Y - 1, n.GScore + 1));
            newNodes.Add(new Node(n.X, n.Y + 1, n.GScore + 1));
            newNodes.Add(new Node(n.X - 1, n.Y, n.GScore + 1));
            newNodes.Add(new Node(n.X + 1, n.Y, n.GScore + 1));

            // Diagonals
            newNodes.Add(new Node(n.X + 1, n.Y - 1, n.GScore + 1.41));
            newNodes.Add(new Node(n.X + 1, n.Y + 1, n.GScore + 1.41));
            newNodes.Add(new Node(n.X - 1, n.Y - 1, n.GScore + 1.41));
            newNodes.Add(new Node(n.X - 1, n.Y + 1, n.GScore + 1.41));

            if (open.Count != 0)
            {
                for (int i = 0; i < newNodes.Count; i++)
                {
                    Node newNode = newNodes[i];
                    for (int j = 0; j < open.Count; j++)
                    {
                        Node oldNode = open[j];
                        if (newNode.X != oldNode.X && newNode.Y != oldNode.Y  && !open.Contains(newNode) && !closed.Contains(newNode))

                            open.Add(newNode);
                    }
                }
            }
            else
            {
                foreach (Node newNode in newNodes)
                    open.Add(newNode);
            }
        }

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
            double distance = nodeToCheck.GScore;
            int manhattan = Manhattan(new Location(nodeToCheck.X, nodeToCheck.Y), destination);

            foreach (Pheremone p in GameLogic.Pheremones)
            {
                if (p.Location.IsAt(new Location(nodeToCheck.X, nodeToCheck.Y)))
                {
                    distance -= p.Strength;
                }
            }

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
    }
}