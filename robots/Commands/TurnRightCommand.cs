using robots.Enums;

namespace robots.Commands
{
    public sealed class TurnRightCommand : IPositionCommand
    {
        public Position Execute(Position position)
        {
            position.Orientation = position.Orientation.Next();
            return position;
        }
    }
}
