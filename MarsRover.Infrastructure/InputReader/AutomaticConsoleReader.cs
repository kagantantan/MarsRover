using MarsRover.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Infrastructure.InputReader
{
    public class AutomaticConsoleReader : BaseInputReader, IInputReader
    {
        public AutomaticConsoleReader(IValidator validator) : base(validator)
        {

        }

        public override void ProcessInput()
        {
            var input = PrepareInput();
            Display(input);
            base.SetUpperRightCoordinatesOfLandingSurface(input[0]);
            base.SetOrder(input[1], input[2]);
            base.SetOrder(input[3], input[4]);
        }

        private void Display(List<string> input)
        {
            Console.WriteLine("Test Input:");
            foreach (var command in input)
            {
                Console.WriteLine(command);
            }
            Console.WriteLine("Expected Output:");
        }

        private List<string> PrepareInput()
        {
            List<string> preparedInput = new List<string>();
            preparedInput.Add("5 5");
            preparedInput.Add("1 2 N");
            preparedInput.Add("LMLMLMLMM");
            preparedInput.Add("3 3 E");
            preparedInput.Add("MMRMMRMRRM");
            return preparedInput;
        }
    }
}
