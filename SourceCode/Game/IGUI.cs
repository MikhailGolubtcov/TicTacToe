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
        //void LoadTeamNamesList(List<string> teamNamesList);
        //bool ReturnIsVersusHuman();
        //string ReturnTeamName();
        string ReturnPathToAlgorithms();
        List<BattleParams> ReturnBattleParams();
        void VisualizeNextMove(CellCoordinates cellCoordinates, CellState.cellState cellState);
        void ClearBattleField();
    }
}
