using System;
using Domain.Model.Rover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Test.Model.Rover
{
  [TestClass]
  public class RoverTests
  {

    [TestMethod]
    public void SetPosition_SanitizeWhiteSpaces()
    {
      // Arrange 
      IRover rover = new Domain.Model.Rover.Rover();
      rover.SetPosition("    5   5    N                                       ");
      Assert.IsTrue(rover.GetPosition() == "5 5 N");
    }

    [TestMethod]
    public void RotateLeftFromNorth_ExpectedWest()
    {
      // Arrange
      IRover rover = new Domain.Model.Rover.Rover();
      rover.SetPosition("55N");

      // Act
      rover.RotateLeft();

      // Assert
      Console.WriteLine(rover.GetPosition());
      Assert.IsTrue(rover.GetPosition() == "5 5 W");
    }

    [TestMethod]
    public void RotateLeftFromEast_ExpectedNorth()
    {
      // Arrange
      IRover rover = new Domain.Model.Rover.Rover();
      rover.SetPosition("55E");

      // Act
      rover.RotateLeft();

      // Assert
      Assert.IsTrue(rover.GetPosition() == "5 5 N");
    }

    [TestMethod]
    public void RotateLeftFromSouth_ExpectedEast()
    {
      // Arrange
      IRover rover = new Domain.Model.Rover.Rover();
      rover.SetPosition("55S");

      // Act
      rover.RotateLeft();

      // Assert
      Assert.IsTrue(rover.GetPosition() == "5 5 E");
    }

    [TestMethod]
    public void RotateLeftFromWest_ExpectedSouth()
    {
      // Arrange
      IRover rover = new Domain.Model.Rover.Rover();
      rover.SetPosition("55W");

      // Act
      rover.RotateLeft();

      // Assert
      Assert.IsTrue(rover.GetPosition() == "5 5 S");
    }

    [TestMethod]
    public void RotateRightFromNorth_ExpectedEast()
    {
      // Arrange
      IRover rover = new Domain.Model.Rover.Rover();
      rover.SetPosition("55N");

      // Act
      rover.RotateRight();

      // Assert
      Assert.IsTrue(rover.GetPosition() == "5 5 E");
    }

    [TestMethod]
    public void RotateRightFromEast_ExpectedSouth()
    {
      // Arrange
      IRover rover = new Domain.Model.Rover.Rover();
      rover.SetPosition("55E");

      // Act
      rover.RotateRight();

      // Assert
      Assert.IsTrue(rover.GetPosition() == "5 5 S");
    }

    [TestMethod]
    public void RotateRightFromSouth_ExpectedWest()
    {
      // Arrange
      IRover rover = new Domain.Model.Rover.Rover();
      rover.SetPosition("55S");

      // Act
      rover.RotateRight();

      // Assert
      Assert.IsTrue(rover.GetPosition() == "5 5 W");
    }

    [TestMethod]
    public void RotateRightFromWest_ExpectedNorth()
    {
      // Arrange
      IRover rover = new Domain.Model.Rover.Rover();
      rover.SetPosition("55W");

      // Act
      rover.RotateRight();

      // Assert
      Assert.IsTrue(rover.GetPosition() == "5 5 N");
    }

    [TestMethod]
    public void MoveForwardFacingNorth()
    {
      // Arrange
      IRover rover = new Domain.Model.Rover.Rover();
      rover.SetPosition("55N");

      // Act
      rover.MoveForward();

      // Assert
      Assert.IsTrue(rover.GetPosition() == "5 6 N");
    }

    [TestMethod]
    public void MoveForwardFacingSouth()
    {
      // Arrange
      IRover rover = new Domain.Model.Rover.Rover();
      rover.SetPosition("55S");

      // Act
      rover.MoveForward();

      // Assert
      Assert.IsTrue(rover.GetPosition() == "5 4 S");
    }

    [TestMethod]
    public void MoveForwardFacingWest()
    {
      // Arrange
      IRover rover = new Domain.Model.Rover.Rover();
      rover.SetPosition("55W");

      // Act
      rover.MoveForward();

      // Assert
      Assert.IsTrue(rover.GetPosition() == "4 5 W");
    }

    [TestMethod]
    public void MoveForwardFacingEast()
    {
      // Arrange
      IRover rover = new Domain.Model.Rover.Rover();
      rover.SetPosition("55E");

      // Act
      rover.MoveForward();

      // Assert
      Assert.IsTrue(rover.GetPosition() == "6 5 E");
    }

  }
}
