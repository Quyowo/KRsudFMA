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

        void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadTextFromFile("sudoku_records.txt");
        }

        void LoadTextFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    List<string> recordsList = new List<string>();

                    foreach (string line in lines)
                    {
                        recordsList.Add(line);
                    }

                    recordsList.Sort((a, b) =>
                    {
                        TimeSpan timeA = TimeSpan.Parse(a);
                        TimeSpan timeB = TimeSpan.Parse(b);
                        return timeA.CompareTo(timeB);
                    });

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < recordsList.Count; i++)
                    {
                        sb.AppendLine($"{i + 1}) {recordsList[i]}");
                    }
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