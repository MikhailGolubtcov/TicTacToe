using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.TicTacToe
{
    public class Program
    {
        static void Main(string[] args)
        {
            GUI_Test gui = new GUI_Test();
            gui.RunForm();

            gui.ReturnBattleParams();



            //    UIParameters uIParameters = new UIParameters();
            //uIParameters.InitializeComponent();
            //uIParameters.Run()

            System.Console.ReadLine();
        }
    }
}
