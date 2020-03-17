using Domain.Controllers;
using Domain.Model.Messages;
using Domain.Services.Grid;
using Domain.Services.Rover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain.Model.Exceptions;

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
    public void StartMission_HappyPath()
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

    [TestMethod]
    [ExpectedException(typeof(MoveOutOfBoundariesException))]
    public void StartMission_OutOfBoundariesNorth_Exception()
    {
      // Arrange
      var missionController = this.CreateMissionController();
      var missionInput = new MissionInput
      {
        Input = "5 5" + Environment.NewLine +
                "0 5 N" + Environment.NewLine +
                "M" + Environment.NewLine 
                
      };

      // Act
       missionController.StartMission(missionInput);

      // Assert - Exception
    }

    [TestMethod]
    [ExpectedException(typeof(MoveOutOfBoundariesException))]
    public void StartMission_OutOfBoundariesSouth_Exception()
    {
      // Arrange
      var missionController = this.CreateMissionController();
      var missionInput = new MissionInput
      {
        Input = "5 5" + Environment.NewLine +
                "0 0 S" + Environment.NewLine +
                "M" + Environment.NewLine

      };

      // Act
      missionController.StartMission(missionInput);

      // Assert - Exception
    }

    [TestMethod]
    [ExpectedException(typeof(MoveOutOfBoundariesException))]
    public void StartMission_OutOfBoundariesEast_Exception()
    {
      // Arrange
      var missionController = this.CreateMissionController();
      var missionInput = new MissionInput
      {
        Input = "5 5" + Environment.NewLine +
                "5 0 E" + Environment.NewLine +
                "M" + Environment.NewLine

      };

      // Act
      missionController.StartMission(missionInput);

      // Assert - Exception
    }

    [TestMethod]
    [ExpectedException(typeof(MoveOutOfBoundariesException))]
    public void StartMission_OutOfBoundariesWest_Exception()
    {
      // Arrange
      var missionController = this.CreateMissionController();
      var missionInput = new MissionInput
      {
        Input = "5 5" + Environment.NewLine +
                "0 5 W" + Environment.NewLine +
                "M" + Environment.NewLine

      };

      // Act
      missionController.StartMission(missionInput);

      // Assert - Exception
    }
  }
}
