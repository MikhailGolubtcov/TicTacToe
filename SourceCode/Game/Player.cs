﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace EPAM.TicTacToe
{
    internal class Player : ICloneable
    {
        internal int PlayingPairId;
        internal int PlayerId;
        internal string ClassName;
        internal string TeamName;
        internal Type AlgorithmClass;
        internal bool IsHuman;
        internal bool isWinner;
        internal PlayerCellState.playerCellState playerCellState;
        internal IPlayer initializedPlayer;
        internal string battleResult;
        internal TimeSpan RemainingTimeForGame;
        internal byte QtyCellsForWin;
        internal byte MaxLengthFieldOfBattlefield;
        internal DBInteraction dbInteraction = new DBInteraction();

        public object Clone()
        {
            //this.initializedPlayer = new IPlayer();
            return this.MemberwiseClone();
        }

        internal List<Type> GetAssemblies(string PlayersDllPath)
        {
            Regex regex = new Regex(@"(?<!\\)\\(?!\\)");
            List<Type> assemblies = new List<Type>();
            regex.Replace(PlayersDllPath, @"\\");
            //PlayersDllPath = PlayersDllPath.Replace(@"\", @"\\");

            try
            {
                foreach (string fileName in Directory.GetFiles(PlayersDllPath, "*.dll"))
                {
                    Assembly assembly = Assembly.LoadFrom(fileName);

                    foreach (Type type in assembly.GetTypes().Where(m => m.IsClass && m.GetInterface("IPlayer") != null))
                    {
                        assemblies.Add(type);
                    }
                }
            }
            catch (Exception e)
            {
                dbInteraction.PublishGameException("Exceptions in algorithms loading", e.ToString());
            }

            return assemblies;
        }


        internal List<Player> ReturnAllPlayers(bool isVersusHuman, string teamName, string PlayersDllPath)
        {
            List<Player> playersList = new List<Player>();
            List<Type> assemblies = new List<Type>();
            assemblies = GetAssemblies(PlayersDllPath);
            int i = 1;

            foreach (Type type in assemblies)
            {
                if (isVersusHuman)
                {
                    if (((TeamName)type.GetCustomAttribute(typeof(TeamName))).Team == teamName)
                    {
                        playersList.Add(new Player() { PlayerId = 1, ClassName = type.Name, TeamName = ((TeamName)type.GetCustomAttribute(typeof(TeamName))).Team, AlgorithmClass = type, IsHuman = false });
                        playersList.Add(new Player() { PlayerId = 2, ClassName = type.Name, TeamName = ((TeamName)type.GetCustomAttribute(typeof(TeamName))).Team, AlgorithmClass = type, IsHuman = true });
                    }
                }
                else
                {
                    playersList.Add(new Player() { PlayerId = i, ClassName = type.Name, TeamName = ((TeamName)type.GetCustomAttribute(typeof(TeamName))).Team, AlgorithmClass = type, IsHuman = false });
                }

                i += 1;
            }

            return playersList;
        }


        internal List<string> GetTeamList(string PlayersDllPath)
        {
            List<string> teamList = new List<string>();
            List<Type> assemblies = new List<Type>();
            assemblies = GetAssemblies(PlayersDllPath);

            foreach (Type type in assemblies)
            {
                teamList.Add(((TeamName)type.GetCustomAttribute(typeof(TeamName))).Team);
            }

            return teamList;
        }

    }
}
