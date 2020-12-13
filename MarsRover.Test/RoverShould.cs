using MarsRover.Domain.Interfaces;
using MarsRover.Domain.Squads;
using Moq;
using Xunit;
using MarsRover.Common;
using System;

namespace MarsRover.Test
{
    public class RoverShould
    {
        private readonly Rover _sut;
        private readonly Mock<IValidator> _mockValidator;
        private readonly Mock<INavigationAdvisor> _mockNavigationAdvisor;
        private readonly Mock<IReport> _mockReport;
        private readonly Mock<ILandingSurface> _mockLandingSurface;
        public RoverShould()
        {
            _mockValidator = new Mock<IValidator>();
            _mockNavigationAdvisor = new Mock<INavigationAdvisor>();
            _mockReport = new Mock<IReport>();
            _mockLandingSurface = new Mock<ILandingSurface>();
            _sut = new Rover(_mockLandingSurface.Object, _mockNavigationAdvisor.Object, _mockReport.Object, _mockValidator.Object);
        }
        [Fact]
        public void DeployToSurface()
        {
            var deployPosition = new Position(3, 5);
            var deployOritentation = Orientation.N;
            _sut.Deploy(deployPosition, deployOritentation);

            Assert.Equal(deployPosition, _sut.CurrentPosition);
            Assert.Equal(deployOritentation, _sut.CurrentOrientation);
        }

        [Theory]
        [InlineData(3, 4, Orientation.N, 3, 5)]
        [InlineData(3, 4, Orientation.S, 3, 3)]
        [InlineData(3, 4, Orientation.W, 2, 4)]
        [InlineData(3, 4, Orientation.E, 4, 4)]
        public void MoveForward(double currentXCoordinate, double currentYCoordinate, Orientation currentOrientation, double newXCoordinate, double newYCoordinate)
        {
            _sut.CurrentPosition = new Position(currentXCoordinate, currentYCoordinate);
            _sut.CurrentOrientation = currentOrientation;

            var newPosition = new Position(newXCoordinate, newYCoordinate);
            _mockNavigationAdvisor.Setup(x => x.CalculateDestinationPosition(It.IsAny<Position>(), It.IsAny<Orientation>(), 1)).Returns(newPosition);

            _mockValidator.Setup(x => x.PositionInRange(It.IsAny<Position>(), It.IsAny<Position>(), It.IsAny<Position>(), It.IsAny<string>()));

            _sut.MoveForward();
            Assert.Equal(newPosition, _sut.CurrentPosition);
        }

        [Fact]
        public void CouldNotMoveForward()
        {
            _mockNavigationAdvisor.Setup(x => x.CalculateDestinationPosition(It.IsAny<Position>(), It.IsAny<Orientation>(), 1)).Returns(It.IsAny<Position>());

            _mockValidator.Setup(x => x.PositionInRange(It.IsAny<Position>(), It.IsAny<Position>(), It.IsAny<Position>(), It.IsAny<string>())).Throws(new ArgumentOutOfRangeException("DestinationPoint"));
            
            Assert.Throws<ArgumentOutOfRangeException>("DestinationPoint", () => _sut.MoveForward());
        }
        [Theory]
        [InlineData(Orientation.N, Orientation.W)]
        [InlineData(Orientation.S, Orientation.E)]
        [InlineData(Orientation.W, Orientation.S)]
        [InlineData(Orientation.E, Orientation.N)]
        public void TurnLeft(Orientation currentOrientation, Orientation newOrientation)
        {
            _sut.CurrentOrientation = currentOrientation;

            _mockNavigationAdvisor.Setup(x => x.CalculateDestinationOrientation(It.IsAny<Orientation>(), -90)).Returns(newOrientation);

            _sut.TurnLeft();
            Assert.Equal(newOrientation, _sut.CurrentOrientation);
        }

        [Fact]
        public void SendReport()
        {
            _mockReport.Setup(x => x.SendPositionReport(It.IsAny<Position>(), It.IsAny<Orientation>()));
            var ex = Record.Exception(() => _sut.SendPositionReport());

            Assert.Null(ex);
        }
        [Fact]
        public void CoultNotSendReport()
        {
            _mockReport.Setup(x => x.SendPositionReport(It.IsAny<Position>(), It.IsAny<Orientation>())).Throws(new Exception());

            var ex = Record.Exception(() => _sut.SendPositionReport());
            Assert.NotNull(ex);
        }
    }
}
