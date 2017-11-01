using EPAM.TicTacToe.GUI;
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
        public string pathtoAlgorithm; //находится путь к алгоритму
        public List<BattleParams> listParameters = new List<BattleParams>(); //для GUI: хранятся параметры (для таблицы)
                                                               //для Host: содержатся значения из таблицы
                                                               //один элемент листа содержит одну строку таблицы
                                                               //в каждом элементе листа содержится: Длинна поля (напр. если 50, то поле 50х50), количество выигрышных клеток (напр. 5), время сражения)
        int countFields;
        int size, x, y;
        bool checkSelectedSquare;
        int numberGame; //Считает количество игр (одна строка в таблице = 2 игры)
        int numberListParameters; //Считает количество элементов listParameters
        int fieldValue; //хранит размер игорвого поля, например 4x4
        List<Square> listSquares = new List<Square>(); //хранится поле в виде квадратиков
        List<int[]> listCoordinates = new List<int[]>(); //хранятся координаты пустых ячеек

        public FormHost()
        {
            InitializeComponent();
            fieldValue = (int)numericUpDownNumberFields.Value;
            CreateSquares();
        }

        //↓↓↓ Внесение данных в таблицу при нажатии кнопки "Занести в таблицу" ↓↓↓
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (dateTimePicker.Text == "0:00:00")
            {
                MessageBox.Show("Введите время");
                return;
            }
            try
            {
                listParameters.Add(new BattleParams((byte)numericUpDownWinSquares.Value, (byte)numericUpDownNumberFields.Value, dateTimePicker.Value.TimeOfDay));
                Insert();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonPlay_MouseHover(object sender, EventArgs e)
        {
            buttonPlay.BackColor = Color.Green;
        }

        private void buttonPlay_MouseLeave(object sender, EventArgs e)
        {
            buttonPlay.BackColor = Color.LightGreen;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (listParameters.Count == 0)
            {
                MessageBox.Show("Введите данные в таблицу");
                return;
            }
            try
            {
                fieldValue = listParameters[0].MaxLengthFieldOfBattlefield;
                CreateSquares();
                numberGame = 0; //при нажатии "Играть" обнуляем количество игр
                numberListParameters = 1; //Начинаем с первого элемента листа (первой строки таблицы)
                Game game = new Game();

                Task task = Task.Run(() => game.RunGame(textBoxPath.ToString(), listParameters, this));
                //game.RunGame(textBoxPath.ToString(), listParameters, this);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

        //↓↓↓ Открывает окно на месте его последнего закрытия ↓↓↓
        private void FormHost_Load(object sender, EventArgs e)
        {
            Properties.Settings ps = Properties.Settings.Default;
            this.Top = ps.Top;
            this.Left = ps.Left;
        }

        //↓↓↓ Сохраняет расположение окна перед закрытием (чтобы открылось на прежнем месте) ↓↓↓
        private void FormHost_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings ps = Properties.Settings.Default;
            ps.Top = this.Top;
            ps.Left = this.Left;
            ps.Save();
        }

        //↓↓↓ Заносит данные в таблицу ↓↓↓

        private void numericUpDownNumberFields_ValueChanged(object sender, EventArgs e)
        {
            fieldValue = (int)numericUpDownNumberFields.Value;
            labelField.Text = fieldValue.ToString() + " x " + fieldValue.ToString();
            CreateSquares();
        }

        //↓↓↓ Удаляет последнюю строку из таблицы ↓↓↓
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            listParameters.Remove(listParameters.Last());
            Insert();
        }

        void Insert()
        {
            listViewParameters.Items.Clear();
            foreach (BattleParams bp in listParameters)
            {
                ListViewItem lvi = new ListViewItem(new string[] { bp.MaxLengthFieldOfBattlefield.ToString(), bp.QtyCellsForWin.ToString(), bp.RemainingTimeForGame.ToString() });
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
        }        //↓↓↓ Реализация IGUI ↓↓↓ //

        public void RunForm()
        {
            throw new NotImplementedException();
        }

        public void LoadTeamNamesList(List<string> teamNamesList)
        {
            throw new NotImplementedException();
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

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout aboutProgram = new FormAbout();
            aboutProgram.Show();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = @"..\..\Docs\Инструкция.docx";
            System.Diagnostics.Process.Start(path);
        }
        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = @"..\..\Docs\Исправления.docx";
            System.Diagnostics.Process.Start(path);
        }
        //↓↓↓ Принимает координату и значение (Х или 0) и отрисовывает её на игровом поле ↓↓↓ //
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
            Application.DoEvents();
            playGround.AutoScrollOffset = new Point(50, 50);
            
        }
        
        //↓↓↓ Очищает поле перед ново игрой ↓↓↓ //
        public void ClearBattleField()
        {
            if(numberGame == 0 || numberGame == 1)
            {
                foreach (Square s in listSquares)
                {
                    if (s.Value != 0)
                    {
                        s.Value = 0;
                    }
                }
                numberGame++;
            }
            else if(numberGame == 2 && numberListParameters < listParameters.Count)
            {
                fieldValue = listParameters[numberListParameters].MaxLengthFieldOfBattlefield;
                CreateSquares();
                playGround.Invalidate();
                numberListParameters++;
                numberGame = 1;
            }
        }
    }
}
