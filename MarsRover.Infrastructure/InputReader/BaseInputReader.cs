using MarsRover.Common;
using MarsRover.Common.Order;
using MarsRover.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Infrastructure.InputReader
{
    public abstract class BaseInputReader : IInputReader
    {
        public Input SpaceCenterInput { get; set; } = new Input();
        private readonly IValidator _validator;

        protected BaseInputReader(IValidator validator)
        {
            _validator = validator;
        }
        public abstract void ProcessInput();
        public void SetUpperRightCoordinatesOfLandingSurface(string inputAboutLandingSurface)
        {
            var landingSurfaceCoordinates = inputAboutLandingSurface.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            _validator.LandingSurfaceCoordinatesValidator(landingSurfaceCoordinates);

            SpaceCenterInput.UpperRightCoordinatesOfLandingSurface = new Position
            {
                X = Convert.ToInt64(landingSurfaceCoordinates[0]),
                Y = Convert.ToInt64(landingSurfaceCoordinates[1]),
            };
        }
        public void SetOrder(string inputAboutLandingPosition, string inputAboutInstructions)
        {
            var landingPosition = inputAboutLandingPosition.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            _validator.LandingPositionValidator(landingPosition);
            _validator.InstructionValidator(inputAboutInstructions);
            _validator.PositionInRange(new Position(Convert.ToInt64(landingPosition[0]), Convert.ToInt64(landingPosition[1])), new Position(0, 0), SpaceCenterInput.UpperRightCoordinatesOfLandingSurface, "inputAboutLandingPosition");

            var order = new Order
            {
                Instructions = inputAboutInstructions,
                LandingPosition = new Position
                {
                    X = Convert.ToInt64(landingPosition[0]),
                    Y = Convert.ToInt64(landingPosition[1]),
                },
                Orientation = (Orientation)Enum.Parse(typeof(Orientation), landingPosition[2])
            };
            SpaceCenterInput.SquadOrders.Add(order);
        }
    }
}
