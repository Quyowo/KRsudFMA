using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApp1
{
    public partial class Game : Form
    {
        int time = 0;
        const int n = 3;
        const int sizeButton = 50;
        int[,] mapcopi = new int[n * n, n * n];
        int[,] map = new int[,]
         {
            {5, 3, 4, 6, 7, 8, 9, 1, 2},
            {6, 7, 2, 1, 9, 5, 3, 4, 8},
            {1, 9, 8, 3, 4, 2, 5, 6, 7},
            {8, 5, 9, 7, 6, 1, 4, 2, 3},
            {4, 2, 6, 8, 5, 3, 7, 9, 1},
            {7, 1, 3, 9, 2, 4, 8, 5, 6},
            {9, 6, 1, 5, 3, 7, 2, 8, 4},
            {2, 8, 7, 4, 1, 9, 6, 3, 5},
            {3, 4, 5, 2, 8, 6, 1, 7, 9}
         };
        Button[,] buttons = new Button[n * n, n * n];

        public Game()
        {
            InitializeComponent();
            GenerateMap();
        }

        void GenerateMap()
        {
            { 
                Random rnd = new Random();
                int numShuffles = rnd.Next(1, 6);

                for (int i = 0; i < numShuffles; i++)
                {
                    for (int group = 0; group < 3; group++)
                    {
                        Shuffler.ShuffleRows(group * 3, map, rnd);
                        Shuffler.ShuffleColumns(group * 3, map, rnd);
                    }
                }
            }
            mapcopi = map;
            CreateMap();
            HideCells();
            timer1.Enabled = true;
        }


        void HideCells()
        {
            int N = 40;
            Random r = new Random();
            while (N > 0)
            {
                for (int i = 0; i < n * n; i++)
                {
                    for (int j = 0; j < n * n; j++)
                    {
                        if (!string.IsNullOrEmpty(buttons[i, j].Text))
                        {
                            int a = r.Next(0, 3);
                            buttons[i, j].Text = a == 0 ? "" : buttons[i, j].Text;
                            buttons[i, j].Enabled = a == 0 ? true : false;
                            if (a == 0)
                            {
                                map[i, j] = 0;
                                N--;
                            }
                            if (N <= 0)
                                break;

                        }
                    }

                    if (N <= 0)
                        break;
                }
            }
        }
        public static class Shuffler
        {
            public static void ShuffleRows(int startRow, int[,] map, Random rnd)
            {
                for (int i = 0; i < 3; i++)
                {
                    int randomRow = rnd.Next(3) + startRow;
                    for (int j = 0; j < 9; j++)
                    {
                        int temp = map[startRow + i, j];
                        map[startRow + i, j] = map[randomRow, j];
                        map[randomRow, j] = temp;
                    }
                }
            }

            public static void ShuffleColumns(int startCol, int[,] map, Random rnd)
            {
                for (int i = 0; i < 3; i++)
                {
                    int randomCol = rnd.Next(3) + startCol;
                    for (int j = 0; j < 9; j++)
                    {
                        int temp = map[j, startCol + i];
                        map[j, startCol + i] = map[j, randomCol];
                        map[j, randomCol] = temp;
                    }
                }
            }
        }

        void CreateMap()
        {
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    Button button = new Button();
                    buttons[i, j] = button;
                    button.Size = new Size(sizeButton, sizeButton);
                    button.Text = map[i, j].ToString();
                    button.Click += OnCellPressed;
                    button.Location = new Point(j * sizeButton, i * sizeButton);
                    button.Enabled = false;
                    button.Tag = new Point(i, j);

                    this.Controls.Add(button);
                }
            }
        }

        void OnCellPressed(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            Point buttonIndex = (Point)pressedButton.Tag;
            int i = buttonIndex.X;
            int j = buttonIndex.Y;
                map[i, j]++;
                if (map[i, j] == 10)
                    map[i, j] = 1;
                pressedButton.Text = map[i, j].ToString();

        }

        void SaveTimeToFile()
        {
            string filePath = "sudoku_records.txt";
            string currentTime = timer.Text;

            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(currentTime);
                }

                MessageBox.Show("Время сохранено успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при сохранении времени: " + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            int hours = time / 3600;
            int minutes = (time % 3600) / 60;
            int seconds = time % 60;
            timer.Text = $"{hours:00}:{minutes:00}:{seconds:00}";
        }

        private void Время_Click(object sender, EventArgs e)
        {

        }

        private void Check_Click(object sender, EventArgs e)
        {

            if (CheckSudokuSolution())
            {
                if (MessageBox.Show("Верно! Записать время?", "Результат", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveTimeToFile();
                    Предыгровое_меню menuWindow = new Предыгровое_меню();
                    menuWindow.Show();
                    this.Close();

                }

                for (int i = 0; i < n * n; i++)
                {
                    for (int j = 0; j < n * n; j++)
                    {
                        this.Controls.Remove(buttons[i, j]);
                    }
                }
                timer1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Неверно! Попробуйте еще раз.");
            }
        }
        bool CheckSudokuSolution()
        {
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    if (mapcopi[i, j].ToString() != buttons[i, j].Text)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void Record_Click(object sender, EventArgs e)
        {
            string filePath = "sudoku_records.txt";
            string smallestTime = "99:59:59";

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.Compare(line, smallestTime) < 0) 
                        {
                            smallestTime = line;
                        }
                    }
                }

                record1.Text = smallestTime;
            }
        }

        private void gomenu_Click(object sender, EventArgs e)
        {
            Предыгровое_меню menuWindow = new Предыгровое_меню();
            menuWindow.Show();
            this.Close();
        }
    }
}
