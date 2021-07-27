using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;
using ToyRobot.Exception;

namespace ToyRobotTest
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void Place_Move_GetReport()
        {
            var toyRobot = new ToyRobotDto();
            var toyRobotOperator = new ToyRobotOperator(new ToyRobotSimulator());

            toyRobotOperator.Do(toyRobot, "PLACE 0,0,NORTH");
            toyRobotOperator.Do(toyRobot, "MOVE");

            var report = toyRobot.ToString().ToUpper();
            Assert.AreEqual("0, 1, NORTH", report);
        }

        [TestMethod]
        public void Place_Rotate_GetReport()
        {
            var toyRobot = new ToyRobotDto();
            var toyRobotOperator = new ToyRobotOperator(new ToyRobotSimulator());

            toyRobotOperator.Do(toyRobot, "PLACE 0,0,NORTH");
            toyRobotOperator.Do(toyRobot, "LEFT");

            var report = toyRobot.ToString().ToUpper();
            Assert.AreEqual("0, 0, WEST", report);
        }

        [TestMethod]
        public void Place_Move_Move_Rotate_Move_GetReport()
        {
            var toyRobot = new ToyRobotDto();
            var toyRobotOperator = new ToyRobotOperator(new ToyRobotSimulator());

            toyRobotOperator.Do(toyRobot, "PLACE 1,2,EAST");
            toyRobotOperator.Do(toyRobot, "MOVE");
            toyRobotOperator.Do(toyRobot, "MOVE");
            toyRobotOperator.Do(toyRobot, "LEFT");
            toyRobotOperator.Do(toyRobot, "MOVE");

            var report = toyRobot.ToString().ToUpper();
            Assert.AreEqual("3, 3, NORTH", report);
        }

        [TestMethod]
        public void Place_Move_Rotate_Move_Place_Move_GetReport()
        {
            var toyRobot = new ToyRobotDto();
            var toyRobotOperator = new ToyRobotOperator(new ToyRobotSimulator());

            toyRobotOperator.Do(toyRobot, "PLACE 1,2,EAST");
            toyRobotOperator.Do(toyRobot, "MOVE");
            toyRobotOperator.Do(toyRobot, "LEFT");
            toyRobotOperator.Do(toyRobot, "MOVE");
            toyRobotOperator.Do(toyRobot, "PLACE 3,1");
            toyRobotOperator.Do(toyRobot, "MOVE");

            var report = toyRobot.ToString().ToUpper();
            Assert.AreEqual("3, 2, NORTH", report);
        }

        [TestMethod]
        public void Place_Move_Outside_The_Table_ThrowsException()
        {
            var toyRobot = new ToyRobotDto();
            var toyRobotOperator = new ToyRobotOperator(new ToyRobotSimulator());

            toyRobotOperator.Do(toyRobot, "PLACE 5,5,EAST");

            Assert.ThrowsException<OutsideOfTableException>(() => toyRobotOperator.Do(toyRobot, "MOVE"));
        }
    }
}
