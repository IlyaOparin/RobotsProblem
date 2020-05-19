using robots.Commands;
using robots.Enums;

namespace robots.Configurations
{
    public interface ICommandConfiguration
    {
        bool TryGetCommand(char commandSymbol, out IPositionCommand outPositionCommand);
        bool TryGetOrientation(char orientationSymbol, out Orientation orientation);
        bool TryGetOrientationOutputSymbol(Orientation orientation, out char orientationSymbol);
    }
}
