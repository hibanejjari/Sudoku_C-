using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Grid
    {
        private Cell[,] cells = new Cell[9, 9];

        public Grid()
        {
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    cells[row, col] = new Cell(0, false); // Initially, cells are not fixed and set to 0
                }
            }
        }

        public void SetCell(int row, int col, int value)
        {
            if (row >= 0 && row < 9 && col >= 0 && col < 9)
            {
                cells[row, col].Value = value;
            }
        }

        public int GetCell(int row, int col)
        {
            if (row >= 0 && row < 9 && col >= 0 && col < 9)
            {
                return cells[row, col].Value;
            }
            return -1; // Indicate an invalid or out-of-bounds operation
        }

        // New SolveGrid method adapted for the Cell structure
        public bool SolveGrid()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (cells[row, col].Value == 0) // Find an empty cell
                    {
                        for (int num = 1; num <= 9; num++)
                        {
                            if (IsSafe(row, col, num))
                            {
                                cells[row, col].Value = num; // Try this number

                                if (SolveGrid())
                                {
                                    return true; // Solved successfully
                                }

                                cells[row, col].Value = 0; // Backtrack
                            }
                        }
                        return false; // No valid number found, backtrack
                    }
                }
            }
            return true; // All cells filled successfully
        }
        public bool IsValidMove(int row, int col, int num)
        {
            // Check if the number is valid in the given row and column
            for (int i = 0; i < 9; i++)
            {
                if (cells[row, i].Value == num || cells[i, col].Value == num)
                {
                    return false;
                }
            }

            // Check the 3x3 subgrid
            int startRow = row - row % 3;
            int startCol = col - col % 3;
            for (int r = startRow; r < startRow + 3; r++)
            {
                for (int c = startCol; c < startCol + 3; c++)
                {
                    if (cells[r, c].Value == num)
                    {
                        return false;
                    }
                }
            }

            // The move is valid if it doesn't violate Sudoku rules
            return true;
        }


        // Check if placing a number is safe according to Sudoku rules
        private bool IsSafe(int row, int col, int num)
        {
            // Row and column check
            for (int i = 0; i < 9; i++)
            {
                if (cells[row, i].Value == num || cells[i, col].Value == num)
                {
                    return false;
                }
            }

            // Subgrid check
            int startRow = row - row % 3, startCol = col - col % 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (cells[i + startRow, j + startCol].Value == num)
                    {
                        return false;
                    }
                }
            }

            return true; // The number does not violate any rule
        }
    }

   



}