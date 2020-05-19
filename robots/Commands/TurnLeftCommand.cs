using robots.Enums;

namespace robots.Commands
{
    public sealed class TurnLeftCommand : IPositionCommand
    {
        public Position Execute(Position position)
        {
            position.Orientation = position.Orientation.Previous();
            return position;
        }
    }
}
