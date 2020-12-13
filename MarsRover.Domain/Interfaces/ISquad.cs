using MarsRover.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain.Interfaces
{
    public interface ISquad
    {
        void MoveForward();
        void TurnLeft();
        void TurnRight();
        void Deploy(Position position, Orientation orientation);
        void SendPositionReport();
    }
}
