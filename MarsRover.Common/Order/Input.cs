using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Common.Order
{
    public class Input
    {
        public Position UpperRightCoordinatesOfLandingSurface { get; set; }
        public List<Order> SquadOrders { get; set; } = new List<Order>();
    }
}
