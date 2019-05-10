using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using RobotWar;


namespace Tests
{
    
    class Game_Play_Test
    {
        [Test]
        public void RunScenario_simple()
        {
            var input = File.ReadAllLines("Data/game_simple.txt");
            var game = Game.CreateGame(input);

            // execute
            game.Run();


            var robot_1 = game.Robots[0];
            Assert.AreEqual(1, robot_1.Position.x, "robot 1 x");
            Assert.AreEqual(1, robot_1.Position.y, "robot 1 y");
            Assert.AreEqual('E', robot_1.Direction, "robot 1 direction");
        }


        [Test]
        public void RunScenario_full()
        {
            var input = File.ReadAllLines("Data/game_full.txt");
            var game = Game.CreateGame(input);

            // execute
            game.Run();


            var robot_1 = game.Robots[0];
            Assert.AreEqual(1, robot_1.Position.x, "robot 1 x");
            Assert.AreEqual(3, robot_1.Position.y, "robot 1 y");
            Assert.AreEqual('N', robot_1.Direction, "robot 1 direction");

            var robot_2 = game.Robots[1];
            Assert.AreEqual(5, robot_2.Position.x, "robot 2 x");
            Assert.AreEqual(1, robot_2.Position.y, "robot 2 y");
            Assert.AreEqual('E', robot_2.Direction, "robot 2 direction");
        }
    }
}
