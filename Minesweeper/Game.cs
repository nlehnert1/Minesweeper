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
    public partial class Game : Form
    {
        private int numRows;
        private int numCols;
        private int numBombs;
        private Random random;
        private Tile[][] tiles;
        private bool gameWon;
        private bool gameLost;

        public Game(int rows, int cols, int numBombs)
        {
            InitializeComponent();
            this.numRows = rows;
            this.numCols = cols;
            this.numBombs = numBombs;
            tiles = new Tile[rows][];
            for(int i = 0; i < rows; i++)
            {
                tiles[i] = new Tile[cols];
            }
            random = new Random();


            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    //TODO: Create and place tiles, populate with bombs, then update tile values
                    Tile t = new Tile();
                    t.Location = new Point(i * 25, j * 25);
                    this.Controls.Add(t);
                    tiles[i][j] = t;
                }
            }
            placeBombs();

        }

        private void Game_Load(object sender, EventArgs e)
        {

        }

        void placeBombs()
        {
            //Start with 0 bombs placed
            int bombsPlaced = 0;
            while (bombsPlaced < numBombs)
            {
                //Keep placing bombs at random locations until all have been placed
                int x = random.Next(0, numRows);
                int y = random.Next(0, numCols);
                //If random tile is not already a bomb, make it a bomb and increment bombsPlaced
                if(!tiles[x][y].IsBomb())
                {
                    tiles[x][y].PlantBomb();
                    bombsPlaced++;
                    updateAdjacentTiles(x, y);
                }

            }
        }

        void updateAdjacentTiles(int x, int y)
        {
            for(int i = x-1; i <= x+1; i++)
            {
                for(int j = y-1; j <= y+1; j++)
                {
                    if((i >= 0 && j >= 0 && i < this.numRows && j < this.numCols) && tiles[i][j].GetValue() != -1)
                    {
                        tiles[i][j].IncrementValue();
                    }
                }
            }
        }
    }
}
