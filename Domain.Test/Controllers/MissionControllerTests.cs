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
    private MockRepository mockRepository;

    private Mock<IRoverService> mockRoverService;
    private Mock<IGridService> mockGridService;

    [TestInitialize]
    public void TestInitialize()
    {
      this.mockRepository = new MockRepository(MockBehavior.Strict);

      this.mockRoverService = this.mockRepository.Create<IRoverService>();
      this.mockGridService = this.mockRepository.Create<IGridService>();
    }

    private MissionController CreateMissionController()
    {
      return new MissionController(
          this.mockRoverService.Object,
          this.mockGridService.Object);
    }

    [TestMethod]
    public void StartMission_StateUnderTest_ExpectedBehavior()
    {
      // Arrange
      var missionController = this.CreateMissionController();
      MissionInput missionInput = null;

      // Act
      var result = missionController.StartMission(
        missionInput);

      // Assert
      Assert.Fail();
      this.mockRepository.VerifyAll();
    }
  }
}
