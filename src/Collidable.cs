namespace MyGame
{
    public interface Collidable: Drawable
    {
        bool CheckCollision(Location l);


        int Size
        {
            get;
        }
    }
}
