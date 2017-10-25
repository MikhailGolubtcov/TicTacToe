using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPAM.TicTacToe
{
    public class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormHost());

            GUI_Test gui = new GUI_Test();
            gui.RunForm();

            gui.ReturnBattleParams();


            //System.Console.ReadLine();
        }
    }
}
