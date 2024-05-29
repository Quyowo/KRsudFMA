using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Records : Form
    {
        public Records()
        {
            InitializeComponent();
            textBox1.TextChanged += textBox1_TextChanged;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadTextFromFile("sudoku_records.txt");
        }

        private void LoadTextFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    // Читаем строки из файла
                    string[] lines = File.ReadAllLines(filePath);

                    // Создаем список для хранения записей
                    List<string> recordsList = new List<string>();

                    // Парсим каждую строку и добавляем в список
                    foreach (string line in lines)
                    {
                        recordsList.Add(line);
                    }

                    // Сортируем записи по времени в возрастающем порядке
                    recordsList.Sort((a, b) =>
                    {
                        TimeSpan timeA = TimeSpan.Parse(a);
                        TimeSpan timeB = TimeSpan.Parse(b);
                        return timeA.CompareTo(timeB);
                    });

                    // Формируем текст для отображения в TextBox с добавлением номеров записей
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < recordsList.Count; i++)
                    {
                        sb.AppendLine($"{i + 1}) {recordsList[i]}");
                    }

                    // Устанавливаем отсортированный текст в TextBox
                    textBox1.Text = sb.ToString();
                }
                else
                {
                    MessageBox.Show("Файл не существует.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке файла: " + ex.Message);
            }
        }
    }
}