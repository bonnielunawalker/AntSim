using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            SwinGame.OpenWindow("AntSim", GameState.WindowWidth, GameState.WindowHeight);
            GameLogic.Setup();

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
