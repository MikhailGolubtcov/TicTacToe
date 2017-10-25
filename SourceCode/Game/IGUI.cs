using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.TicTacToe
{
    public interface IGUI
    {
        void RunForm();
        string ReturnPathToAlgorithms();
        void VisualizeNextMove(CellCoordinates cellCoordinates, PlayerCellState.playerCellState plCellState);
        void ClearBattleField();
    }
}
