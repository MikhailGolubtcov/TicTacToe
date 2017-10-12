using System;
namespace EPAM.TicTacToe
{
    [TeamName("Second team")]
    public class Algorithm_2 : IPlayer
    {
        public CellCoordinates NextMove(CellState.cellState[,] currentState, byte qtyCellsForWin, bool isVersusHuman, TimeSpan remainingTimeForGame, int remainingQtyMovesForGame)
        {
            CellCoordinates nextMove = new CellCoordinates();
            if (currentState[2, 3] == CellState.cellState.Empty)
            {
                nextMove.X = 2;
                nextMove.Y = 3;
            }
            else if (currentState[3, 3] == CellState.cellState.Empty)
            {
                nextMove.X = 3;
                nextMove.Y = 3;
            }
            else if (currentState[5, 8] == CellState.cellState.Empty)
            {
                nextMove.X = 5;
                nextMove.Y = 8;
            }

            return nextMove;
        }
    }
}
