using MarsRover.Application.Interfaces;
using MarsRover.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Application.CommandHandlers
{
    public class MoveForwardCommand : ICommand
    {
        private readonly ISquad _squad;

        public MoveForwardCommand(ISquad squad)
        {
            _squad = squad;
        }
        public void Execute()
        {
            _squad.MoveForward();
        }
    }
}
