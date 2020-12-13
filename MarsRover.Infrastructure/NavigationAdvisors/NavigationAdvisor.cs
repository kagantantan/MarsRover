using MarsRover.Common;
using MarsRover.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Infrastructure.NavigationAdvisors
{
    public class NavigationAdvisor : INavigationAdvisor
    {
        public Position CalculateDestinationPosition(Position position, Orientation orientation, int distance)
        {
            switch (orientation)
            {
                case Orientation.N:
                    position.Y += distance;
                    break;
                case Orientation.E:
                    position.X += distance;
                    break;
                case Orientation.S:
                    position.Y -= distance;
                    break;
                case Orientation.W:
                    position.X -= distance;
                    break;
                default:
                    break;
            }

            return position;
        }
        public Orientation CalculateDestinationOrientation(Orientation orientation, long turningDegree)
        {
            var newDegree = ((Convert.ToInt64(orientation) + turningDegree) + 360) % 360;
            return (Orientation)newDegree;
        }
    }
}
