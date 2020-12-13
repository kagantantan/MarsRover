using MarsRover.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Infrastructure.InputReader
{
    public class ConsoleReader : BaseInputReader, IInputReader
    {
        public ConsoleReader(IValidator validator) : base(validator)
        {
        }

        public override void ProcessInput()
        {
            string inputAboutLandingSurface = Console.ReadLine();
            base.SetUpperRightCoordinatesOfLandingSurface(inputAboutLandingSurface);

            string inputAboutFirstSquadLandingPosition = Console.ReadLine();
            string inputAboutFirstSquadInstructions = Console.ReadLine();

            base.SetOrder(inputAboutFirstSquadLandingPosition, inputAboutFirstSquadInstructions);

            string inputAboutSecondSquadLandingPosition = Console.ReadLine();
            string inputAboutSecondSquadInstructions = Console.ReadLine();

            base.SetOrder(inputAboutSecondSquadLandingPosition, inputAboutSecondSquadInstructions);
        }
        
    }
}
