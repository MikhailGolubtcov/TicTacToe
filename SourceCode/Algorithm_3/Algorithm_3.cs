using System;
namespace EPAM.TicTacToe
{
    [TeamName("Third team")]
    public class Algorithm_3 : IPlayer
    {
        public CellCoordinates NextMove(CellState.cellState[,] currentState, byte qtyCellsForWin, bool isVersusHuman, TimeSpan remainingTimeForGame)
        {
            CellCoordinates nextMove = new CellCoordinates();
            if (currentState[1, 0] == CellState.cellState.Empty)
            {
                nextMove.X = 1;
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

            return nextMove;
        }

        public void RefreshUI(CellState.cellState[,] CurrentState)
        {

        }
    }
}
