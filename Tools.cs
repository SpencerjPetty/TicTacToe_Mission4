using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Mission4
{
    internal class Tools
    {

        public static bool IsGameOver(char[] boardArray, string player1Name, string player2Name)
        {
            bool result = false;
            
            // Set winning combinations
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
            
            // Loop through the winning combinations to check if there are any wins
            foreach (string combination in winningCombinations)
            {
                string winningRowContent = "";
                
                // Loop through each character of a combination and add up all existing values
                for (int i = 0; i < combination.Length; i++)
                {
                    int index = combination[i] - '1';
                    winningRowContent += boardArray[index];
                }
                
                if (winningRowContent.ToLower() == "xxx")
                {
                    result = true;
                    Console.WriteLine($"{player1Name} Wins! (X)");
                }
                
                if (winningRowContent.ToLower() == "ooo")
                {
                    result = true;
                    Console.WriteLine($"{player2Name} Wins! (O)");
                }
            }
    
            // if no one has won
            if (!result)
            {
                bool boardFull = true;
                
                // loop through the board
                for (int i = 0; i < boardArray.Length; i++)
                {
                    char matchingIndex = (i + 1).ToString()[0];
                    
                    // If there is a number we know the board is not full
                    if (boardArray[i] == matchingIndex)
                    {
                        boardFull = false;
                        break;
                    }
                }
                
                // If the board is still full end the game
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
            Console.Clear();
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
