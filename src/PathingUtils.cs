using System;
using System.Collections.Generic;

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

        private static int GetFScore(Location destination, Node nodeToCheck)
        {
            int distance = nodeToCheck.GScore;

            int manhattan = Math.Abs(nodeToCheck.X - destination.X) +
                            Math.Abs(nodeToCheck.Y - destination.Y);

            return distance + manhattan;
        }
    }
}