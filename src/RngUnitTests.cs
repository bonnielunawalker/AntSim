using System;
using NUnit.Framework;

namespace MyGame
{
    [TestFixture()]
    public class RngUnitTests
    {
        [Test()]
        public void DifferentRandTest()
        {
            Assert.AreNotEqual(GameLogic.Random.Next(720), GameLogic.Random.Next(720));
        }

        [Test()]
        public void DifferentLocationTest()
        {
            Location loc1 = new Location(GameLogic.Random.Next(720), GameLogic.Random.Next(480));
            Location loc2 = new Location(GameLogic.Random.Next(720), GameLogic.Random.Next(480));

            Creature c = new Creature(loc1);
            c.NewPath = c.GetPathTo(loc2);
            c.CurrentPath = c.NewPath;

            Assert.AreNotEqual(c.Location.X, c.CurrentPath.Destination.X);
        }
    }
}