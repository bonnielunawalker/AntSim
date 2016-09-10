using SwinGameSDK;
using System;
using System.Collections.Generic;

namespace MyGame
{
    public static class GameLogic
    {
        private static List<Creature> _creatures = new List<Creature>();

        public static void Process()
        {
            SwinGame.ProcessEvents();

            if (GameState.Setup)
            {
                _creatures.Add(new Creature(new Location(100, 100)));
            }
        }

        public static void DrawObjects()
        {
            foreach (Creature c in _creatures)
            {
                c.Draw();
            }
        }
    }
}