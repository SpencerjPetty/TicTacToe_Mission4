using TicTacToe_Mission4;

// Initialize variables for tictactoe board and player moves 
char[] boardArray = new char[9];

int playerMove;

for (int i = 0; i < boardArray.Length; i++)
{
    boardArray[i] = (char)('1' + i);  // '1' is the ASCII character for the digit 1, and adding i shifts it to '2', '3', ..., '9'
}

// print board, assign player order and name and start the game!

bool player1Turn = true;

Console.WriteLine("Let's play Tic Tac Toe!");


// Get player names and ensure no null values
string player1Name = "";
while (string.IsNullOrEmpty(player1Name))
{
    Console.WriteLine("Player 1, enter your name:");
    player1Name = Console.ReadLine();
    if (string.IsNullOrEmpty(player1Name))
    {
        Console.WriteLine("Name cannot be empty. Please enter a valid name.");
    }
}

string player2Name = "";
while (string.IsNullOrEmpty(player2Name))
{
    Console.WriteLine("Player 2, enter your name:");
    player2Name = Console.ReadLine();
    if (string.IsNullOrEmpty(player2Name))
    {
        Console.WriteLine("Name cannot be empty. Please enter a valid name.");
    }
}

Console.WriteLine($"Welcome {player1Name} and {player2Name}!");

Console.WriteLine($"{player1Name}, you are X. {player2Name}, you are O.");

Console.WriteLine("Press any key to start the game.");
Console.ReadKey();

Console.WriteLine($"{player1Name}, you go first.");

Tools.PrintDisplay(boardArray);


// Enter loop to play the game, pass player names and board to track the winner
while (!Tools.IsGameOver(boardArray, player1Name, player2Name))
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

