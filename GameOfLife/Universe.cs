using System;
namespace GameOfLife
{
    public class Universe
    {
        private int _row;
        private int _col;

        public Universe(int row, int col)
        {
            _row = row;
            _col = col;
        }

        public bool IsXOverUnveriseEdge(int num)
        {
            return num == 0 || num > _col;
        }

        public bool IsYOverUniverseEdge(int num)
        {
            return num == 0 || num > _row;
        }

        public int GetXValueOfOtherEdge(int num)
        {
            if(num == 0)
            {
                return _col;
            }
            return 1;
        }

        public int GetYValueOfOtherEdge(int num)
        {
            if (num == 0)
            {
                return _row;
            }
            return 1;
        }
    }
}
