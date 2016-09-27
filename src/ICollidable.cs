namespace MyGame
{
    public interface ICollidable: IDrawable
    {
        bool CheckCollision(Location l);


        int Size
        {
            get;
        }
    }
}