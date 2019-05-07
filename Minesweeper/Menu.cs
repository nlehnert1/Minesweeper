using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(200, 200, 200);
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            //Start easy game
            Populate(9, 9, 10);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //Start medium game
            Populate(16, 16, 40);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //Start hard game
            Populate(22, 22, 99);
        }

        private void Populate(int rows, int cols, int numBombs)
        {
            Game game = new Game(rows, cols, numBombs);
            game.Visible = true;
            //TODO: Should Game be a singleton, or should we allow more than 1 game to potentially exist at a time?

        }
    }
}
