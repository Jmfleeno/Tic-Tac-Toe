// Use Board Class from BoardLogic
using BoardLogic;
using System;

namespace TicTacToe {
    class Program {
        // Initialize Board
        static Board game = new Board();
        // Define Main Program
        static void Main(string[] args) {
            InitializeGame();
        }
        // Define Initialize Game Function
        private static void InitializeGame() { 
            int gameType = -1;
            Console.WriteLine("-----------------------------------\n-------Welcome to TicTacToe!-------\n-----------------------------------\nAre you playing 1 player or 2 player? (Enter 1 or 2)");
            while (gameType != 1 || gameType != 2) {

                // User Selects Game Type
                bool gameTypeSuccess = int.TryParse(Console.ReadLine(), out gameType);

                // If 1 Player Game Selected
                if (gameType == 1) {
                    // Initialize Variables
                    game = new Board();
                    int userTurn = -1;
                    int computerTurn = -1;
                    Random rand = new Random();

                    // Run Game
                    Console.WriteLine("You've chosen 1 Player! Let the Games Begin!\n");
                    while (game.checkForWinner() == 0) {
                        // Block user overwrite of an existing choice
                        while (userTurn == -1 || game.Grid[userTurn] != 0 || userTurn > 8) {
                            // Prompt User Turn
                            Console.WriteLine("Please enter an available number from 0 to 8");
                            bool userTurnSuccess = int.TryParse(Console.ReadLine(), out userTurn);
                        }
                        // Add user choice to board
                        game.Grid[userTurn] = 1;
                        if (game.isBoardFull())
                            break;

                        // Display Board
                        Console.WriteLine("Player 1 Turn:");
                        printBoard();
                        Console.WriteLine("\n");

                        // Block computer overwrite of an existing choice
                        while (computerTurn == -1 || game.Grid[computerTurn] != 0) {
                            // Run Computer Turn
                            computerTurn = rand.Next(8);
                        }
                        // Add computer choice to board
                        game.Grid[computerTurn] = 2;

                        if (game.isBoardFull())
                            break;

                        // Display Current Board
                        Console.WriteLine("Computers Turn:");
                        printBoard();
                        Console.WriteLine("\n");

                    }

                    // Determine Winner
                    Console.WriteLine(game.checkForWinner());
                    if (game.checkForWinner() == 0) {
                        Console.WriteLine("Game over! It's a Draw!\n");
                    } else {
                        Console.WriteLine("Game over! Player " + game.checkForWinner() + " won the game!\n");
                    }

                    // Check if User Wants to Play Again
                    Console.WriteLine("Want to play again? (Enter yes or no)");
                    string replayAnswer = Console.ReadLine();
                    if (replayAnswer == "yes") {
                        InitializeGame();
                    } else {
                        Console.WriteLine("\nThanks for playing!");
                        break;
                    }
                }

                // If 2 Player Game Selected
                else if (gameType == 2) {

                    // Initialize Variables
                    game = new Board();
                    int userTurn = -1;
                    int secondUserTurn = -1;

                    // Run Game
                    Console.WriteLine("You've chosen 2 Player! Let the Games Begin!\n");
                    while (game.checkForWinner() == 0) {
                        // Block Player 1 overwrite of an existing choice
                        while (userTurn == -1 || game.Grid[userTurn] != 0 || userTurn > 8) {
                            // Prompt Player 1 Turn
                            Console.WriteLine("Player 1 - Please enter an available number from 0 to 8");
                            bool userTurnSuccess = int.TryParse(Console.ReadLine(), out userTurn);
                        }

                        // Add Player 1 choice to board
                        game.Grid[userTurn] = 1;
                        if (game.isBoardFull())
                            break;

                        // Display Current Board
                        Console.WriteLine("Player 1 Turn:");
                        printBoard();
                        Console.WriteLine("\n");


                        // Block Player 2 overwrite of an existing choice
                        while (secondUserTurn == -1 || game.Grid[secondUserTurn] != 0 || secondUserTurn > 8) {
                            // Prompt Player 2 Turn
                            Console.WriteLine("Player 2 - Please enter an available number from 0 to 8");
                            bool secondUserTurnSuccess = int.TryParse(Console.ReadLine(), out secondUserTurn);
                        }

                        // Add Player 2 choice to board
                        game.Grid[secondUserTurn] = 2;
                        
                        // Display Current Board
                        Console.WriteLine("Player 2 Turn:");
                        printBoard();
                        Console.WriteLine("\n");

                        // Check if Board is Full
                        if (game.isBoardFull())
                            break;
                    }

                    //  Determine Winner
                    if (game.checkForWinner() == 0) {
                        Console.WriteLine("Game over! It's a Draw!\n");
                    } else {
                        Console.WriteLine("Game over! Player " + game.checkForWinner() + " won the game!\n");
                    }

                    // Check if User Wants to Play Again
                    Console.WriteLine("Want to play again? (Enter yes or no)");
                    string replayAnswer = Console.ReadLine();
                    if (replayAnswer == "yes") {
                        InitializeGame();
                    } else {
                        Console.WriteLine("Thanks for playing!");
                        break;
                    }
                }

                // If Wrong Input Given for Game Type
                else if (gameType != 1 && gameType != 2) {
                    Console.WriteLine("Wrong Value Entered, \nAre you playing 1 player or 2 player? (Enter 1 or 2)");
                }
            }
        }
        // Define PrintBoard Function
        private static void printBoard() {
            // Loop over board squares
            for (int i = 0; i < 9; i++)
            {
                // Log the number on each square
                // 0 = not taken
                // 1 = player 1 (X)
                // 2 = player 2 (O)
                //Console.WriteLine("Square " + i + " contains " + board[i]);

                if (game.Grid[i] == 0)
                {
                    Console.Write(".");
                }
                if (game.Grid[i] == 1)
                {
                    Console.Write("X");
                }
                if (game.Grid[i] == 2)
                {
                    Console.Write("O");
                }

                // Pring a new line on every third square
                if (i == 2 || i == 5 || i == 8)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}

