using System;

namespace RobotWar
{
    class GameInputReader
    {
        public static Game CreateGame(string[] lines)
        {
            try
            {
                // first line contains area size
                var values = lines[0].Split(' ');
                int width = int.Parse(values[0]);
                int height = int.Parse(values[1]);

                // 2 lines for each robot
                var numberOfRobots = ((lines.Length - 1) / 2);

                var robots = new Robot[numberOfRobots];
                var moves = new string[numberOfRobots];

                for (int index = 0; index < numberOfRobots; index++)
                {
                    values = lines[index*numberOfRobots+1].Split(' ');
                    int x = int.Parse(values[0]);
                    int y = int.Parse(values[1]);
                    char direction = char.Parse(values[2]);

                    var robot = new Robot(new Position(x, y), direction);
                    robot.Commands = lines[index * numberOfRobots + 2].ToCharArray();
                    robots[index] = robot;
                }       

                var game = new Game(width, height)
                {
                    Robots = robots
                };

                return game;
            }
            catch (Exception exc)
            {
                throw new Exception("Failed to create Game from input.", exc);
            }
        }
    }
}
