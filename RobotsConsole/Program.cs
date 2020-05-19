using System;
using Autofac;
using robots.Controllers;
using robots.Robots;

namespace RobotsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var robotsController = scope.Resolve<IRobotsController>();

                robotsController.AddRobot<MartianRobot>(1, 1, 'E', "RFRFRFRF");
                robotsController.AddRobot<MartianRobot>(3, 2, 'N', "FRRFLLFFRRFLL");
                robotsController.AddRobot<MartianRobot>(0, 3, 'W', "LLFFFLFLFL");
                
                robotsController.Run();
                
                Console.WriteLine(robotsController.GetRobotsDescription());
            }

            Console.ReadLine();

        }
    }
}
