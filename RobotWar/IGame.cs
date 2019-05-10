namespace RobotWar
{
    public interface IGame
    {
        Position CalculateNewPosition(Position initialPosition, char direction);
        char CalculateNewDirection(char currentDirection, char move);
        bool IsPositionFree(Position position);
        bool IsPositionValid(Position position);
    }
}
