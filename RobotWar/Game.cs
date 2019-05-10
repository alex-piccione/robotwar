using System;
using System.Linq;

namespace RobotWar
{

    public class Game : IGame
    {
        private int width;
        private int height;
        public Robot[] Robots { get; set; }


        public Game(int width, int height)
        {
            this.width = width;
            this.height = height;
            Robots = new Robot[0];
        }

        public static Game CreateGame(string[] input) => GameInputReader.CreateGame(input);

        /// <summary>
        /// Execute the commands of each robot sequentially (complete all the commands of a robot before passing to the next one).
        /// </summary>
        public void Run()
        {
            foreach (var robot in Robots)
                foreach (var command in robot.Commands)
                    if (command == 'M')
                    {
                        var newPosition = CalculateNewPosition(robot.Position, robot.Direction);
                        if (IsPositionValid(newPosition) && IsPositionFree(newPosition))
                            robot.Position = newPosition;
                    }
                    else
                        robot.Direction = CalculateNewDirection(robot.Direction, command);                
        }


        /// Calculate new position resulting from the move
        public Position CalculateNewPosition(Position initialPosition, char direction)
        {
            int x = initialPosition.x;
            int y = initialPosition.y;

            var _ = 
            direction == 'N' ? y++ :
            direction == 'E' ? x++ :
            direction == 'S' ? y-- :
                               x-- ;

            return new Position(x, y);
        }

        public char CalculateNewDirection(char currentDirection, char command) =>
            command == 'L' ?
                currentDirection == 'N' ? 'W' :
                currentDirection == 'E' ? 'N' :
                currentDirection == 'S' ? 'E' :
                                          'S' :
                currentDirection == 'N' ? 'E' :
                currentDirection == 'E' ? 'S' :
                currentDirection == 'S' ? 'W' 
                                        : 'N' ;


        public bool IsPositionFree(Position position) =>
            !Robots.Any(r => r.Position.x == position.x && r.Position.y == position.y);

        public bool IsPositionValid(Position position) =>
            position.x >= 0 && position.x <= width &&
            position.y >= 0 && position.y <= height;
    }
}
