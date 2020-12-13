using MarsRover.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain.Interfaces
{
    public interface IReport
    {
        void SendPositionReport(Position currentPosition, Orientation currentOrientation);
    }
}
