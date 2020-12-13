using MarsRover.Application.Interfaces;
using MarsRover.Domain.Interfaces;

namespace MarsRover.Application.CommandHandlers
{
    public class TurnLeftCommand : ICommand
    {
        private readonly ISquad _squad;

        public TurnLeftCommand(ISquad squad)
        {
            _squad = squad;
        }

        public void Execute()
        {
            _squad.TurnLeft();
        }
    }
}
