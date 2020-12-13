using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Common.Order
{
    public class Order
    {
        public Position LandingPosition { get; set; }
        public Orientation Orientation { get; set; }
        public string Instructions { get; set; }
    }
}
