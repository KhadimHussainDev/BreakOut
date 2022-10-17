using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewGame;
namespace BreakIT
{
    public partial class Game_Start : Form
    {
        public Game_Start()
        {
            InitializeComponent();
        }

        private void btnPlayGame_Click(object sender, EventArgs e)
        {
            Level1 level1 = new Level1();
            level1.Show();
                Hide();
        }

        private void btnLevel1_Click(object sender, EventArgs e)
        {
            Level1 level1 = new Level1();
            level1.Show();
            Hide();
        }

        private void btnLevel2_Click(object sender, EventArgs e)
        {
            /*Level2 level2 = new Level2();
            level2.Show();
            Hide();*/
        }

        private void Game_Start_Load(object sender, EventArgs e)
        {

        }
    }
}
