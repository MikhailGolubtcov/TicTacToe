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
        public int WinSquares { get; set; }
        public int NumberFields { get; set; }
        public string TimeBattle { get; set; }

        public Table (int winSquares, int numberFields, string timeBattle)
        {
            WinSquares = winSquares;
            NumberFields = numberFields;
            TimeBattle = timeBattle;
        }
    }
}
