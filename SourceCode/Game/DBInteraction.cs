using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace EPAM.TicTacToe
{
    internal class DBInteraction
    {
        private string sqlConnStr = "Data Source=(localdb)\\mssqllocaldb;AttachDbFilename=|DataDirectory|\\TicTacToeDB.mdf;Integrated Security=True";

        internal void PublishGameResults(List<Player> playersTournamentList)
        {
            string insertStatement = "insert into dbo.Results(PlayingPairId, PlayerId, ClassName, TeamName, IsHuman, IsWinner, RemainingTimeForGame, PlayerCellState, BattleResult) values(@PlayingPairId, @PlayerId, @ClassName, @TeamName, @IsHuman, @IsWinner, @RemainingTimeForGame, @PlayerCellState, @BattleResult)";
            string truncateStatement = "truncate table dbo.Results";
            using (SqlConnection sqlConn = new SqlConnection(sqlConnStr))
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

        internal void PublishGameException(string CustomizedExceptionDescription, string SystemExceptionDescription)
        {
            string insertStatement = "insert into dbo.Logs(CustomizedExceptionDescription, SystemExceptionDescription) values(@CustomizedExceptionDescription, @SystemExceptionDescription)";
            using (SqlConnection sqlConn = new SqlConnection(sqlConnStr))
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
        }

        internal void CleanGameLogs()
        {
            string truncateStatement = "truncate table dbo.Logs";
            using (SqlConnection sqlConn = new SqlConnection(sqlConnStr))
            {
                using (SqlCommand sqlComm = new SqlCommand(truncateStatement, sqlConn))
                {
                    sqlConn.Open();
                    sqlComm.ExecuteNonQuery();
                    sqlConn.Close();
                }
            }
        }

        internal bool HaveExceptionsOccurred()
        {
            string selectStatement = "select count(*) from dbo.Logs";
            int rowCount = 0;
            bool haveExceptionsOccurred = false;
            using (SqlConnection sqlConn = new SqlConnection(sqlConnStr))
            {
                using (SqlCommand sqlComm = new SqlCommand(selectStatement, sqlConn))
                {
                    sqlConn.Open();

                    rowCount = (Int32)sqlComm.ExecuteScalar();

                    sqlConn.Close();
                }
            }

            if (rowCount > 0)
            {
                haveExceptionsOccurred = true;
            }

            return haveExceptionsOccurred;
        }
    }
}
