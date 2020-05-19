using System;
using robots.Enums;

namespace robots.Commands
{
    public sealed class MoveForwardCommand : IPositionCommand
    {
        public Position Execute(Position position)
        {
            switch (position.Orientation)
            {
                case Orientation.North:
                    position.Y++;
                    break;
                case Orientation.South:
                    position.Y--;
                    break;
                case Orientation.East:
                    position.X++;
                    break;
                case Orientation.West:
                    position.X--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(position.Orientation), "Unknown position.Orientation value!");
            }

            return position;
        }
    }
}
