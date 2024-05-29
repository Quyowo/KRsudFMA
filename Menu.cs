using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Предыгровое_меню : Form
    {
        public Предыгровое_меню()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void LoadHelp(object sender, EventArgs e)
        {
            Help helpWindow = new Help();

            helpWindow.Show();
        }

        private void LoadGame(object sender, EventArgs e)
        {
            Game gameWindow = new Game();   
            gameWindow.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Records_Click(object sender, EventArgs e)
        {
            Records recordsWindow = new Records();
            recordsWindow.Show();
        }
    }
}
