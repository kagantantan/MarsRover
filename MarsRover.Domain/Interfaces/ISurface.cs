using MarsRover.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain.Interfaces
{
    public interface ILandingSurface
    {
        Position UpperRight { get; set; }
        Position LowerLeft { get; set; }

        void SetUpperRightCoordinates(Position upperRight);
    }
}
