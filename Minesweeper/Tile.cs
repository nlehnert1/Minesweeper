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
        //Fields, setters, & getters
        private bool bomb;
        private int value;
        private bool _flagged;
        public bool Flagged
        {
            get { return _flagged; }
        }
        private bool _revealed;
        public bool Revealed
        {
            get { return _revealed;  }
            set { _revealed = value; }
        }
        private int xPos;
        private int yPos;


        //Constructor
        public Tile(int x, int y)
        {
            _flagged = false;
            bomb = false;
            value = 0;
            this.Size = new Size(35, 35);
            xPos = x;
            yPos = y;
            this.Text = "";
            this.Padding = new Padding(0, 0, 0, 0);
            this.BackColor = Color.LightGray;
            this.Font = new Font(this.Font.Name, 12.0f, this.Font.Style);

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
        }

        public void IncrementValue()
        {
            this.value++;
        }

        public int GetValue()
        {
            return this.value;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            //If game is already won or lost, don't do anything
            if(Game.GameWon || Game.GameLost)
            {
                return;
            }
            base.OnMouseDown(e);
            switch(e.Button)
            {
                case MouseButtons.Left:
                    Reveal();
                    break;
                case MouseButtons.Right:
                    SwapFlagged();
                    break;
            }
        }

        public void Reveal()
        {
            //Only reveal a tile if it isn't flagged
            if (!_flagged && !_revealed)
            {
                _revealed = true;
                //Auto-reveal surrounding tiles if there are no bombs surrounding this tile
                if (this.value == 0)
                {
                    Game.RevealSurroundingTiles(xPos, yPos);
                }
                UpdateDisplay();

                //If tile is a bomb, lose the game
                if(this.value == -1)
                {
                    UpdateDisplay();
                    Game.LoseGame();
                }
            }

            if(!_flagged && _revealed)
            {
                if(Game.GetSurroundingFlags(xPos, yPos) == this.value)
                {
                    Game.RevealSurroundingTiles(xPos, yPos);
                }
            }
        }

        private void SwapFlagged()
        {
            _flagged = !_flagged;
            UpdateDisplay();
            if(_flagged)
            {
                Game.NumFlagsPlaced++;
            }
            else
            {
                Game.NumFlagsPlaced--;
            }
        }

        public void UpdateDisplay()
        {
            if(_flagged)
            {
                //If flagged, show flag
                this.Text = "🚩";
                this.BackColor = Color.LightCoral;
            }
            else if(_revealed)
            {
                //Otherwise, if revealed, show value
                this.Text = this.value.ToString();
                this.BackColor = Color.Gray;
                if(this.value == 0)
                {
                    this.Text = "";
                }
                if(this.value == -1)
                {
                    this.Text = "X";
                    this.BackColor = Color.Red;
                }
            }
            else
            {
                //This should only be hit when toggling a flag back off. Sets the text back to blank and puts the background color back to normal
                this.Text = "";
                this.BackColor = Color.LightGray;
            }
        }
    }
}
