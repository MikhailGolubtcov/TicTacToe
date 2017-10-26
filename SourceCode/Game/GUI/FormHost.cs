using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace EPAM.TicTacToe
{
    public partial class FormHost : Form, IGUI
    {
        /////////////////////////////////// Host//////////////////////////////////////

        public string pathtoAlgorithm; //находится путь к алгоритму
        public string selectPlayer; //кто с кем игареет (Alg vs alg или alg vs Hum), напр. "Algorithm vs human"
        public string nameTeam; //находится имя команды
        public List<BattleParams> listParameters = new List<BattleParams>(); //для GUI: хранятся параметры (для таблицы)
                                                               //для Host: содержатся значения из таблицы
                                                               //один элемент листа содержит одну строку таблицы
                                                               //в каждом элементе листа содержится: Длинна поля (напр. если 50, то поле 50х50), количество выигрышных клеток (напр. 5), время сражения)


        /// //////////////////////////////////////////////////////////////////////////

        bool buttonPlayClicked;
        int figure = 1; //хранится фигура, которой играет ползователь 1 - X, 2 - 0
        int countFields;
        int size, x, y;
        bool checkSelectedSquare;
        int fieldValue; //хранит размер игорвого поля, например 4x4
        //int[,] playField; //двумерный массив (матрица), в котором хранится игровое поле
        List<Square> listSquares = new List<Square>(); //хранится поле в виде квадратиков
        List<int[]> listCoordinates = new List<int[]>(); //хранятся координаты пустых ячеек


        public FormHost()
        {
            InitializeComponent();
            fieldValue = (int)numericUpDownNumberFields.Value;
            CreateSquares();
            //CreatePlayField();
        }

        private void buttonX_MouseClick(object sender, MouseEventArgs e)
        {
            //buttonX.BackColor = Color.Gray;
            //button0.BackColor = Color.LightGray;
            //figure = 1; // X (крестик)
        }
        private void button0_Click(object sender, EventArgs e)
        {
            //button0.BackColor = Color.Gray;
            //buttonX.BackColor = Color.LightGray;
            //figure = 2; // 0 (нолик)
        }

        //↓↓↓ Внесение данных в таблицу при нажатии кнопки "Занести в таблицу" ↓↓↓
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            listParameters.Add(new BattleParams((byte)numericUpDownWinSquares.Value, (byte)numericUpDownNumberFields.Value, dateTimePicker.Value.TimeOfDay));
            Insert();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            buttonPlayClicked = !buttonPlayClicked;
            if (buttonPlayClicked == true)
            {
                buttonPlay.BackColor = Color.Red;
                buttonPlay.Text = "Стоп";
            }
            else
            {
                buttonPlay.BackColor = Color.LightGreen;
                buttonPlay.Text = "Играть";
            }

            fieldValue = listParameters[0].MaxLengthFieldOfBattlefield;
            CreateSquares();

            Game game = new Game();
            game.RunGame(textBoxPath.ToString(), listParameters, this);
        }

        //↓↓↓ Рисует квадратики ↓↓↓
        private void playGround_Paint(object sender, PaintEventArgs e)
        {
            foreach(Square s in listSquares)
            {
                Pen myPen = new Pen(Color.Black, 3);
                e.Graphics.DrawRectangle(myPen, s.Location.X, s.Location.Y, size, size);
                e.Graphics.FillRectangle(Brushes.LightGray, s.Location.X, s.Location.Y, size, size);
                if (s.Value == 1)
                {
                    e.Graphics.FillRectangle(Brushes.Gray, s.Location.X, s.Location.Y, size, size);
                    if (fieldValue == 3)
                    {
                        e.Graphics.DrawImage(Properties.Resources.cross, s.Location.X, s.Location.Y, 80, 80);
                    }
                    else if (fieldValue == 4)
                    {
                        e.Graphics.DrawImage(Properties.Resources.cross, s.Location.X, s.Location.Y);
                    }
                    else if (fieldValue >= 5 && fieldValue <= 8)
                    {
                        e.Graphics.DrawImage(Properties.Resources.cross, s.Location.X, s.Location.Y, 60, 60);
                    }
                    else if (fieldValue == 9 || fieldValue == 10)
                    {
                        e.Graphics.DrawImage(Properties.Resources.cross, s.Location.X, s.Location.Y, 50, 50);
                    }
                    else if (fieldValue >= 11)
                    {
                        e.Graphics.DrawImage(Properties.Resources.cross, s.Location.X, s.Location.Y, 30, 30);
                    }
                }
                else if (s.Value == 2)
                {
                    e.Graphics.FillRectangle(Brushes.Gray, s.Location.X, s.Location.Y, size, size);
                    if (fieldValue == 3)
                    {
                        e.Graphics.DrawImage(Properties.Resources.circle, s.Location.X, s.Location.Y, 80, 80);
                    }
                    else if (fieldValue == 4)
                    {
                        e.Graphics.DrawImage(Properties.Resources.circle, s.Location.X, s.Location.Y);
                    }
                    else if (fieldValue >= 5 && fieldValue <= 8)
                    {
                        e.Graphics.DrawImage(Properties.Resources.circle, s.Location.X, s.Location.Y, 60, 60);
                    }
                    else if (fieldValue == 9 || fieldValue == 10)
                    {
                        e.Graphics.DrawImage(Properties.Resources.circle, s.Location.X, s.Location.Y, 50, 50);
                    }
                    else if (fieldValue >= 11)
                    {
                        e.Graphics.DrawImage(Properties.Resources.circle, s.Location.X, s.Location.Y, 30, 30);
                    }
                }
            }
        }

        //↓↓↓ При наведении мышки на квадратик, квадратик окрашивается в серый цвет ↓↓↓
        private void playGround_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            var g = playGround.CreateGraphics();
            foreach (Square s in listSquares)
            {
                if ((s.Location.X < point.X && point.X < s.Location.X + size) && (s.Location.Y < point.Y && point.Y < s.Location.Y + size) && s.Value == 0)
                {
                    g.FillRectangle(Brushes.Gray, s.Location.X, s.Location.Y, size, size);
                    x = s.Location.X;
                    y = s.Location.Y;
                    checkSelectedSquare = true;
                    break;
                }
                else if (checkSelectedSquare == true)
                {
                    g.FillRectangle(Brushes.LightGray, x, y, size, size);
                    checkSelectedSquare = false;
                    break;
                }
            }
        }


        //↓↓↓ Заносит данные в таблицу ↓↓↓
        void Insert()
        {
            listViewParameters.Items.Clear();
            foreach (BattleParams bp in listParameters)
            {
                ListViewItem lvi = new ListViewItem(new string[] { bp.QtyCellsForWin.ToString(), bp.MaxLengthFieldOfBattlefield.ToString(), bp.RemainingTimeForGame.ToString() });
                listViewParameters.Items.Add(lvi);
            }
        }


        //↓↓↓ Создаёт квадратики, которые в последствии будут отрисованы ↓↓↓
        void CreateSquares()
        {
            listSquares.Clear();
            countFields = (int)fieldValue;
            size = 60;
            int coordinateX = 0;
            int coordinateY = 0;
            int startPoint = 10;
            if (countFields > 8 && countFields < 11)
            {
                size = 50;
            }
            else if (countFields >= 11)
            {
                size = 30;
            }
            else
            {
                switch (countFields)
                {
                    case 3:
                        startPoint = 155;
                        size = 80;
                        break;
                    case 4:
                        startPoint = 135;
                        size = 70;
                        break;
                    case 5:
                        startPoint = 115;
                        break;
                    case 6:
                        startPoint = 80;
                        break;
                    case 7:
                        startPoint = 45;
                        break;
                    default:
                        break;
                }
            }
            for (int i = 0; i < countFields; i++)
            {
                for (int j = 0; j < countFields; j++)
                {
                    listSquares.Add(new Square(new Point(startPoint + coordinateX, startPoint + coordinateY), 0, i, j));
                    coordinateX = coordinateX + size + 5;
                }
                coordinateX = 0;
                coordinateY = coordinateY + size + 5;
            }
            playGround.Invalidate();
            playGround.Invalidate();
        }
        private void numericUpDownNumberFields_ValueChanged(object sender, EventArgs e)
        {
            fieldValue = (int)numericUpDownNumberFields.Value;
            labelField.Text = fieldValue.ToString() + " x " + fieldValue.ToString();
            CreateSquares();
            //CreatePlayField();
        }

        //↓↓↓ Удаляет последнюю строку из таблицы ↓↓↓
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            listParameters.Remove(listParameters.Last());
            Insert();
        }
        private void radioButtonHumvsAlg_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButtonHumvsAlg.Checked)
            //{
            //    labelSelFigure.Visible = true;
            //    buttonX.Visible = true;
            //    button0.Visible = true;
            //    buttonTeam.Visible = true;
            //    labelTeam.Visible = true;
            //    comboBoxTeam.Visible = true;
            //}
            //else
            //{
            //    labelSelFigure.Visible = false;
            //    buttonX.Visible = false;
            //    button0.Visible = false;
            //    buttonTeam.Visible = false;
            //    labelTeam.Visible = false;
            //    comboBoxTeam.Visible = false;
            //}
        }

        public void RunForm()
        {
            throw new NotImplementedException();
        }

        public void LoadTeamNamesList(List<string> teamNamesList)
        {
            throw new NotImplementedException();
        }

        bool ReturnIsVersusHuman()
        {
            bool temp = false;
            if (radioButtonAlgvsAlg.Checked)
            {
                temp = false;
            }
            else if (radioButtonHumvsAlg.Checked)
            {
                temp = true;
            }
            return temp;
        }

        public string ReturnTeamName()
        {
            throw new NotImplementedException();
        }

        public string ReturnPathToAlgorithms()
        {
            return textBoxPath.Text;
        }

        public List<BattleParams> ReturnBattleParams()
        {
            return listParameters;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        public void VisualizeNextMove(CellCoordinates cellCoordinates, PlayerCellState.playerCellState cellState)
        {
            foreach (Square s in listSquares)
            {
                if (s.CoordX == cellCoordinates.X && s.CoordY == cellCoordinates.Y)
                {
                    switch (cellState)
                    {
                        case PlayerCellState.playerCellState.X:
                            s.Value = 1;
                            break;
                        case PlayerCellState.playerCellState.O:
                            s.Value = 2;
                            break;
                        default:
                            break;
                    }
                }
            }

            playGround.Refresh();
        }


        public void ClearBattleField()
        {
            foreach (Square s in listSquares)
            {
                if (s.Value != 0)
                {
                    s.Value = 0;
                }
            }
        }
    }
}
