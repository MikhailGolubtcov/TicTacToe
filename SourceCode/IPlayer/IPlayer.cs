using System;
namespace EPAM.TicTacToe
{
    public interface IPlayer
    {
        CellCoordinates NextMove(CellState.cellState[,] CurrentState, byte qtyCellsForWin, TimeSpan remainingTimeForGame);
    }
}
