using System;
namespace EPAM.TicTacToe
{
    [TeamName("Second team")]
    public class Algorithm_2 : IPlayer
    {
        public CellCoordinates NextMove(CellState.cellState[,] currentState, byte qtyCellsForWin, bool isVersusHuman, TimeSpan remainingTimeForGame, int remainingQtyMovesForGame)
        {
            CellCoordinates nextMove = new CellCoordinates();
            if (currentState[0, 1] == CellState.cellState.Empty)
            {
                nextMove.X = 0;
                nextMove.Y = 1;
            }
            else if (currentState[0, 2] == CellState.cellState.Empty)
            {
                nextMove.X = 0;
                nextMove.Y = 2;
            }
            else if (currentState[1, 0] == CellState.cellState.Empty)
            {
                nextMove.X = 1;
                nextMove.Y = 0;
            }
            else if (currentState[2, 2] == CellState.cellState.Empty)
            {
                nextMove.X = 2;
                nextMove.Y = 2;
            }
            else if (currentState[2, 1] == CellState.cellState.Empty)
            {
                nextMove.X = 2;
                nextMove.Y = 1;
            }
            return nextMove;
        }
    }
}
