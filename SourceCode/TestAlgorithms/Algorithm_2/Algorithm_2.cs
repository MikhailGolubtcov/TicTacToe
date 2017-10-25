using System;
namespace EPAM.TicTacToe
{
    [TeamName("Second team")]
    public class Algorithm_2 : IPlayer
    {
        public CellCoordinates NextMove(CellState.cellState[,] currentState, byte qtyCellsForWin, TimeSpan remainingTimeForGame)
        {
            CellCoordinates nextMove = new CellCoordinates();
            if (currentState[0, 0] == CellState.cellState.Empty)
            {
                nextMove.X = 0;
                nextMove.Y = 0;
            }
            else if (currentState[0, 2] == CellState.cellState.Empty)
            {
                nextMove.X = 0;
                nextMove.Y = 2;
            }
            else if (currentState[2, 1] == CellState.cellState.Empty)
            {
                nextMove.X = 0;
                nextMove.Y = 2;
            }
            //else if (currentState[2, 2] == CellState.cellState.Empty)
            //{
            //    nextMove.X = 2;
            //    nextMove.Y = 2;
            //}
            //else if (currentState[2, 1] == CellState.cellState.Empty)
            //{
            //    nextMove.X = 2;
            //    nextMove.Y = 1;
            //}
            return nextMove;
        }

        public void RefreshUI(CellState.cellState[,] CurrentState)
        {

        }
    }
}
