using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Mission4
{
    internal class Tools
    {

        public static bool IsGameOver(char[] boardArray)
        {
            bool result = false;

            string[] winningCombinations = new string[8]
            {
                "123", // Top row
                "456", // Middle row
                "789", // Bottom row
                "147", // Left column
                "258", // Middle column
                "369", // Right column
                "159", // Top-left to bottom-right diagonal
                "357"  // Top-right to bottom-left diagonal
            };
            
            foreach (string combination in winningCombinations)
            {
                string winningRowContent = "";
                
                for (int i = 0; i < combination.Length; i++)
                {
                    int index = combination[i] - '1';
                    winningRowContent += boardArray[index];
                }

                if (winningRowContent.ToLower() == "xxx")
                {
                    result = true;
                    Console.WriteLine("Player 1 (X) Wins!");
                }
                
                if (winningRowContent.ToLower() == "ooo")
                {
                    result = true;
                    Console.WriteLine("Player 2 (O) Wins!");
                }
            }
    
            // if no one has won
            if (!result)
            {
                bool boardFull = true;
                
                // loop through the array
                for (int i = 0; i < boardArray.Length; i++)
                {
                    char matchingIndex = (i + 1).ToString()[0];
                    
                    // check if each value is the number or not
                    if (boardArray[i] == matchingIndex)
                    {
                        boardFull = false;
                        break;
                    }
                }

                if (boardFull)
                {
                    result = true;
                    Console.WriteLine("No Player wins!");
                }
            }
            
            return result;
        }
        
        public static void PrintDisplay(char[] boardArray)
        {
            // Loop through each cell in the board array
            for (int i = 0; i < boardArray.Length; i++)
            {
                // Print the current cell X or O
                Console.Write($" {boardArray[i]} ");

                // Add grid dividers for the board 
                if ((i + 1) % 3 == 0 && i != 8) // End of row, but not the last cell
                {
                    Console.WriteLine("\n---+---+---");
                }
                else if ((i + 1) % 3 != 0) // Not the last cell in the row
                {
                    Console.Write("|");
                }
            }
            Console.WriteLine(); // Add a blank line after the board
        }
    }
}
