using Autofac;
using robots;
using robots.Configurations;
using robots.Controllers;
using robots.Planets;
using robots.Robots;

namespace RobotsConsole
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RobotFactory>().As<IRobotFactory>();

            builder.RegisterType<Mars>().As<GridModelPlanet>()
                .WithParameter("planetGridWidth", 5)
                .WithParameter("planetGridHeight", 3);

            builder.RegisterType<CommandConfiguration>().As<ICommandConfiguration>().SingleInstance(); // must be common for all robots

            builder.RegisterType<RobotsContext>().As<IRobotsContext>().SingleInstance(); // must be common for all robots

            builder.RegisterType<MartianRobot>().As<IRobot>();

            builder.RegisterType<RobotsController>().As<IRobotsController>();

            return builder.Build();

        }
    }
}
