using MarsRover.Application.CommandHandlers;
using MarsRover.Application.Interfaces;
using MarsRover.Common;
using MarsRover.Common.Exceptions;
using MarsRover.Common.Order;
using MarsRover.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Application.SpaceCenters
{
    public class Houston : ISpaceCenter
    {
        private readonly ILandingSurface _landingSurface;
        private readonly CommandManager _commandManager;
        public ISquad Squad { get; set; }
        public Order Order { get; set; }
        public Houston(ILandingSurface landingSurface, CommandManager commandManager)
        {
            _landingSurface = landingSurface;
            _commandManager = commandManager;
        }
        public void SetLandingSize(Position upperRightCoordinatesOfLandingSurface)
        {
            _landingSurface.SetUpperRightCoordinates(upperRightCoordinatesOfLandingSurface);
        }
        public void SetOrder(Order order)
        {
            Order = order;
        }
        public void SetSquad(ISquad squad)
        {
            Squad = squad;
        }
        public void StartProcess()
        {
            SetInstruction();

            _commandManager.InvokeAll();

            Squad.SendPositionReport();
        }

        private void SetInstruction()
        {
            _commandManager.Commands.Add(new DeployCommand(Squad, Order));
            foreach (var instruction in Order.Instructions)
            {
                switch (Enum.Parse(typeof(Instruction), instruction.ToString()))
                {
                    case Instruction.L:
                        _commandManager.Commands.Add(new TurnLeftCommand(Squad));
                        break;
                    case Instruction.R:
                        _commandManager.Commands.Add(new TurnRightCommand(Squad));
                        break;
                    case Instruction.M:
                        _commandManager.Commands.Add(new MoveForwardCommand(Squad));
                        break;
                    default:
                        throw new UnsupportedCommandException("Unsupported Command");
                }
            }
        }
    }
}
