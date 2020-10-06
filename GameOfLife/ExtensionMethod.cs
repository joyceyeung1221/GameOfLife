using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public static class ExtensionMethod
    {
        public static bool IsContained(this List<Location> theList, Location locationToCheck)
        {
            if (theList.Count == 0)
            {
                return false;
            }
            foreach (Location location in theList)
            {
                if (location.IsEqual(locationToCheck))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
