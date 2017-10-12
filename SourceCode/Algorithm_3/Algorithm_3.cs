using System;
namespace EPAM.TicTacToe
{
    [TeamName("Third team")]
    public class Algorithm_3 : IPlayer
    {
        public CellCoordinates NextMove(CellState.cellState[,] currentState, byte qtyCellsForWin, bool isVersusHuman, TimeSpan remainingTimeForGame, int remainingQtyMovesForGame)
        {
            CellCoordinates nextMove = new CellCoordinates();
            if (currentState[10, 10] == CellState.cellState.Empty)
            {
                nextMove.X = 10;
                nextMove.Y = 10;
            }
            else if (currentState[11, 6] == CellState.cellState.Empty)
            {
                nextMove.X = 11;
                nextMove.Y = 6;
            }
            else if (currentState[12, 13] == CellState.cellState.Empty)
            {
                nextMove.X = 12;
                nextMove.Y = 13;
            }

            return nextMove;
        }
    }
}
