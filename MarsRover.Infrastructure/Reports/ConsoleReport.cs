using MarsRover.Common;
using MarsRover.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Infrastructure.Reports
{
    public class ConsoleReport : IReport
    {
        public void SendPositionReport(Position currentPosition, Orientation currentOrientation)
        {
            Console.WriteLine($"{currentPosition.X} {currentPosition.Y} {currentOrientation}");
        }
    }
}
