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
            Game battle = new Game();
            battle.RunGame();



            //    UIParameters uIParameters = new UIParameters();
            //uIParameters.InitializeComponent();
            //uIParameters.Run()

            System.Console.ReadLine();
        }
    }
}
