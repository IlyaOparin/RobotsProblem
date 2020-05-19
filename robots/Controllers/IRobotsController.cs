using robots.Robots;

namespace robots.Controllers
{
    public interface IRobotsController
    {
        string GetRobotsDescription();
        void Run();
        void AddRobot<T>(int xStart, int yStart, char orientationStart, string instructions) where T : IRobot;
    }
}
