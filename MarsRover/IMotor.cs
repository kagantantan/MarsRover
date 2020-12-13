using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public interface IMotor
    {
        Position Move(Position currentPosition, Orientation orientation, int stepCount);
        long Turn(long currentDegree, long turningDegree);
    }
}
