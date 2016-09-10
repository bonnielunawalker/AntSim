using System;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            SwinGame.OpenWindow("AntSim", 720, 480);
            Console.WriteLine("Everything appears to be working!");

            while (!SwinGame.WindowCloseRequested() && !GameState.Exit)
            {
                SwinGame.ClearScreen(Color.White);
                GameLogic.Process();
                GameLogic.DrawObjects();
                SwinGame.RefreshScreen(60);
            }
        }
    }
}
