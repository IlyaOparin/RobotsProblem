using System;
using robots.Configurations;

namespace robots.Robots
{
    public sealed class MartianRobot : IRobot
    {
        private readonly ICommandConfiguration _commandConfiguration;
        private readonly IRobotsContext _robotsContext;

        private Position _currentPosition;
        private string _instructions = string.Empty;

        private bool IsLost { get; set; }

        public MartianRobot(ICommandConfiguration commandConfiguration, IRobotsContext robotsContext)
        {
            _commandConfiguration = commandConfiguration;
            _robotsContext = robotsContext;
        }

        public void Initialize(int xStart, int yStart, char orientationStart, string instructions)
        {
            if (!ValidateInput(xStart, yStart, orientationStart, instructions))
            {
                return;
            }

            _commandConfiguration.TryGetOrientation(orientationStart, out var parsedOrientation);
            _currentPosition = new Position(xStart, yStart, parsedOrientation);
            _instructions = instructions;
        }

        private bool ValidateInput(int xStart, int yStart, char orientationStart, string instructions)
        {
            if (xStart < 0 || xStart > 50 || yStart < 0 || yStart > 50
                || instructions.Length > 99 || !_commandConfiguration.TryGetOrientation(orientationStart, out _))
            {
                // TODO write warnings to logs and put magic constants in config!
                return false;
            }

            return true;
        }

        public void Move()
        {
            if (string.IsNullOrEmpty(_instructions))
            {
                return;
            }

            foreach (var commandSymbol in _instructions)
            {
                if (IsLost)
                {
                    break;
                }

                if (!_commandConfiguration.TryGetCommand(commandSymbol, out var positionCommand))
                {
                    continue;
                }

                var newPosition = positionCommand.Execute(_currentPosition);

                var wasAllowedToMove = _robotsContext.IsAvailableMovement(newPosition);

                if (!wasAllowedToMove)
                {
                    continue;
                }

                IsLost = _robotsContext.IsPositionOutOfGrid(newPosition);

                if (!IsLost)
                {
                    _currentPosition = newPosition;
                }
            }
        }

        public override string ToString()
        {
            return $"{_currentPosition.X}{_currentPosition.Y} {(_commandConfiguration.TryGetOrientationOutputSymbol(_currentPosition.Orientation, out var definedOrientation) ? definedOrientation.ToString() : "Undefined")}{(IsLost ? " LOST" : String.Empty)}";
        }

    }
}
