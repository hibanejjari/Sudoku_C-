using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Move
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int OldValue { get; set; } // Ensure this property is defined

        public Move(int row, int col, int oldValue)
        {
            Row = row;
            Col = col;
            OldValue = oldValue;
        }
    }


}
