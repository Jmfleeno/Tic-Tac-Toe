using System;

namespace BoardLogic
{
    // Create Board Class
    public class Board
    {
        public int [] Grid
        {
            get; set;
        }
        // Create Board Constructor
        public Board()
        {
            // Initialize Grid
            Grid = new int[9];
            for (int i = 0; i < 9; i++)
            {
                Grid[i] = 0;
            }
        }

        // Check if Board is Full
        public bool isBoardFull()
        {
            bool isFull = true;
            for (int i = 0; i < Grid.Length; i++)
            {
                if (Grid[i] == 0)
                {
                    isFull = false;
                }
            }
            return isFull;
        }

        // Check for Game Winner
        public int checkForWinner()
        {
            // Return a 0 if nobody won and Player value if winner

            // Check First Row
            if (Grid[0] == Grid[1] && Grid[1] == Grid[2])
            {
                return Grid[0];
            }
            // Check Second Row
            if (Grid[3] == Grid[4] && Grid[4] == Grid[5])
            {
                return Grid[3];
            }
            // Check Third Row
            if (Grid[6] == Grid[7] && Grid[7] == Grid[8])
            {
                return Grid[6];
            }
            // Check First Column
            if (Grid[0] == Grid[3] && Grid[3] == Grid[6])
            {
                return Grid[0];
            }
            // Check Second Column
            if (Grid[1] == Grid[4] && Grid[4] == Grid[7])
            {
                return Grid[1];
            }
            // Check Third Column
            if (Grid[2] == Grid[5] && Grid[5] == Grid[8])
            {
                return Grid[2];
            }
            // Check First Diagonal
            if (Grid[0] == Grid[4] && Grid[4] == Grid[8])
            {
                return Grid[0];
            }
            // Check Second Diagonal
            if (Grid[6] == Grid[4] && Grid[4] == Grid[2])
            {
                return Grid[6];
            }
            return 0;
        }

    }
}

