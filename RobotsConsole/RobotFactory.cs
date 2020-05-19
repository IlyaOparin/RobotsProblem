using Autofac;
using robots;
using robots.Robots;

namespace RobotsConsole
{
    public sealed class RobotFactory : IRobotFactory
    {
        private readonly ILifetimeScope _container;

        public RobotFactory(ILifetimeScope container)
        {
            _container = container;
        }

        public IRobot CreateRobot<T>() where T : IRobot
        {
            return _container.Resolve<IRobot>();
        }
    }
}
