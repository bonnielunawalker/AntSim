using System;

namespace MyGame
{
    public static class Setup
    {
        public static void Run()
        {
            Console.WriteLine("Generating entities...");
            GenerateEntities();
            Console.WriteLine("Done!");
            Console.WriteLine("Adding objects to game grid...");
            AddEntitiesToRenderer();
            Console.WriteLine("Done!");
        }

        private static void GenerateEntities()
        {
            GameLogic.Nest = new Nest(new Location(GameState.WindowWidth / 2, GameState.WindowHeight / 2));

            for (int i = 0; i < 1; i++)
                GameLogic.Nest.Ants.Add(new Ant(GameLogic.Nest));

            for (int i = 0; i < 5; i++)
                GameLogic.Foods.Add(new Food(new Location()));

            for (int i = 0; i < GameLogic.Random.Next(10, 40); i++)
                GameLogic.Obstacles.Add(new Obstacle(new Location()));
        }

        private static void AddEntitiesToRenderer()
        {
            GameLogic.Renderer.AddDrawable(GameLogic.Nest);

            foreach (Food f in GameLogic.Foods)
                GameLogic.Renderer.AddDrawable(f);

            foreach (Ant a in GameLogic.Nest.Ants)
                GameLogic.Renderer.AddDrawable(a);

//            foreach (Obstacle o in _obstacles)
//                GameLogic.Renderer.AddDrawable(o);
        }
    }
}