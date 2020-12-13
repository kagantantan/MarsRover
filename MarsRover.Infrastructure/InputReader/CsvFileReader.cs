using MarsRover.Domain.Interfaces;
using System.IO;
using System.Linq;

namespace MarsRover.Infrastructure.InputReader
{
    public class CsvFileInputReader : BaseInputReader, IInputReader
    {
        public CsvFileInputReader(IValidator validator) : base(validator)
        {
        }
        public override void ProcessInput()
        {
            string[] input = File.ReadAllLines("Input.csv");
            var inputAboutLanding = input[0];
            var inputAboutSquad = input.Skip(1).ToArray();
            base.SetUpperRightCoordinatesOfLandingSurface(inputAboutLanding);
            SetSquadOrder(inputAboutSquad);
        }
        
        private void SetSquadOrder(string[] inputAboutSquad)
        {
            for (int i = 0; i < inputAboutSquad.Length; i += 2)
            {
                var landingPosition = inputAboutSquad[i]; 
                var instructions = inputAboutSquad[i + 1].ToString();
                base.SetOrder(landingPosition, instructions);
            }
        }
    }
}
