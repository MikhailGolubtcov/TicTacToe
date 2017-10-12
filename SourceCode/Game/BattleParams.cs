using System;

namespace EPAM.TicTacToe
{
    internal class BattleParams
    {
        internal BattleParams(byte qtyCellsForWin, byte maxLengthFieldOfBattlefield, TimeSpan remainingTimeForGame, int remainingQtyMovesForGame)
        {
            QtyCellsForWin = qtyCellsForWin;
            MaxLengthFieldOfBattlefield = maxLengthFieldOfBattlefield;
            RemainingTimeForGame = remainingTimeForGame;
            RemainingQtyMovesForGame = remainingQtyMovesForGame;
        }
        public byte QtyCellsForWin { get; set; }
        public byte MaxLengthFieldOfBattlefield { get; set; }
        public TimeSpan RemainingTimeForGame { get; set; }
        public int RemainingQtyMovesForGame { get; set; }
    }
}
