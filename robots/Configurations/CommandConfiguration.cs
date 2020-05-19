using System.Collections.Generic;
using robots.Commands;
using robots.Enums;

namespace robots.Configurations
{
    public sealed class CommandConfiguration : ICommandConfiguration
    {
        // TODO put mappings into config file

        private readonly IDictionary<char, IPositionCommand> _commandByInputSymbol = new Dictionary<char, IPositionCommand>()
        {
            ['L'] = new TurnLeftCommand(),
            ['R'] = new TurnRightCommand(),
            ['F'] = new MoveForwardCommand()
        };

        private readonly IDictionary<char, Orientation> _orientationByInputSymbol = new Dictionary<char, Orientation>()
        {
            ['N'] = Orientation.North,
            ['E'] = Orientation.East,
            ['S'] = Orientation.South,
            ['W'] = Orientation.West
        };

        private readonly IDictionary<Orientation, char> _outputSymbolByOrientationEnum = new Dictionary<Orientation, char>()
        {
            [Orientation.North] = 'N',
            [Orientation.East] = 'E',
            [Orientation.South] = 'S',
            [Orientation.West] = 'W'
        };

        public bool TryGetCommand(char commandSymbol, out IPositionCommand command)
        {
            return _commandByInputSymbol.TryGetValue(commandSymbol, out command);
        }

        public bool TryGetOrientation(char orientationSymbol, out Orientation orientation)
        {
            return _orientationByInputSymbol.TryGetValue(orientationSymbol, out orientation);
        }

        public bool TryGetOrientationOutputSymbol(Orientation orientation, out char orientationSymbol)
        {
            return _outputSymbolByOrientationEnum.TryGetValue(orientation, out orientationSymbol);
        }
    }
}
