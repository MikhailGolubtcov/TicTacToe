using System;

namespace EPAM.TicTacToe
{
    public class BattleParams
    {
        public BattleParams(byte qtyCellsForWin, byte maxLengthFieldOfBattlefield, TimeSpan remainingTimeForGame)
        {
            QtyCellsForWin = qtyCellsForWin;
            MaxLengthFieldOfBattlefield = maxLengthFieldOfBattlefield;
            RemainingTimeForGame = remainingTimeForGame;
        }
        public byte QtyCellsForWin { get; set; }
        public byte MaxLengthFieldOfBattlefield { get; set; }
        public TimeSpan RemainingTimeForGame { get; set; }
    }
}