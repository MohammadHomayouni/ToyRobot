using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;
using ToyRobot.Exception;

namespace ToyRobotTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Place_GetReport()
        {
            var toyRobot = new ToyRobotDto();
            var toyRobotOperator = new ToyRobotOperator(new ToyRobotSimulator());

            toyRobotOperator.Do(toyRobot, "PLACE 0,0,NORTH");

            var report = toyRobot.ToString().ToUpper();
            Assert.AreEqual("0, 0, NORTH", report);
        }

        [TestMethod]
        public void PlaceWithoutDirectionOnTheFirstCommand_ThrowsException()
        {
            var toyRobot = new ToyRobotDto();
            var toyRobotOperator = new ToyRobotOperator(new ToyRobotSimulator());
            
            Assert.ThrowsException<InvalidCommandException>(() => toyRobotOperator.Do(toyRobot, "PLACE 0,0"));
        }

        [TestMethod]
        public void PlaceWithInvalidArgs_ThrowsException()
        {
            var toyRobot = new ToyRobotDto();
            var toyRobotOperator = new ToyRobotOperator(new ToyRobotSimulator());

            Assert.ThrowsException<InvalidCommandArgumentsException>(() => toyRobotOperator.Do(toyRobot, "PLACE zero,zero"));
        }

        [TestMethod]
        public void Move_ThrowsException()
        {
            var toyRobot = new ToyRobotDto();
            var toyRobotOperator = new ToyRobotOperator(new ToyRobotSimulator());

            Assert.ThrowsException<InvalidCommandException>(() => toyRobotOperator.Do(toyRobot, "Move"));
        }

        [TestMethod]
        public void Right_ThrowsException()
        {
            var toyRobot = new ToyRobotDto();
            var toyRobotOperator = new ToyRobotOperator(new ToyRobotSimulator());

            Assert.ThrowsException<InvalidCommandException>(() => toyRobotOperator.Do(toyRobot, "Right"));
        }

        [TestMethod]
        public void Left_ThrowsException()
        {
            var toyRobot = new ToyRobotDto();
            var toyRobotOperator = new ToyRobotOperator(new ToyRobotSimulator());

            Assert.ThrowsException<InvalidCommandException>(() => toyRobotOperator.Do(toyRobot, "Left"));
        }
    }
}
