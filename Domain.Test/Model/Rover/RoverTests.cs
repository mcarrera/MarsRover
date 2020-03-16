using Domain.Model.Enums;
using Domain.Model.Position;
using Domain.Model.Rover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test.Model.Rover
{
  [TestClass]
  public class RoverTests
  {
    private static IRover _rover;

    [ClassInitialize]
    public static void TestFixtureSetup(TestContext context)
    {
      _rover = new Domain.Model.Rover.Rover();
      _rover.SetPosition(new Position
      {
        X = 1000,
        Y = 1000,
      });
    }

    [TestMethod]
    public void RotateLeftFromNorth_ExpectedWest()
    {
      // Arrange
      _rover.SetHeading(Heading.North);

      // Act
      _rover.RotateLeft();

      // Assert
      Assert.IsTrue(_rover.GetHeading() == Heading.West);
    }

    [TestMethod]
    public void RotateLeftFromEast_ExpectedNorth()
    {
      // Arrange
      _rover.SetHeading(Heading.East);

      // Act
      _rover.RotateLeft();

      // Assert
      Assert.IsTrue(_rover.GetHeading() == Heading.North);
    }

    [TestMethod]
    public void RotateLeftFromSouth_ExpectedEast()
    {
      // Arrange
      _rover.SetHeading(Heading.South);

      // Act
      _rover.RotateLeft();

      // Assert
      Assert.IsTrue(_rover.GetHeading() == Heading.East);
    }

    [TestMethod]
    public void RotateLeftFromWest_ExpectedSouth()
    {
      // Arrange
      _rover.SetHeading(Heading.West);

      // Act
      _rover.RotateLeft();

      // Assert
      Assert.IsTrue(_rover.GetHeading() == Heading.South);
    }

    [TestMethod]
    public void RotateRightFromNorth_ExpectedEast()
    {
      // Arrange
      _rover.SetHeading(Heading.North);

      // Act
      _rover.RotateRight();

      // Assert
      Assert.IsTrue(_rover.GetHeading() == Heading.East);
    }

    [TestMethod]
    public void RotateRightFromEast_ExpectedSouth()
    {
      // Arrange
      _rover.SetHeading(Heading.East);

      // Act
      _rover.RotateRight();

      // Assert
      Assert.IsTrue(_rover.GetHeading() == Heading.South);
    }

    [TestMethod]
    public void RotateRightFromSouth_ExpectedWest()
    {
      // Arrange
      _rover.SetHeading(Heading.South);

      // Act
      _rover.RotateRight();

      // Assert
      Assert.IsTrue(_rover.GetHeading() == Heading.West);
    }

    [TestMethod]
    public void RotateRightFromWest_ExpectedNorth()
    {
      // Arrange
      _rover.SetHeading(Heading.West);

      // Act
      _rover.RotateRight();

      // Assert
      Assert.IsTrue(_rover.GetHeading() == Heading.North);
    }

    [TestMethod]
    public void MoveForwardFacingNorth()
    {
      // Arrange
      _rover.SetHeading(Heading.North);

      // Act
      var x = _rover.GetPosition().X;
      var y = _rover.GetPosition().Y;
      _rover.MoveForward();

      // Assert
      Assert.IsTrue(_rover.GetPosition().X == x && _rover.GetPosition().Y == y + 1);
    }

    [TestMethod]
    public void MoveForwardFacingSouth()
    {
      // Arrange
      _rover.SetHeading(Heading.South);

      // Act
      var x = _rover.GetPosition().X;
      var y = _rover.GetPosition().Y;
      _rover.MoveForward();

      // Assert
      Assert.IsTrue(_rover.GetPosition().X == x && _rover.GetPosition().Y == y - 1);
    }

    [TestMethod]
    public void MoveForwardFacingWest()
    {
      //Arrange
      _rover.SetHeading(Heading.West);

      //  Act
      var x = _rover.GetPosition().X;
      var y = _rover.GetPosition().Y;
      _rover.MoveForward();

      //   Assert
      Assert.IsTrue(_rover.GetPosition().X == x - 1 && _rover.GetPosition().Y == y);
    }

    //[TestMethod]
    public void MoveForwardFacingEast()
    {
      //Arrange
      _rover.SetHeading(Heading.East);

      //  Act
      var x = _rover.GetPosition().X;
      var y = _rover.GetPosition().Y;
      _rover.MoveForward();

      //   Assert
      Assert.IsTrue(_rover.GetPosition().X == x + 1 && _rover.GetPosition().Y == y);
    }

  }
}
