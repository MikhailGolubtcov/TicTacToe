using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPAM.TicTacToe
{
    public class Table
    {
        public int NumberFields { get; set; }
        public int WinSquares { get; set; }
        public string TimeBattle { get; set; }

        public Table (int numberFields, int winSquares, string timeBattle)
        {
            NumberFields = numberFields;
            WinSquares = winSquares;
            TimeBattle = timeBattle;
        }
    }
}
