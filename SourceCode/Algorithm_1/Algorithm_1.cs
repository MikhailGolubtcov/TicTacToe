using System;
namespace EPAM.TicTacToe
{
    [TeamName("First team")]
    public class Algorithm_1 : IPlayer
    {
        public CellCoordinates NextMove(CellState.cellState[,] currentState, byte qtyCellsForWin, bool isHuman, TimeSpan remainingTimeForGame, int remainingQtyMovesForGame)
        {
            CellCoordinates nextMove = new CellCoordinates();
            if (currentState[0,0] == CellState.cellState.Empty)
            {
                nextMove.X = 0;
                nextMove.Y = 0;
            }
            else if (currentState[1, 1] == CellState.cellState.Empty)
            {
                nextMove.X = 1;
                nextMove.Y = 1;
            }
            else if (currentState[1, 2] == CellState.cellState.Empty)
            {
                nextMove.X = 1;
                nextMove.Y = 2;
            }
            else if (currentState[2, 0] == CellState.cellState.Empty)
            {
                nextMove.X = 2;
                nextMove.Y = 0;
            }
            else if (currentState[2, 1] == CellState.cellState.Empty)
            {
                nextMove.X = 2;
                nextMove.Y = 1;
            }
            else if (currentState[2, 1] == CellState.cellState.Empty)
            {
                nextMove.X = 2;
                nextMove.Y = 0;
            }

            return nextMove;
        }
    }
}
