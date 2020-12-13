using MarsRover.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain.Interfaces
{
    public interface IValidator
    {
        void PositionInRange(Position input , Position lowerPosition, Position upperPosition, string parameterName);
        void EnumValidate(Type enumType, string input);
        void UserInputNullOrWhiteSpace(string input, string parameterName);
        void LandingSurfaceCoordinatesValidator(List<string> LandingSurfaceCoordinates);
        void LandingPositionValidator(List<string> LandingPosition);
        void InstructionValidator(string Instructions);
    }
}
