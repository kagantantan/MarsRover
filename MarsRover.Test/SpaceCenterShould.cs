using MarsRover.Application.CommandHandlers;
using MarsRover.Application.SpaceCenters;
using MarsRover.Common;
using MarsRover.Common.Order;
using MarsRover.Domain.Interfaces;
using MarsRover.Domain.Squads;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Test
{
    public  class SpaceCenterShould
    {
        private readonly Houston _sut;
        private readonly CommandManager _commandManager;
        private readonly Mock<ILandingSurface> _mockLandingSurface;
        private readonly Mock<ISquad> _mockSquad;
        public SpaceCenterShould()
        {
            _mockLandingSurface = new Mock<ILandingSurface>();
            _mockSquad = new Mock<ISquad>();
            _commandManager = new CommandManager();
            _sut = new Houston(_mockLandingSurface.Object, _commandManager);
            _sut.Order = new Order()
            {
                Instructions = "LMLMLMMR",
                LandingPosition = new Position(1, 1),
                Orientation = Orientation.N
            };
        }
        [Fact]
        public void SetLandingSize()
        {
            _mockLandingSurface.Setup(x => x.SetUpperRightCoordinates(It.IsAny<Position>()));
            var ex = Record.Exception(() => _sut.SetLandingSize(It.IsAny<Position>()));

            Assert.Null(ex);
        }
        [Fact]
        public void SetSquad()
        {
            _sut.SetSquad(_mockSquad.Object);

            Assert.Equal(_mockSquad.Object, _sut.Squad);
        }
        [Fact]
        public void SetOrder()
        {
            var newOrder = new Order()
            {
                Instructions = string.Empty,
                LandingPosition = new Position(1, 1),
                Orientation = Orientation.N
            };
            _sut.SetOrder(newOrder);

            Assert.Equal(newOrder, _sut.Order);
        }

        [Fact]
        public void StartProcess()
        {
            _sut.SetSquad(_mockSquad.Object);

            _sut.StartProcess();
            Assert.True(_commandManager.Commands.Count == 9);
            var ex = Record.Exception(() => _sut.StartProcess());
            Assert.Null(ex);
        }
        [Fact]
        public void ProcessFailedSurfaceBorderControl()
        {
            _sut.SetSquad(_mockSquad.Object);

            _mockSquad.Setup(x => x.MoveForward()).Throws(new ArgumentOutOfRangeException("DestinationPoint"));

            Assert.Throws<ArgumentOutOfRangeException>("DestinationPoint", () => _sut.StartProcess());
        }
    }
}
