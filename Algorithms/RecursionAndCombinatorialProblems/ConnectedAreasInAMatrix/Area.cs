using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedAreasInAMatrix
{
    public class Area
    {
        public Area(int row, int col, int size)
        {
            this.Row = row;
            this.Col = col;
            this.Size = size;
        }

        public int Row { get; private set; }

        public int Col { get; private set; }

        public int Size { get; private set; }
    }
}
