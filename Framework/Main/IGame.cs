using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Framework.Main
{
    public interface IGame
    {
        void raisePlayerDieEvent(PictureBox pb);
        void raiseEnemyDieEvent(PictureBox bullet, PictureBox enemy);
        void raiseEventToReverseDirectionOfBall(GameObject g);
        void raiseEventToIncreaseScore();
        void raiseEventToUpdateTries();
        void raisePowerUpDieEvent(GameObject powerUp);
    }
}
