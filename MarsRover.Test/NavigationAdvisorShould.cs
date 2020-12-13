using MarsRover.Common;
using MarsRover.Infrastructure.NavigationAdvisors;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Test
{
    public class NavigationAdvisorShould
    {
        private readonly NavigationAdvisor _sut;
        public NavigationAdvisorShould()
        {
            _sut = new NavigationAdvisor();
        }
        [Theory]
        [InlineData(3, 4, Orientation.N, 3, 5)]
        [InlineData(3, 4, Orientation.S, 3, 3)]
        [InlineData(3, 4, Orientation.W, 2, 4)]
        [InlineData(3, 4, Orientation.E, 4, 4)]
        public void CalculateDestinationPosition(double currentXCoordinate, double currentYCoordinate, Orientation currentOrientation, double expectedXCoordinate, double expectedYCoordinate)
        {
            var currentPosition = new Position(currentXCoordinate, currentYCoordinate);

            var expectedPosition = new Position(expectedXCoordinate, expectedYCoordinate); ;

            _sut.CalculateDestinationPosition(currentPosition, currentOrientation, 1);

            Assert.Equal(expectedPosition.X, currentPosition.X);
            Assert.Equal(expectedPosition.Y, currentPosition.Y);
        }
        [Theory]
        [InlineData(Orientation.N, 90, Orientation.E)]
        [InlineData(Orientation.S, 90, Orientation.W)]
        [InlineData(Orientation.W, 90, Orientation.N)]
        [InlineData(Orientation.E, 90, Orientation.S)]
        [InlineData(Orientation.N, -90, Orientation.W)]
        [InlineData(Orientation.S, -90, Orientation.E)]
        [InlineData(Orientation.W, -90, Orientation.S)]
        [InlineData(Orientation.E, -90, Orientation.N)]
        public void CalculateDestinationOrientation(Orientation currentOrientation, long turningDegree, Orientation expectedOrientation)
        {
            var destinationOrientation = _sut.CalculateDestinationOrientation(currentOrientation, turningDegree);

            Assert.Equal(expectedOrientation, destinationOrientation);
        }
    }
}
