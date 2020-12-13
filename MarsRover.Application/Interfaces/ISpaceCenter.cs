using MarsRover.Common;
using MarsRover.Common.Order;
using MarsRover.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Application.Interfaces
{
    public interface ISpaceCenter
    {
        void SetOrder(Order order);
        void SetLandingSize(Position upperRightCoordinatesOfLandingSurface);
        void SetSquad(ISquad squad);
        void StartProcess();
    }
}
