using System;

namespace RobotWar
{
    public class Robot
    {
        public Position Position { get; set; }
        public char Direction { get; set; }
        public char[] Commands { get; set; }

        public Robot(Position position, char direction) {
            Position = position;
            Direction = direction;
        }
    }
}
