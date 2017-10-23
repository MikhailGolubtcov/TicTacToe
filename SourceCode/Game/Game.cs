using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Reflection;




namespace EPAM.TicTacToe
{
    internal class Game
    {
        private List<Player> allPlayersList;
        private List<Player> playersTournamentList = new List<Player>();
        private int currentQtyEmptyCellsOnBattleField;
        private bool hasExceptionsOccured;

        private CellState.cellState[,] CreateBattleField(byte maxLengthFieldOfBattlefield)
        {
            CellState.cellState[,] battleField = new CellState.cellState[maxLengthFieldOfBattlefield, maxLengthFieldOfBattlefield];
            return battleField;
        }

        //Setting point on battlefield based on xy-coordinates
        private string SetPointOnBattleField(CellCoordinates pointOnBattleField, Player algorithm, CellState.cellState[,] battleField, bool isVictory)
        {
            string settingPointResult = "";
            try
            {
                if (battleField[pointOnBattleField.X, pointOnBattleField.Y] == CellState.cellState.Empty)
                {
                    battleField[pointOnBattleField.X, pointOnBattleField.Y] = (CellState.cellState)algorithm.playerCellState;
                    currentQtyEmptyCellsOnBattleField -= 1;
                }
                else
                {
                    settingPointResult = "Non-empty cell";
                }
            }
            catch (IndexOutOfRangeException e)
            {
                PublishGameExceptions("Team \"" + algorithm.TeamName + "\" has returned coordinates outside the bound of battlefield.", e.ToString());
                settingPointResult = "Point is outside the bound";
            }

            return settingPointResult;
        }

