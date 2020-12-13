using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class RoverMotor : IMotor
    {
        public Position Move(Position currentPosition, Orientation orientation, int stepCount)
        {


            var newX = currentPosition.X + (stepCount * Math.Cos(Convert.ToInt64(orientation)));
            var newY = currentPosition.Y + (stepCount * Math.Sin(Convert.ToInt64(orientation)));

            var newPosition = currentPosition;
            switch (orientation)
            {
                case Orientation.N:
                    newPosition.Y += stepCount;
                    break;
                case Orientation.E:
                    newPosition.X += stepCount;
                    break;
                case Orientation.S:
                    newPosition.Y -= stepCount;
                    break;
                case Orientation.W:
                    newPosition.X -= stepCount;
                    break;
            };
            return newPosition;
        }

        public long Turn(long currentDegree, long turningDegree)
        {
            var newDegree = ((currentDegree + turningDegree) + 360) % 360;
            return newDegree;
        }
    }
}
