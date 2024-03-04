
using System;

namespace Sudoku
{

    class Program
    {

        static void Main(string[] args)
        {
            Game game = new Game();
            bool isPlaying = true;
            int difficulty = 1; // Default difficulty level

            // Function to start or restart the game
            void StartGame()
            {
                // Initial game setup and difficulty selection
                Console.WriteLine("Select difficulty level:");
                Console.WriteLine("1 - Easy");
                Console.WriteLine("2 - Medium");
                Console.WriteLine("3 - Hard");
                Console.WriteLine("4 - Very Hard");
                difficulty = int.Parse(Console.ReadLine() ?? "1");
                game.GeneratePuzzle(difficulty); // Generate a new puzzle based on the difficulty level

                while (isPlaying)
                {
                    DisplayGrid(game);
                    Console.WriteLine("Enter 'row,col value', 'undo', 'restart', or 'q' to quit:");

                    string input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input)) continue;

                    if (input.ToLower() == "q")
                    {
                        isPlaying = false; // Exit the game loop and terminate the application
                        break;
                    }
                    else if (input.ToLower() == "restart")
                    {
                        Console.WriteLine();
                        Console.WriteLine("You have started a new game !");
                        Console.WriteLine();
                        StartGame(); // Restart the game with the same difficulty level
                        break; // Exit the current game loop to avoid recursion depth increase
                    }
                    else if (input.ToLower() == "undo")
                    {
                        if (game.UndoLastMove())
                        {
                            Console.WriteLine("Last move undone.");
                        }
                        else
                        {
                            Console.WriteLine("No moves to undo.");
                        }
                        continue;
                    }

                    // Process 'row,col value' input
                    string[] parts = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 3 && int.TryParse(parts[0], out int row) && int.TryParse(parts[1], out int col) && int.TryParse(parts[2], out int value))
                    {
                        row--; // Adjust for zero-based index (assuming 1-based input)
                        col--; // Adjust for zero-based index

                        if (row >= 0 && row < 9 && col >= 0 && col < 9 && value > 0 && value <= 9)
                        {
                            if (game.CanSetValue(row, col) || game.IsValidMove(row, col, value))
                            {
                                game.SetCellValue(row, col, value);
                                Console.WriteLine("Valid move! Continue playing.");
                                if (game.IsFullySolved())
                                {
                                    Console.WriteLine("Congratulations! You've solved the Sudoku!");
                                    isPlaying = false;
                                }
                            }
                            else
                            {

                                Console.WriteLine("Invalid move or cell cannot be modified. Please try again.");
                                // No need to undo the move here since it was never made
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please ensure all numbers are within the range 1-9 and row,col are valid.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid format. Please use 'row,col value'.");
                    }
                }
            }


            StartGame(); // Start the game for the first time

            Console.WriteLine("Thank you for playing!");
        }


        static void DisplayGrid(Game game)
        {
            Console.WriteLine(); // Add a space before displaying the grid

            // Display column headers
            Console.Write("    "); // Space for row numbers
            for (int header = 1; header <= 9; header++)
            {
                if (header % 3 == 1 && header != 1)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(" | "); // Separator for visual subgrid grouping
                    Console.ResetColor();
                }
                Console.Write($" {header} "); // Column numbers
            }
            Console.WriteLine();

            // Display the top border of the grid
            Console.Write("    "); // Align with the grid's indentation
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("---------------------------------"); // Top border
            Console.ResetColor();

            for (int row = 0; row < 9; row++)
            {
                // Row separator for visual subgrid grouping
                if (row % 3 == 0 && row != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("    ----------+-----------+----------"); // Subgrid row separator
                    Console.ResetColor();
                }

                // Display row number
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{row + 1} "); // Row numbers (1-based indexing)
                Console.ResetColor();

                for (int col = 0; col < 9; col++)
                {
                    // Column separator for visual subgrid grouping
                    if (col % 3 == 0 && col != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("|");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                    // Display cell value
                    int cellValue = game.GetCellValue(row, col);
                    if (cellValue == 0) // Assuming 0 represents an empty cell
                    {
                        Console.Write(" . ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; // Set number color
                        Console.Write($" {cellValue} ");
                        Console.ResetColor(); // Reset to default color
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor();
            // Display the bottom border of the grid
            Console.Write("    "); // Align with the grid's indentation
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("---------------------------------"); // Bottom border
            Console.ResetColor();

            Console.WriteLine(); // Add a space after displaying the grid
        }

    }
}




