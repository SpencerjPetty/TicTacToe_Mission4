using TicTacToe_Mission4;

char[] boardArray = new char[9];

int playerMove;

for (int i = 0; i < boardArray.Length; i++)
{
    boardArray[i] = (char)(i + 1);
}

bool player1Turn = true;

Console.WriteLine("Let's play Tic Tac Toe!");

Console.WriteLine("Player 1, enter your name:");
string player1Name = Console.ReadLine();

Console.WriteLine("Player 2, enter your name:");
string player2Name = Console.ReadLine();

Console.WriteLine($"{player1Name}, you are X. {player2Name}, you are O.");

Console.WriteLine("Press any key to start the game.");
Console.ReadKey();

Console.WriteLine($"{player1Name}, you go first.");

Tools.PrintDisplay(boardArray);

while (!IsGameOver(boardArray))
{
    if (player1Turn)
    {
        Console.WriteLine($"{player1Name}, it is your turn!");
    }
    else
    {
        Console.WriteLine($"{player2Name}, it is your turn!");
    }
    do
    {
        Console.Write("Please enter a single positive whole number: ");
        string input = Console.ReadLine();

        // Try to parse the input and check if it's a positive number
        if (int.TryParse(input, out playerMove) && playerMove > 0 && playerMove <= 9)
        {
            // Check if the selected cell is already taken
            if (boardArray[playerMove - 1] == 'X' || boardArray[playerMove - 1] == 'O')
            {
                Console.WriteLine("That cell is already taken. Please select another one.");
                continue;
            }
            break; // Exit the loop if valid input is provided
        }
        else
        {
            Console.WriteLine("Invalid input. Make sure to enter a whole number between 1 and 9.");
        }
    } while (true);
    
    // Update the board with the player's move
    boardArray[playerMove - 1] = player1Turn ? 'X' : 'O';

    Tools.PrintDisplay(boardArray);

    player1Turn = !player1Turn;
}

Console.WriteLine("Thank you for playing!");








