using MarsRover.Common;
using MarsRover.Domain.Interfaces;
using MarsRover.Infrastructure.InputReader;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MarsRover.Test
{
    public class InputReaderShould
    {
        private readonly Mock<IValidator> _mockValidator;
        private readonly Mock<BaseInputReader> _sut;

        public InputReaderShould()
        {
            _mockValidator = new Mock<IValidator>();
            _sut = new Mock<BaseInputReader>(_mockValidator.Object)
            {
                CallBase = true
            };
        }
        [Fact]
        public void SetUpperRightCoordinatesOfLandingSurface()
        {
            _mockValidator.Setup(x => x.LandingSurfaceCoordinatesValidator(It.IsAny<List<string>>()));
            _sut.Object.SetUpperRightCoordinatesOfLandingSurface("5 5");

            Assert.Equal(5, _sut.Object.SpaceCenterInput.UpperRightCoordinatesOfLandingSurface.X);
            Assert.Equal(5, _sut.Object.SpaceCenterInput.UpperRightCoordinatesOfLandingSurface.Y);
        }

        [Fact]
        public void SetOrder()
        {
            _mockValidator.Setup(x => x.LandingPositionValidator(It.IsAny<List<string>>()));
            _mockValidator.Setup(x => x.InstructionValidator(It.IsAny<string>()));
            _mockValidator.Setup(x => x.PositionInRange(It.IsAny<Position>(), It.IsAny<Position>(), It.IsAny<Position>(), It.IsAny<string>()));

            _sut.Object.SetOrder("1 2 N", "LMLMLMLMM");

            Assert.True(_sut.Object.SpaceCenterInput.SquadOrders.Count == 1);
            Assert.Equal("LMLMLMLMM", _sut.Object.SpaceCenterInput.SquadOrders.First().Instructions);
            Assert.Equal(1, _sut.Object.SpaceCenterInput.SquadOrders.First().LandingPosition.X);
            Assert.Equal(2, _sut.Object.SpaceCenterInput.SquadOrders.First().LandingPosition.Y);
            Assert.Equal(Orientation.N, _sut.Object.SpaceCenterInput.SquadOrders.First().Orientation);
        }
    }
}
