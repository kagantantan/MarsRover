using MarsRover.Application.Interfaces;
using MarsRover.Domain.Interfaces;

namespace MarsRover.Application.CommandHandlers
{
    public class TurnRightCommand : ICommand
    {
        private readonly ISquad _squad;
        public TurnRightCommand(ISquad squad)
        {
            _squad = squad;
        }
        public void Execute()
        {
            _squad.TurnRight();
        }
    }
}
