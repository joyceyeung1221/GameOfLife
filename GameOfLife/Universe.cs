using System;
namespace GameOfLife
{
    public class Universe
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public Universe(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public bool IsColumnOverUnveriseEdge(int num)
        {
            return num == 0 || num > Col;
        }

        public bool IsRowOverUniverseEdge(int num)
        {
            return num == 0 || num > Row;
        }

        public int GetColumnValueOfOtherEdge(int num)
        {
            if(num == 0)
            {
                return Col;
            }
            return 1;
        }

        public int GetRowValueOfOtherEdge(int num)
        {
            if (num == 0)
            {
                return Row;
            }
            return 1;
        }
    }
}
