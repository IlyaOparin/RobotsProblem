namespace robots.Robots
{
    public interface IRobotsContext
    {
        bool IsPositionOutOfGrid(Position positionToCheck);
        bool IsAvailableMovement(Position positionToMove);
    }
}
