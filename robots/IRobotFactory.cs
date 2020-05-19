using robots.Robots;

namespace robots
{
    public interface IRobotFactory
    {
        IRobot CreateRobot<T>() where T : IRobot;
    }
}
