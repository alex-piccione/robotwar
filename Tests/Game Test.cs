using System;

using NUnit.Framework;
using RobotWar;


namespace Tests
{   
    public class GameTest
    {
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(0, 1)]
        [TestCase(0, 9)]
        [TestCase(9, 0)]
        [TestCase(9, 9)]
        public void IsPositionValid__should__return_True(int x, int y)
        {
            var game = new Game(9, 9);
            var position = new Position(x,y);
            Assert.IsTrue(game.IsPositionValid(position), $"x:{x}, y:{y}");
        }

        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(-1, -1)]
        [TestCase(10, 9)]
        [TestCase(9, 10)]
        [TestCase(10, 10)]
        public void IsPositionValid__should__return_False(int x, int y)
        {
            var game = new Game(9, 9);
            var position = new Position(x, y);
            Assert.IsFalse(game.IsPositionValid(position), $"x:{x}, y:{y}");
        }



        [TestCase(0,1)]
        [TestCase(1, 0)]
        [TestCase(1, 1)]
        [TestCase(1, 3)]
        [TestCase(3, 1)]
        [TestCase(3, 3)]
        public void IsPositionFree__should__return_True(int x, int y)
        {
            var game = new Game(9, 9);
            game.Robots = new Robot[] {
                new Robot(new Position(0, 0), 'N'),
                new Robot(new Position(2, 3), 'N')
            };

            Assert.IsTrue(game.IsPositionFree(new Position(x, y)));
        }

        [TestCase(0, 0)]
        [TestCase(2, 3)]
        public void IsPositionFree__should__return_False(int x, int y)
        {
            var game = new Game(9, 9);
            game.Robots = new Robot[] {
                new Robot(new Position(0, 0), 'N'),
                new Robot(new Position(2, 3), 'N')
            };

            Assert.IsFalse(game.IsPositionFree(new Position(x, y)));
        }



        [TestCase(0, 0, 'N', 0, 1)]
        [TestCase(0, 0, 'E', 1, 0)]
        [TestCase(0, 0, 'S', 0, -1)]
        [TestCase(0, 0, 'W', -1, 0)]
        public void CalculateNewPosition_N(int x1, int y1, char direction, int x2, int y2)
        {
            var initialPosition = new Position(x1, y1);
            var expectedPosition = new Position(x2, y2);

            var game = new Game(10, 10);

            // execute
            var newPosition = game.CalculateNewPosition(initialPosition, direction);

            Assert.AreEqual(x2, newPosition.x, "x");
            Assert.AreEqual(y2, newPosition.y, "y");
        }



        [TestCase('N', 'L', ExpectedResult = 'W')]
        [TestCase('N', 'R', ExpectedResult = 'E')]
        [TestCase('E', 'L', ExpectedResult = 'N')]
        [TestCase('E', 'R', ExpectedResult = 'S')]
        [TestCase('S', 'L', ExpectedResult = 'E')]
        [TestCase('S', 'R', ExpectedResult = 'W')]
        [TestCase('W', 'L', ExpectedResult = 'S')]
        [TestCase('W', 'R', ExpectedResult = 'N')]
        public char CalculateNewDirection(char currentDirection, char move)
            => new Game(10, 10).CalculateNewDirection(currentDirection, move);

    }
}