        private bool CheckVictory(Player algorithm, CellCoordinates cellCoordinates, int maxCellCoordinate, byte qtyCellsForWin, byte maxLengthFieldOfBattlefield, CellState.cellState[,] battleField, bool isVictory, string battleResult)
        {
            int[] correctDifferenceCoordinates = { 1, maxLengthFieldOfBattlefield - 1, maxLengthFieldOfBattlefield, maxLengthFieldOfBattlefield + 1 };
            int initialCellCoordinate = cellCoordinates.X * 1000 + cellCoordinates.Y;
            int currentCellCoordinate;
            int prevCellCoordinate;

            byte currentQtyOfVictoryCells;
            bool isOppositeDirectionSearched;

            foreach (sbyte coordNumAdd in correctDifferenceCoordinates)
            {
                sbyte coordinateNumAdd = coordNumAdd;
                currentCellCoordinate = initialCellCoordinate;
                prevCellCoordinate = initialCellCoordinate;
                currentQtyOfVictoryCells = 0;
                isOppositeDirectionSearched = false;

                try
                {
                    while (currentCellCoordinate >= 0
                            && currentCellCoordinate / 1000 <= maxCellCoordinate / 1000
                            && currentCellCoordinate % 1000 <= maxCellCoordinate % 1000
                            && (CellState.cellState)battleField.GetValue(currentCellCoordinate / 1000, currentCellCoordinate % 1000) == (CellState.cellState)algorithm.playerCellState)
                    {
                        if (Math.Abs(currentCellCoordinate / 1000 - prevCellCoordinate / 1000) < 2
                            && Math.Abs(currentCellCoordinate % 1000 - prevCellCoordinate % 1000) < 2)
                        {
                            currentQtyOfVictoryCells += 1;
                        }

                        prevCellCoordinate = currentCellCoordinate;
                        currentCellCoordinate = AddNumToCoordinates(currentCellCoordinate, coordinateNumAdd, maxLengthFieldOfBattlefield);

                        if (currentCellCoordinate < 0
                            || currentCellCoordinate / 1000 > maxCellCoordinate / 1000
                            || currentCellCoordinate % 1000 > maxCellCoordinate % 1000)
                        {
                            if (!isOppositeDirectionSearched)
                            {
                                coordinateNumAdd = (sbyte)(0 - coordNumAdd);
                                currentCellCoordinate = AddNumToCoordinates(initialCellCoordinate, coordinateNumAdd, maxLengthFieldOfBattlefield);
                                prevCellCoordinate = initialCellCoordinate;
                                isOppositeDirectionSearched = true;
                            }
                        }
                        else if ((CellState.cellState)battleField.GetValue(currentCellCoordinate / 1000, currentCellCoordinate % 1000) != (CellState.cellState)algorithm.playerCellState
                                    && !isOppositeDirectionSearched)
                        {
                            coordinateNumAdd = (sbyte)(0 - coordNumAdd);
                            currentCellCoordinate = AddNumToCoordinates(initialCellCoordinate, coordinateNumAdd, maxLengthFieldOfBattlefield);
                            prevCellCoordinate = initialCellCoordinate;
                            isOppositeDirectionSearched = true;
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    PublishGameExceptions("CheckVictory engine has returned coordinates outside the bound of battlefield.", e.ToString());
                }

                if (currentQtyOfVictoryCells >= qtyCellsForWin)
                {
                    isVictory = true;
                    return isVictory;
                }
            }

            return isVictory;
        }

        private int AddNumToCoordinates(int number, int increment, byte maxLengthFieldOfBattlefield)
        {
            byte maxIndexFieldOfBattlefield = (byte)(maxLengthFieldOfBattlefield - 1);
            int num = number + increment;
            if ((number % 1000 + increment) > maxIndexFieldOfBattlefield && increment != 1)
            {
                num = (number / 1000 + 1) * 1000 + increment - (maxIndexFieldOfBattlefield - number % 1000 + 1);
            }

            else if ((number % 1000 + increment) < 0 && increment != -1)
            {
                num = (number / 1000 - 1) * 1000 + maxIndexFieldOfBattlefield + increment + number % 1000 + 1;
            };

            return num;
        }

        private void RunBattle(List<Player> playingPairOfPlayers, byte qtyCellsForWin, byte maxLengthFieldOfBattlefield)
        {
            CellState.cellState[,] battleField;
            bool isVictory = false;
            string battleResult = "";
            bool hasAlgorithmError;

            TimeSpan timeBeforePlayerMove;
            currentQtyEmptyCellsOnBattleField = maxLengthFieldOfBattlefield * maxLengthFieldOfBattlefield;
            sbyte algorithmIndex = 1;
            CellCoordinates nextMove = new CellCoordinates();
            int maxCellCoordinate = (maxLengthFieldOfBattlefield - 1) * 1000 + (maxLengthFieldOfBattlefield - 1);
            battleField = CreateBattleField(maxLengthFieldOfBattlefield);

            do
            {
                algorithmIndex = (SByte)((algorithmIndex - 1) * (-1));
                hasAlgorithmError = false;
                string settingPointResult = "";

                timeBeforePlayerMove = DateTime.Now.TimeOfDay;

                try
                {
                    nextMove = playingPairOfPlayers[algorithmIndex].initializedPlayer.NextMove(battleField, qtyCellsForWin, playingPairOfPlayers[algorithmIndex].IsHuman, playingPairOfPlayers[algorithmIndex].RemainingTimeForGame);
                }
                catch (Exception e)
                {
                    PublishGameExceptions("Exception in algorithm's team " + playingPairOfPlayers[algorithmIndex].TeamName + " - nextMove method.", e.ToString());
                    hasAlgorithmError = true;
                }

                playingPairOfPlayers[algorithmIndex].RemainingTimeForGame -= DateTime.Now.TimeOfDay - timeBeforePlayerMove;

                settingPointResult = SetPointOnBattleField(nextMove, playingPairOfPlayers[algorithmIndex], battleField, isVictory);

                //If player exceeds amount of limit time for whole game, he lost
                if (playingPairOfPlayers[algorithmIndex].RemainingTimeForGame < TimeSpan.FromSeconds(0))
                {
                    isVictory = true;
                    (playingPairOfPlayers[(SByte)((algorithmIndex - 1) * (-1))]).isWinner = true;
                    playingPairOfPlayers[algorithmIndex].battleResult = "Player has exceeded limit time for whole game";
                    playingPairOfPlayers[(SByte)((algorithmIndex - 1) * (-1))].battleResult = "Another player has exceeded limit time for whole game";
                }
                //If algorithm return point coordinates, which are outside the bound of the battlefield, he lost
                else if (settingPointResult == "Point is outside the bound")
                {
                    isVictory = true;
                    (playingPairOfPlayers[(SByte)((algorithmIndex - 1) * (-1))]).isWinner = true;
                    playingPairOfPlayers[algorithmIndex].battleResult = "Algorithm has returned coordinates outside the bound of battlefield";
                    playingPairOfPlayers[(SByte)((algorithmIndex - 1) * (-1))].battleResult = "Another algorithm has returned coordinates outside the bound of battlefield";
                }
                //If algorithm throws error, he lost
                else if (hasAlgorithmError)
                {
                    isVictory = true;
                    (playingPairOfPlayers[(SByte)((algorithmIndex - 1) * (-1))]).isWinner = true;
                    playingPairOfPlayers[algorithmIndex].battleResult = "Algorithm has thrown exception";
                    playingPairOfPlayers[(SByte)((algorithmIndex - 1) * (-1))].battleResult = "Another algorithm has thrown exception";
                }
                //If Player set point in non-empty cell, he lost
                else if (settingPointResult == "Non-empty cell")
                {
                    isVictory = true;
                    playingPairOfPlayers[(SByte)((algorithmIndex - 1) * (-1))].isWinner = true;
                    playingPairOfPlayers[algorithmIndex].battleResult = "Player set point in non-empty cell";
                    playingPairOfPlayers[(SByte)((algorithmIndex - 1) * (-1))].battleResult = "Another player set point in non-empty cell";
                }
                //Checking victory after each setting point
                else if (CheckVictory(playingPairOfPlayers[algorithmIndex], nextMove, maxCellCoordinate, qtyCellsForWin, maxLengthFieldOfBattlefield, battleField, isVictory, battleResult))
                {
                    isVictory = true;
                    playingPairOfPlayers[algorithmIndex].isWinner = true;
                    playingPairOfPlayers[algorithmIndex].battleResult = "Player set line of victory points";
                    playingPairOfPlayers[(SByte)((algorithmIndex - 1) * (-1))].battleResult = "Another player set line of victory points";
                }
                //Checking draw
                else if (currentQtyEmptyCellsOnBattleField <= 0 && !isVictory)
                {
                    isVictory = true;
                    playingPairOfPlayers[algorithmIndex].battleResult = "Empty cells are run out";
                    playingPairOfPlayers[(SByte)((algorithmIndex - 1) * (-1))].battleResult = "Empty cells are run out";
                }
            }
            while (!isVictory);

            //Refreshing UI after victory
            try
            {
                if (playingPairOfPlayers[algorithmIndex].IsHuman)
                {
                    playingPairOfPlayers[algorithmIndex].initializedPlayer.RefreshUI(battleField);
                }
                else
                {
                    playingPairOfPlayers[(SByte)((algorithmIndex - 1) * (-1))].initializedPlayer.RefreshUI(battleField);
                }
            }
            catch (Exception e)
            {
                PublishGameExceptions("Exception in algorithm's team " + playingPairOfPlayers[algorithmIndex].TeamName + " - RefreshUI method.", e.ToString());
            }

        }

        internal void RunGame(bool isVersusHuman, string teamName, string playersDllPath, List<BattleParams> listBattleParams)
        {
            CleanGameLogs();

            Player players = new Player();
            allPlayersList = players.ReturnAllPlayers(isVersusHuman, teamName, playersDllPath);

            int k = 1;
            var queryPlayers = allPlayersList.SelectMany(PlayerId => allPlayersList, (PlayerId1, PlayerId2) => new { PlayerId1, PlayerId2 }).Where(PlayerId => PlayerId.PlayerId1 != PlayerId.PlayerId2);
            foreach (var player in queryPlayers)
            {
                try
                {
                    ConstructorInfo constructor1 = player.PlayerId1.AlgorithmClass.GetConstructor(new Type[0]);
                    dynamic initializedPlayer1 = constructor1.Invoke(new object[0]);
                    player.PlayerId1.initializedPlayer = initializedPlayer1;
                }
                catch (Exception e)
                {
                    PublishGameExceptions("Team's \"" + player.PlayerId1.TeamName + "\" algorithm has thrown exceptions while creating class object via constructor.", e.ToString());
                }

                try
                {
                    ConstructorInfo constructor2 = player.PlayerId2.AlgorithmClass.GetConstructor(new Type[0]);
                    dynamic initializedPlayer2 = constructor2.Invoke(new object[0]);
                    player.PlayerId2.initializedPlayer = initializedPlayer2;
                }
                catch (Exception e)
                {
                    PublishGameExceptions("Team's \"" + player.PlayerId2.TeamName + "\" algorithm has thrown exceptions while creating class object via constructor.", e.ToString());
                }

                player.PlayerId1.playerCellState = PlayerCellState.playerCellState.X;
                player.PlayerId2.playerCellState = PlayerCellState.playerCellState.O;

                foreach (BattleParams battleParams in listBattleParams)
                {
                    player.PlayerId1.RemainingTimeForGame = battleParams.RemainingTimeForGame;
                    player.PlayerId1.QtyCellsForWin = battleParams.QtyCellsForWin;
                    player.PlayerId1.MaxLengthFieldOfBattlefield = battleParams.MaxLengthFieldOfBattlefield;
                    player.PlayerId1.PlayingPairId = k;
                    player.PlayerId2.RemainingTimeForGame = battleParams.RemainingTimeForGame;
                    player.PlayerId2.QtyCellsForWin = battleParams.QtyCellsForWin;
                    player.PlayerId2.MaxLengthFieldOfBattlefield = battleParams.MaxLengthFieldOfBattlefield;
                    player.PlayerId2.PlayingPairId = k;
                    playersTournamentList.Add((Player)player.PlayerId1.Clone());
                    playersTournamentList.Add((Player)player.PlayerId2.Clone());
                    k += 1;
                }
            }

            for (int n = 1; n < k; n++)
            {
                List<Player> playingPairOfPlayers = new List<Player>();
                playingPairOfPlayers.AddRange(playersTournamentList.Where(CurrentPlayingPairId => CurrentPlayingPairId.PlayingPairId == n));

                RunBattle(playingPairOfPlayers, playingPairOfPlayers[0].QtyCellsForWin, playingPairOfPlayers[0].MaxLengthFieldOfBattlefield);
            }

            PublishGameResults();
            FinishGame();
        }

        private void PublishGameResults()
        {
            string insertStatement = "insert into dbo.Results(PlayingPairId, PlayerId, ClassName, TeamName, IsHuman, IsWinner, RemainingTimeForGame, PlayerCellState, BattleResult) values(@PlayingPairId, @PlayerId, @ClassName, @TeamName, @IsHuman, @IsWinner, @RemainingTimeForGame, @PlayerCellState, @BattleResult)";
            string truncateStatement = "truncate table dbo.Results";
            using (SqlConnection sqlConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\TicTacToeDB.mdf;Integrated Security=True"))
            {
                using (SqlCommand sqlCommand = new SqlCommand(truncateStatement, sqlConn))
                {
                    sqlConn.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConn.Close();
                }
                using (SqlCommand sqlComm = new SqlCommand(insertStatement, sqlConn))
                {
                    sqlComm.Parameters.Add("@PlayingPairId", SqlDbType.Int);
                    sqlComm.Parameters.Add("@PlayerId", SqlDbType.Int);
                    sqlComm.Parameters.Add("@ClassName", SqlDbType.NVarChar);
                    sqlComm.Parameters.Add("@TeamName", SqlDbType.NVarChar);
                    sqlComm.Parameters.Add("@IsHuman", SqlDbType.Bit);
                    sqlComm.Parameters.Add("@IsWinner", SqlDbType.Bit);
                    sqlComm.Parameters.Add("@RemainingTimeForGame", SqlDbType.Time);
                    sqlComm.Parameters.Add("@PlayerCellState", SqlDbType.NVarChar);
                    sqlComm.Parameters.Add("@battleResult", SqlDbType.NVarChar);

                    sqlConn.Open();

                    foreach (Player player in playersTournamentList)
                    {
                        sqlComm.Parameters["@PlayingPairId"].Value = player.PlayingPairId;
                        sqlComm.Parameters["@PlayerId"].Value = player.PlayerId;
                        sqlComm.Parameters["@ClassName"].Value = player.ClassName;
                        sqlComm.Parameters["@TeamName"].Value = player.TeamName;
                        sqlComm.Parameters["@IsHuman"].Value = player.IsHuman;
                        sqlComm.Parameters["@IsWinner"].Value = player.isWinner;
                        sqlComm.Parameters["@RemainingTimeForGame"].Value = player.RemainingTimeForGame;
                        sqlComm.Parameters["@PlayerCellState"].Value = player.playerCellState;
                        if (player.battleResult != null)
                            sqlComm.Parameters["@battleResult"].Value = player.battleResult;
                        else
                            sqlComm.Parameters["@battleResult"].Value = DBNull.Value;

                        sqlComm.ExecuteNonQuery();
                    }

                    sqlConn.Close();
                }
            }
        }

        private void PublishGameExceptions(string CustomizedExceptionDescription, string SystemExceptionDescription)
        {
            string insertStatement = "insert into dbo.Logs(CustomizedExceptionDescription, SystemExceptionDescription) values(@CustomizedExceptionDescription, @SystemExceptionDescription)";
            using (SqlConnection sqlConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\TicTacToeDB.mdf;Integrated Security=True"))
            {
                using (SqlCommand sqlComm = new SqlCommand(insertStatement, sqlConn))
                {
                    sqlComm.Parameters.Add("@CustomizedExceptionDescription", SqlDbType.NVarChar);
                    sqlComm.Parameters.Add("@SystemExceptionDescription", SqlDbType.NVarChar);

                    sqlConn.Open();

                    sqlComm.Parameters["@CustomizedExceptionDescription"].Value = CustomizedExceptionDescription;
                    sqlComm.Parameters["@SystemExceptionDescription"].Value = SystemExceptionDescription;
                    sqlComm.ExecuteNonQuery();

                    sqlConn.Close();
                }
            }

            hasExceptionsOccured = true;
        }

        private void CleanGameLogs()
        {
            string truncateStatement = "truncate table dbo.Logs";
            using (SqlConnection sqlConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\TicTacToeDB.mdf;Integrated Security=True"))
            {
                using (SqlCommand sqlComm = new SqlCommand(truncateStatement, sqlConn))
                {
                    sqlConn.Open();
                    sqlComm.ExecuteNonQuery();
                    sqlConn.Close();
                }
            }
        }

        private void FinishGame()
        {
            if (hasExceptionsOccured)
            {
                MessageBox.Show("Game is over. Exceptions have occurred during process. Please, see logs in DB.");
            }
            else
            {
                MessageBox.Show("Game is over. Please, see results in DB.");
            }
        }

    }
}
