using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.TicTacToe
{
    public class GUI_Test : IGUI
    {
        public void RunForm()
        {
            StartGame();
        }

        //bool ReturnIsVersusHuman()
        //{
        //    return true;
        //}

        //string ReturnTeamName()
        //{
        //    return "First team";
        //}

        public string ReturnPathToAlgorithms()
        {
            return "C:\\Users\\Mikhail_Golubtcov\\Documents\\TicTacToe\\Assemblies\\TestAlgorithms";
        }

        public List<BattleParams> ReturnBattleParams()
        {
            List<BattleParams> battleParams = new List<BattleParams>();
            BattleParams battleParam1 = new BattleParams(3, 7, TimeSpan.FromSeconds(20));
            battleParams.Add(battleParam1);

            return battleParams;
        }

        public void VisualizeNextMove(CellCoordinates cellCoordinates, PlayerCellState.playerCellState plCellState)
        {

        }

        public void ClearBattleField()
        {

        }

        public void StartGame()
        {
            //List<BattleParams> listBattleParams = new List<BattleParams>();
            //BattleParams battleParams = new BattleParams(3, 8, TimeSpan.FromSeconds(10));
            //listBattleParams.Add(battleParams);

            Game battle = new Game();
            battle.RunGame("hgv", ReturnBattleParams(), this);
        }


    }
}
