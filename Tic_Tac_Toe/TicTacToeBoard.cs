using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public class TicTacToeBoard
    {
        /*
         * 0: Normal Tic-tac-toe
         *      NxN, N in a row, X and O
         * 1: Misere Tic-tac-toe (Avoidance Tic-tac-toe)
         *      NxN, N in a row, X and O
         *      The player who get N in a row loses
         * 2: Nokato Tic-tac-toe
         *      NxN, N in a row, X
         *      The player who get N in a row loses
         * 3: Wild Tic-tac-toe (Your Choice Tic-tac-toe)
         *      NxN, N in a row, X and Order
         *      Player chooses X or O each turn
         * 4: Devil's Tic-tac-toe
         *      NxN, N in a row, X and O
         *      Player chooses X or O each turn
         *      The player who get N in a row loses
         * 5: Revenge Tic-tac-toe
         *      NxN, N in a row, X and O
         *      Player who gets N-in-a-row unless opponent can create n-in-a-row in the next turn
         * 6: Random Tic-tac-toe
         *      NxN, N in a row, X and O
         *      Random turn each turn
         * 7: Ultimate Tic-tac-toe
         *      9x9, N in a row, X and O
         *      each 3x3 square is a normal Tic-tac-toe game
         *      Forced to play on a board based on last move
         * 8: 3D Tic-tac-toe
         *      NxNxN, N in a row, X and O
         */
        public int gameMode;
        public int N { get; set; }
        public Cell[,] Grid { get; set; }
        public Cell[,,] ThreeDGrid { get; set; }

        public TicTacToeBoard()
        {
            Grid = new Cell[N, N];
            this.N = 3;
            this.Grid = new Cell[this.N, this.N];
            this.gameMode = 0;
        }

        public TicTacToeBoard(int size, int mode)
        {
            this.gameMode = mode;
            N = size;

            if (gameMode == 8)
            {
                ThreeDGrid = new Cell[3, 3, 3];
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        for (int k = 0; k < N; k++)
                        {
                            ThreeDGrid[i, j, k] = new Cell();
                        }
                    }
                }
                this.ThreeDGrid = ThreeDGrid;
            }
            else
            {
                Grid = new Cell[N, N];
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Grid[i, j] = new Cell();
                    }
                }
                this.Grid = Grid;
            }


            
        }

        public TicTacToeBoard(int mode)
        {
            switch (mode)
            {
                case 1:
                    N = 3;
                    Grid = new Cell[N, N];
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            Grid[i, j] = new Cell();
                        }
                    }
                    break;
            }

        }

        public override string ToString()
        {
            string ticTacToeBoardStr = " ";
            for (int k = 0; k < N; k++)
            {
                ticTacToeBoardStr += " " + k;
            }

            ticTacToeBoardStr += "\n";
            for (int i = 0; i < N; i++)
            {
                ticTacToeBoardStr += i;
                for (int j = 0; j < N; j++)
                {
                    ticTacToeBoardStr += " " + Grid[i, j];
                }

                ticTacToeBoardStr += "\n";
            }

            return ticTacToeBoardStr;
        }

        public bool isValidMove(Coordinates location, string mode)
        {
            if (gameMode == 8)
            {
                if(ThreeDGrid[location.row, location.col, location.depth].symbol != '\0')
                {
                    return false;
                }
                return true;
            }
            else
            {
                if (Grid[location.row, location.col].symbol != '\0')
                {
                    return false;
                }
                return true;
            }
        }

        public bool isValidMove(Coordinates location, string mode, Coordinates lastPlayerMove)
        {

            if(lastPlayerMove == null) { return true; }
            if (Grid[location.row, location.col].symbol != '\0' )
            {
                return false;
            }

            if(lastPlayerMove != null)
            {
                switch(lastPlayerMove.row % 3 + " " + lastPlayerMove.col % 3)
                {
                    case "0 0":
                        if(location.row >= 0 && location.row <= 2 && location.col >= 0 && location.col <= 2)
                        {
                            return true;
                        } else
                        {
                            return false;
                        }
                        break;
                    case "1 0":
                    //case "0 1":
                        if (location.row >= 3 && location.row <= 5 && location.col >= 0 && location.col <= 2)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "2 0":
                    // case "0 2":
                        if (location.row >= 6 && location.row <= 8 && location.col >= 0 && location.col <= 2)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "0 1":
                    //case "1 0":
                        if (location.row >= 0 && location.row <= 2 && location.col >= 3 && location.col <= 5)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "1 1":
                        if (location.row >= 3 && location.row <= 5 && location.col >= 3 && location.col <= 5)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "2 1":
                    // case "1 2":
                        if (location.row >= 6 && location.row <= 8 && location.col >= 3 && location.col <= 5)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "0 2":
                    // case "2 0":
                        if (location.row >= 0 && location.row <= 2 && location.col >= 6 && location.col <= 8)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "1 2":
                    // case "2 1":
                        if (location.row >= 3 && location.row <= 5 && location.col >= 6 && location.col <= 8)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "2 2":
                        if (location.row >= 6 && location.row <= 8 && location.col >= 6 && location.col <= 8)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                }
            }
            return true;
        }

        public void makeMove(Coordinates location, char playerSymbol, string mode)
        {
            if (gameMode == 8)
            {
                Cell currCell = ThreeDGrid[location.row, location.col, location.depth];
                currCell.symbol = playerSymbol;
            }
            else
            {
                Cell currCell = Grid[location.row, location.col];
                currCell.symbol = playerSymbol;
            }
        }


        public bool isWinner(char playerSymbol, string mode)
        {
            int counterHorizontal = 0;
            int counterVertical = 0;
            int counterDiagonal = 0;

            if (gameMode == 8)
            {
                return false;
            }
            else
            {
                if  ((Grid[0,0].symbol == playerSymbol & Grid[1,0].symbol == playerSymbol & Grid[2,0].symbol == playerSymbol) ||
                    (Grid[0,1].symbol == playerSymbol  & Grid[1,1].symbol == playerSymbol  & Grid[2,1].symbol == playerSymbol) ||
                    (Grid[0,2].symbol == playerSymbol  & Grid[1,2].symbol == playerSymbol  & Grid[2,2].symbol == playerSymbol) ||
                    (Grid[0,0].symbol == playerSymbol  & Grid[0,1].symbol == playerSymbol  & Grid[0,2].symbol == playerSymbol) ||
                    (Grid[1,0].symbol == playerSymbol  & Grid[1,1].symbol == playerSymbol  & Grid[1,2].symbol == playerSymbol) ||
                    (Grid[2,0].symbol == playerSymbol & Grid[2,1].symbol == playerSymbol  & Grid[2,2].symbol == playerSymbol) ||
                    (Grid[0,0].symbol == playerSymbol & Grid[1,1].symbol == playerSymbol & Grid[2,2].symbol == playerSymbol) ||
                    (Grid[0,2].symbol == playerSymbol & Grid[1,1].symbol == playerSymbol & Grid[2,0].symbol == playerSymbol))
                {
                    return true;
                } else
                {
                    return false;
                }
                /*
                // Horizontal
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Cell currCell = Grid[i, j];
                        char piece = currCell.symbol;
                        if (piece == playerSymbol)
                        {
                            counterHorizontal++;
                        }
                    }

                    if (counterHorizontal == N)
                    {
                        return true;
                    }
                    else
                    {
                        counterHorizontal = 0;
                    }
                }

                // Vertical
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Cell currCell = Grid[i, j];
                        char piece = currCell.symbol;
                        if (piece == playerSymbol)
                        {
                            counterVertical++;
                        }
                    }

                    if (counterVertical == N)
                    {
                        return true;
                    }
                    else
                    {
                        counterVertical = 0;
                    }
                }

                // Diagonal
                // Top Left to Bottom Right
                for (int j = 0; j < N; j++)
                {
                    Cell currCell = Grid[j, j];
                    char piece = currCell.symbol;
                    if (piece == playerSymbol)
                    {
                        counterDiagonal++;
                    }
                }

                if (counterDiagonal == N)
                {
                    return true;
                }
                else
                {
                    counterDiagonal = 0;
                }

                // Bottom Left to Top Right
                for (int i = 0; i < N; i++)
                {
                    for (int j = N - 1; j > 0; j--)
                    {
                        Cell currCell = Grid[i, j];
                        char piece = currCell.symbol;
                        if (piece == playerSymbol)
                        {
                            counterDiagonal++;
                        }

                    }
                }

                if (counterDiagonal == N)
                {
                    return true;
                }

                return false;
            */}
        }

        /*
        public void normalTicTacToeGameLoop()
        {
            while (!isWinner())
            {
                normalTicTacToeTurn();
                if (isWinner) { }
                normalTicTacToeTurn();
            }
        }

        public void normalTicTacToeTurn()
        {

        }

        public void misereTicTacToeGameLoop()
        {

        }

        public void MisereTicTacToeTurn()
        {

        }
        public void nokatoTicTacToeGameLoop()
        {

        }

        public void nokatoTicTacToeTurn()
        {

        }
        public void wildTicTacToeGameLoop()
        {

        }

        public void wildTicTacToeTurn()
        {

        }
        public void devilsTicTacToeGameLoop()
        {

        }

        public void devilsTicTacToeTurn()
        {

        }
        public void revengeTicTacToeGameLoop()
        {

        }

        public void revengeTicTacToeTurn()
        {

        }
        public void randomTicTacToeGameLoop()
        {

        }

        public void randomTicTacToeTurn()
        {

        }
        public void ultimateTicTacToeGameLoop()
        {

        }

        public void ultimateTicTacToeTurn()
        {

        }
        public void threeDTicTacToeGameLoop()
        {

        }

        public void threeDTicTacToeTurn()
        {

        }
        */
    }
}
