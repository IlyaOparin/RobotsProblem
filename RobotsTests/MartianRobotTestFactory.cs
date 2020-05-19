using robots;
using robots.Configurations;
using robots.Robots;

namespace RobotsTests
{
    public sealed class MartianRobotTestFactory : IRobotFactory
    {
        private readonly ICommandConfiguration _commandConfiguration;
        private readonly IRobotsContext _robotsContext;

        public MartianRobotTestFactory(ICommandConfiguration commandConfiguration, IRobotsContext robotsContext)
        {
            _commandConfiguration = commandConfiguration;
            _robotsContext = robotsContext;
        }

        public IRobot CreateRobot<T>() where T : IRobot
        {
            return new MartianRobot(_commandConfiguration, _robotsContext);
        }
    }
}
