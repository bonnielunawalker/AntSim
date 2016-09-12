using System;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            SwinGame.OpenWindow("AntSim", 720, 480);

            while (!SwinGame.WindowCloseRequested() && !GameState.Exit)
            {
                SwinGame.ClearScreen(Color.White);
                GameLogic.Process();
                GameLogic.DrawObjects();
                SwinGame.RefreshScreen(60);
                SwinGame.Delay(40);
            }
        }
    }
}
