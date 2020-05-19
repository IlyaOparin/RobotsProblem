using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using robots.Configurations;
using robots.Controllers;
using robots.Planets;
using robots.Robots;

namespace RobotsTests
{
    [TestClass]
    public class RobotsControllerTest
    {
        [TestMethod]
        public void RunAndGetRobotsDescriptionTest()
        {
            // arrange

            var expected = $@"11 E{Environment.NewLine}33 N LOST{Environment.NewLine}23 S";

            var commandConfiguration = new CommandConfiguration();
            var robotsContext = new RobotsContext(new Mars(5, 3));

            var martianRobotsFactory = new MartianRobotTestFactory(commandConfiguration, robotsContext);
            IRobotsController robotsController = new RobotsController(martianRobotsFactory);

            robotsController.AddRobot<MartianRobot>(1, 1, 'E', "RFRFRFRF");
            robotsController.AddRobot<MartianRobot>(3, 2, 'N', "FRRFLLFFRRFLL");
            robotsController.AddRobot<MartianRobot>(0, 3, 'W', "LLFFFLFLFL");

            // act

            robotsController.Run();
            var actual = robotsController.GetRobotsDescription();

            // assert

            Assert.AreEqual(expected, actual.Trim());

        }
    }
}
