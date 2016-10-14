using System;
using System.Net;

namespace MyGame
{
    public static class Setup
    {
        public static void Run()
        {
            Console.WriteLine("Generating grid...");
            World.Touch();
            Console.WriteLine("Done!");
            Console.WriteLine("Generating entities...");
            GenerateEntities();
            Console.WriteLine("Done!");
            Console.WriteLine("Adding objects to game grid...");
            AddEntitiesToRenderer();
            Console.WriteLine("Done!");
        }

        private static void GenerateEntities()
        {
            World.Instance.Nest = new Nest(new Location(GameState.WindowWidth / 2, GameState.WindowHeight / 2));

            for (int i = 0; i < 1; i++)
                World.Instance.Nest.Ants.Add(new Ant(World.Instance.Nest));

            for (int i = 0; i < 5; i++)
                World.Instance.Foods.Add(new Food(new Location()));

            for (int i = 0; i < GameLogic.Random.Next(10, 40); i++)
                World.Instance.Obstacles.Add(new Obstacle(new Location()));
        }

        private static void AddEntitiesToRenderer()
        {
            GameLogic.Renderer.AddDrawable(World.Instance.Nest);

            foreach (Food f in World.Instance.Foods)
                GameLogic.Renderer.AddDrawable(f);

            foreach (Ant a in World.Instance.Nest.Ants)
                GameLogic.Renderer.AddDrawable(a);

//            foreach (Obstacle o in _obstacles)
//                GameLogic.Renderer.AddDrawable(o);
        }
    }
}