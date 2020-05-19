using System.Collections.Generic;
using System.Text;
using robots.Robots;

namespace robots.Controllers
{
    public sealed class RobotsController : IRobotsController
    {
        private readonly IList<IRobot> _robots = new List<IRobot>();
        private readonly IRobotFactory _robotFactory;

        public RobotsController(IRobotFactory robotFactory)
        {
            _robotFactory = robotFactory;
        }

        public void AddRobot<T>(int xStart, int yStart, char orientationStart, string instructions) where T : IRobot
        {
            var robot = _robotFactory.CreateRobot<T>();
            robot.Initialize(xStart, yStart, orientationStart, instructions);
            _robots.Add(robot);
        }

        public string GetRobotsDescription()
        {
            var sb = new StringBuilder();
            foreach (var robot in _robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString();
        }

        public void Run()
        {
            foreach (var robot in _robots)
            {
                robot.Move();
            }
        }
    }
}
