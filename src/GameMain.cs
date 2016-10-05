using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            SwinGame.OpenWindow("AntSim", GameState.WindowWidth, GameState.WindowHeight);
            Setup.Run();

            while (!SwinGame.WindowCloseRequested() && !GameState.Exit)
            {
                SwinGame.ClearScreen(Color.White);
                GameLogic.Process();
                GameLogic.Renderer.Render();
                SwinGame.DrawFramerate(10, 10);
                SwinGame.RefreshScreen(60);
                //SwinGame.Delay(40);
            }
        }
    }
}
