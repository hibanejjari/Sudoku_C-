using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class GameEntity // Base class to demonstrate inheritance
    {
        protected string Name { get; set; } // Example property

        public GameEntity(string name)
        {
            Name = name;
        }
    }
}
