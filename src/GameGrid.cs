namespace MyGame
{
    public class GameGrid
    {
        private readonly IDrawable[,] _grid;

        public GameGrid()
        {
            _grid = new IDrawable[GameState.WindowWidth, GameState.WindowWidth];
        }

        public IDrawable[,] Grid
        {
            get { return _grid; }
        }

        public void Add(IDrawable drawable)
        {
            _grid[drawable.X, drawable.Y] = drawable;
        }
    }
}