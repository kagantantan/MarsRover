using MarsRover.Common;
using MarsRover.Domain.LandingSurfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Test
{
    public class MarsPlateauSurfaceShould
    {
        private readonly MarsPlateau _sut;
        public MarsPlateauSurfaceShould()
        {
            _sut = new MarsPlateau();
        }
        [Fact]
        public void DefaultMarsPlateauLowerPosition()
        {
            Assert.Equal(0, _sut.LowerLeft.X);
            Assert.Equal(0, _sut.LowerLeft.Y);
        }
        [Fact]
        public void SetMarsPlateauSize()
        {
            var upperRightPosition = new Position(7, 8);
            _sut.SetUpperRightCoordinates(upperRightPosition);

            Assert.Equal(upperRightPosition.X, _sut.UpperRight.X);
            Assert.Equal(upperRightPosition.Y, _sut.UpperRight.Y);
        }
    }
}
