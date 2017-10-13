using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EPAM.TicTacToe
{
    public partial class UIParameters : Window
    {
        public enum GameType { AlgorithmsTournament = 0, HumanVsAlgorihm = 1 };
        internal List<BattleParams> battleParams;
        public UIParameters()
        {
            InitializeComponent();

            battleParams = new List<BattleParams>();
            battleParams.Add(new BattleParams(3, 30, TimeSpan.FromSeconds(60), 20));
            dataGrid1.ItemsSource = battleParams;
            GameTypesComboBox.ItemsSource = Enum.GetValues(typeof(GameType));
            TeamList.ItemsSource = "Load team names".Split(',').ToList<string>();
        }

        internal void LoadAlgorithmsAssembly(object sender, RoutedEventArgs e)
        {
            Player player = new Player();
            TeamList.ItemsSource = player.GetTeamList(PlayerDllPath.Text);
            TeamList.SelectedItem = player.GetTeamList(PlayerDllPath.Text)[0];
        }

        internal void StartGame(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            Game game = new Game();

            game.RunGame(Convert.ToBoolean((int)GameTypesComboBox.SelectedValue), TeamList.SelectedValue.ToString(), PlayerDllPath.Text, sqlServerName.Text, dbLogin.Text, dbPassword.Text, dataGrid1.Items.OfType<BattleParams>().ToList());
            ((Button)sender).IsEnabled = true;
        }

        //private bool ValidateParams()
        //{
        //    bool isValid = true;



        //    return isValid;
        //}

        internal void AddRowToBattleParams(object sender, RoutedEventArgs e)
        {
            battleParams.Add(new BattleParams(0, 0, TimeSpan.FromSeconds(0), 0));
            dataGrid1.Items.Refresh();
        }

        internal void RemoveRowFromBattleParams(object sender, RoutedEventArgs e)
        {
            if (battleParams.Count - 1 > 0)
            {
                battleParams.RemoveAt(battleParams.Count - 1);
                dataGrid1.Items.Refresh();
            }
        }
    }
}
