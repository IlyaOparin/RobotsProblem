using System.Collections.Generic;
using robots.Planets;

namespace robots.Robots
{
    public sealed class RobotsContext : IRobotsContext
    {
        private readonly GridModelPlanet _planetToWalk;
       
        private readonly List<Position> _badPositions = new List<Position>();

        public RobotsContext(GridModelPlanet planet)
        {
            _planetToWalk = planet;
        }

        public bool IsPositionOutOfGrid(Position positionToCheck)
        {
            if (positionToCheck.X < 0 || positionToCheck.X > _planetToWalk.GridWidth
                || positionToCheck.Y < 0 || positionToCheck.Y > _planetToWalk.GridHeight)
            {
                _badPositions.Add(positionToCheck);

                return true;
            }

            return false;
        }

        public bool IsAvailableMovement(Position positionToMove)
        {
            if (_badPositions.Exists(pos => pos.X == positionToMove.X
                                            && pos.Y == positionToMove.Y
                                            && pos.Orientation == positionToMove.Orientation))
            {
                return false; 
                // выставляем фолс, чтобы следующий робот не стал IsLost, но учитываем, что была попытка свалиться снова, поэтому команду не выполним
            }

            return true;
        }
    }
}
