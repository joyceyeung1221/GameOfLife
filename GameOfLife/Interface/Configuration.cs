using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public interface Configuration
    {
        public Universe SetupUniverse();
        public List<Location> SetInitalState(Universe universe);
        public int GetTermValue();
    }

}
