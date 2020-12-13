using MarsRover.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain.Interfaces
{
    public interface INavigationAdvisor
    {
        Position CalculateDestinationPosition(Position position, Orientation orientation, int distance);
        Orientation CalculateDestinationOrientation(Orientation currentOrientation, long turningDegree);
    }
}
