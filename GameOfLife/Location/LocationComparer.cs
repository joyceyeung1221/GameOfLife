using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class LocationComparer : IEqualityComparer<Location>
    {
        public bool Equals(Location a, Location b)
        {
            if (a == null || b == null)
                return false;

            return (a.Column == b.Column && a.Row == b.Row);
        }

        public int GetHashCode(Location obj)
        {
            return obj.GetHashCode();
        }

        public bool Contains(Location obj, List<Location> list)
        {
            if(list.Count == 0)
            {
                return false;
            }
            foreach(Location coordinate in list)
            {
                if (Equals(obj, coordinate))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
