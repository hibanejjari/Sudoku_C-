using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Cell
    {
        private int value;
        private bool isFixed;

        public Cell(int value, bool isFixed)
        {
            this.value = value;
            this.isFixed = isFixed;
        }

        public int Value
        {
            get { return value; }
            set
            {
                if (!isFixed)
                {
                    this.value = value;
                }
            }
        }

        public bool IsFixed
        {
            get { return isFixed; }
            set { isFixed = value; }
        }
    }

}