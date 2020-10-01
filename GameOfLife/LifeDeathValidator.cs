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
            return !IsUnderpopulated(neighbourhood) && !IsOvercrowded(neighbourhood);
        }

        private bool IsUnderpopulated(Neighbourhood neighbourhood)
        {
            return neighbourhood.LiveNeighbours.Count < 2;
        }

        private bool IsOvercrowded(Neighbourhood neighbourhood)
        {
            return neighbourhood.LiveNeighbours.Count > 3;
        }
    }
}
