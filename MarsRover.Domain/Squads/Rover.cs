using MarsRover.Common;
using MarsRover.Domain.Interfaces;

namespace MarsRover.Domain.Squads
{
    public class Rover : ISquad
    {
        private readonly ILandingSurface _landingSurface;
        private readonly INavigationAdvisor _navigationAdvisor;
        private readonly IReport _report;
        private readonly IValidator _validator; 
        public Position CurrentPosition { get; set; }
        public Orientation CurrentOrientation { get; set; }
        public Rover(ILandingSurface landingSurface, INavigationAdvisor navigationAdvisor, IReport report, IValidator validator)
        {
            _landingSurface = landingSurface;
            _navigationAdvisor = navigationAdvisor;
            _report = report;
            _validator = validator;
        }
        public void Deploy(Position position, Orientation orientation)
        {
            this.CurrentPosition = position;
            this.CurrentOrientation = orientation;
        }
        public void MoveForward()
        {
            var newPosition = _navigationAdvisor.CalculateDestinationPosition(CurrentPosition, CurrentOrientation, 1);
            ValidateToNewPosition(newPosition, "DestinationPoint");
            CurrentPosition = newPosition;
        }
        public void ValidateToNewPosition(Position position, string parameterName)
        {
            _validator.PositionInRange(position, _landingSurface.LowerLeft, _landingSurface.UpperRight, parameterName);
        }
        public void TurnLeft()
        {
            var newOrientation = _navigationAdvisor.CalculateDestinationOrientation(CurrentOrientation, -90);
            CurrentOrientation = newOrientation;
        }
        public void TurnRight()
        {
            var newOrientation = _navigationAdvisor.CalculateDestinationOrientation(CurrentOrientation, 90);
            CurrentOrientation = newOrientation;
        }
        public void SendPositionReport()
        {
            _report.SendPositionReport(CurrentPosition, CurrentOrientation);
        }
    }
}
