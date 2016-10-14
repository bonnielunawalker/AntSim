using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            SwinGame.OpenWindow("AntSim", GameState.WindowWidth, GameState.WindowHeight);
            Setup.Run();

            while (!SwinGame.WindowCloseRequested())
            {
                SwinGame.ClearScreen(Color.White);
                GameLogic.Process();
                GameLogic.Renderer.RenderAll();
                SwinGame.DrawFramerate(10, 10);
                SwinGame.RefreshScreen(60);
            }
        }
    }
}
