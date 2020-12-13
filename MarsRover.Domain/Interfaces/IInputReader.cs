using MarsRover.Common.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain.Interfaces
{
    public interface IInputReader
    {
        Input SpaceCenterInput { get; set; }
        void ProcessInput();
    }
}
