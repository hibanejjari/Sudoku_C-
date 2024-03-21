
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{

    public class Score : GameEntity // Inheritance
    {
        private int points;

        public Score(string name, int points) : base(name)
        {
            this.points = points;
        }

        // Additional methods here
    }

}
