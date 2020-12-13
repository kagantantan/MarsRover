using Ardalis.GuardClauses;
using MarsRover.Common;
using MarsRover.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Infrastructure.Validators
{
    public class CustomValidator : IValidator
    {
        public void EnumValidate(Type enumType, string input)
        {
            if (!Enum.IsDefined(enumType, input))
            {
                throw new ArgumentException($"Unsupported Enum Type : {enumType.Name}");
            }
        }

        public void PositionInRange(Position input, Position lowerPosition, Position upperPosition, string parameterName)
        {
            Guard.Against.OutOfRange(input.X, parameterName, lowerPosition.X, upperPosition.X);
            Guard.Against.OutOfRange(input.Y, parameterName, lowerPosition.Y, upperPosition.Y);
        }

        public void UserInputNullOrWhiteSpace(string input, string parameterName)
        {
            Guard.Against.NullOrWhiteSpace(input, parameterName);
        }
        public void LandingSurfaceCoordinatesValidator(List<string> LandingSurfaceCoordinates)
        {
            ArgumentCountValidator(LandingSurfaceCoordinates.Count, 2);
            
            foreach (var landingSurfaceCoordinate in LandingSurfaceCoordinates)
            {
                ArgumentTypeShouldBeIntegerValidator(landingSurfaceCoordinate);
            }
        }

        public void LandingPositionValidator(List<string> LandingPosition)
        {
            ArgumentCountValidator(LandingPosition.Count, 3);
            ArgumentTypeShouldBeIntegerValidator(LandingPosition[0]);
            ArgumentTypeShouldBeIntegerValidator(LandingPosition[1]);
            EnumValidate(typeof(Orientation), LandingPosition[2]);
        }

        public void ArgumentCountValidator(int input, int expected)
        {
            if (input != expected)
            {
                throw new ArgumentException($"Position Contain {expected} Parameter");
            }
        }

        public void ArgumentTypeShouldBeIntegerValidator(string input)
        {
            if (!int.TryParse(input, out int expected))
            {
                throw new ArgumentException("Position Coordinates Should Be Integer");
            }
        }

        public void InstructionValidator(string Instructions)
        {
            foreach (var instruction in Instructions)
            {
                EnumValidate(typeof(Instruction), instruction.ToString());
            }    
        }
    }
}
