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
    public partial class GameFinished : Form
    {
        public GameFinished(Image img)
        {
            InitializeComponent();
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void GameFinished_Load(object sender, EventArgs e)
        {

        }

        private void btnNextLevel_Click(object sender, EventArgs e)
        {
            /*Close();
            Level2 level2 = new Level2();
            level2.Show();*/
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Close();
            Level1 level1 = new Level1();
            level1.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Close();
            Game_Start game_Start=new Game_Start();
            game_Start.Show();
        }
    }
}
