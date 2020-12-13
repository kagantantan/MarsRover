using MarsRover.Application.Interfaces;
using MarsRover.Common;
using MarsRover.Common.Order;
using MarsRover.Domain.Interfaces;

namespace MarsRover.Application.CommandHandlers
{
    public class DeployCommand : ICommand
    {
        private readonly ISquad _squad;
        private readonly Position landingPosition;
        private readonly Orientation orientation;
        public DeployCommand(ISquad squad, Order order)
        {
            _squad = squad;
            this.landingPosition = order.LandingPosition;
            this.orientation = order.Orientation;
        }
        public void Execute()
        {
            _squad.Deploy(landingPosition, orientation);
        }
    }
}
