using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Minesweeper
{
    class Tile : System.Windows.Forms.Button
    {
        private bool bomb;
        private int value;
        private bool flagged;
        private int posX;
        private int posY;

        public Tile()
        {
            flagged = false;
            bomb = false;
            value = 0;
            this.Size = new Size(25, 25);
            this.Text = "";
        }

        public bool IsBomb()
        {
            return bomb;
        }

        public void PlantBomb()
        {
            //Sets the bomb field to true and sets a trash value for number of surrounding bombs
            this.bomb = true;
            this.value = -1;
            this.Text = value.ToString();
        }

        public void IncrementValue()
        {
            this.value++;
            this.Text = value.ToString();
        }

        public int GetValue()
        {
            return this.value;
        }

    }
}
