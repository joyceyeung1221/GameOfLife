using System;
namespace GameOfLife
{
    public class LifeDeathValidator
    {
        public LifeDeathValidator()
        {
        }

        public bool IsCellAliveAfterTick(Neighbourhood neighbourhood)
        {
            if(neighbourhood is LiveCellNeighbourhood)
            {
                return PerformCheckForLiveCell(neighbourhood);
            }
            return PerformCheckForDeadCell(neighbourhood);
        }

        private bool PerformCheckForDeadCell(Neighbourhood neighbourhood)
        {
            return HasThreeLiveCellNeighbours(neighbourhood);
        }

        private bool HasThreeLiveCellNeighbours(Neighbourhood neighbourhood)
        {
            return neighbourhood.LiveCellNeighbours.Count == 3;
        }

        private bool PerformCheckForLiveCell(Neighbourhood neighbourhood)
        {
            return !IsUnderpopulated(neighbourhood) && !IsOvercrowded(neighbourhood);
        }

        private bool IsUnderpopulated(Neighbourhood neighbourhood)
        {
            return neighbourhood.LiveCellNeighbours.Count < 2;
        }

        private bool IsOvercrowded(Neighbourhood neighbourhood)
        {
            return neighbourhood.LiveCellNeighbours.Count > 3;
        }
    }
}
