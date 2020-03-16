using Domain.Model.Enums;
using Domain.Model.Position;
using Domain.Model.Rover;
using Domain.Services.Rover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test.Services.Rover
{
  [TestClass]
  public class RoverServiceTests
  {
    private static IRover _rover;
    private static IRoverService _service = new RoverService();

    [ClassInitialize]
    public static void TestFixtureSetup(TestContext context)
    {
      _service = new RoverService();
      _rover = new Domain.Model.Rover.Rover();

    }

    [TestInitialize]
    public  void SetRoverInitialPosition()
    {
      var initialRoverPosition = new Position { X = 1000, Y = 1000 };
      _rover.SetPosition(initialRoverPosition);
    }


    [TestMethod]
    public void SetGetRoverPosition()
    {
      // Arrange
      var expected = new Position { X = 0, Y = 0 };
      _service.SetRoverPosition(_rover, expected);

      // Act
      var actual = _service.GetRoverPosition(_rover);

      // Assert
      Assert.IsTrue(expected.X == actual.X &&
                    expected.X == actual.Y);
    }

    [TestMethod]
    public void SetGetRoverHeading()
    {
      // Arrange
      var expected = Heading.West;
      _service.SetRoverHeading(_rover, expected);

      // Act
      var actual = _service.GetRoverHeading(_rover);

      // Assert
      Assert.IsTrue(actual==expected);
    }

    [TestMethod]
    public void MoveRover_1()
    {
      // Arrange
     
    }
    //[TestMethod]
    //public void MoveRover_2()
    //{
    //  // Arrange
    //  IRoverService service = new RoverService();
    //  IRover rover = new Domain.Model.Position.Rover();
    //  rover.SetPosition("33E");
    //  var instructions = "MMRMMRMRRM";

    //  // Act
    //  service.MoveRover(rover, instructions);

    //  // Assert
    //  Assert.IsTrue(rover.GetPosition() == "5 1 E");
    //}

    //[TestMethod]
    //public void MoveRover_ExpectedSamePosition()
    //{
    //  // Arrange
    //  IRoverService service = new RoverService();
    //  IRover rover = new Domain.Model.Position.Rover();
    //  rover.SetPosition("00E");
    //  var instructions = "MMRRMM";

    //  // Act
    //  service.MoveRover(rover, instructions);

    //  // Assert
    //  Assert.IsTrue(rover.GetPosition() == "0 0 W");
    //}

    //[TestMethod]
    //public void MoveRover_ExpectedSamePositionAndHeading()
    //{
    //  // Arrange
    //  IRoverService service = new RoverService();
    //  IRover rover = new Domain.Model.Position.Rover();
    //  rover.SetPosition("00E");
    //  var instructions = "MMRRMMLL";

    //  // Act
    //  service.MoveRover(rover, instructions);

    //  // Assert
    //  Assert.IsTrue(rover.GetPosition() == "0 0 E");
  }

}

