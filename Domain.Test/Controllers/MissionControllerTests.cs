using Domain.Controllers;
using Domain.Model.Messages;
using Domain.Services.Grid;
using Domain.Services.Rover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Domain.Test.Controllers
{
  [TestClass]
  public class MissionControllerTests
  {


    private IMissionController CreateMissionController()
    {
      var missionController = new MissionController(new RoverService(), new GridService());
      return missionController;
    }

    [TestMethod]
    public void StartMission_StateUnderTest_ExpectedBehavior()
    {
      // Arrange
      var missionController = this.CreateMissionController();
      var missionInput = new MissionInput
      {
        Input = "5 5" + Environment.NewLine +
        "1 2 N" + Environment.NewLine +
        "LMLMLMLMM" + Environment.NewLine +
        "3 3 E" + Environment.NewLine +
        "MMRMMRMRRM"
      };

      // Act
      var result = missionController.StartMission(missionInput);

      // Assert

      Assert.IsTrue(result.RoversOutput.ContainsValue("1 3 N") &&
                    result.RoversOutput.ContainsValue("5 1 E"));

    }
  }
}
