using SwinGameSDK;
using System;
using System.Collections.Generic;

namespace MyGame
{
    public static class GameLogic
    {
        private static List<Creature> _creatures = new List<Creature>();
        private static Random _rand = new Random();

        public static List<Creature> Creatures
        {
            get { return _creatures; }
            set { _creatures = value; }
        }

        public static void Process()
        {
            SwinGame.ProcessEvents();

            if (GameState.Setup)
            {
                for (int i = 0; i <= 10; i++)
                {
                    _creatures.Add(new Creature(new Location(_rand.Next(0, 720), _rand.Next(0, 480))));
                }

                GameState.Setup = false;
            }
        }

        public static void DrawObjects()
        {
            foreach (DrawableObject obj in _creatures)
            {
                obj.Draw();
            }
        }
    }
}