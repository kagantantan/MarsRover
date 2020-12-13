using MarsRover.Common;
using MarsRover.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain.LandingSurfaces
{
    public class MarsPlateau: ILandingSurface
    {
        public Position UpperRight { get; set; }
        public Position LowerLeft { get; set; } = new Position(0, 0);

        public void SetUpperRightCoordinates(Position upperRight)
        {
            UpperRight = upperRight;
        }
    }
}
