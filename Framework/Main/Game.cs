using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework.Movement;
using System.Drawing;
using Framework.Collision;
using Framework.Fire;

namespace Framework.Main
{
    public class Game : IGame
    {
        List<GameObject> game;
        List<CollisionClass> collisions;
        EventHandler onAddingGameObject;
        EventHandler onPlayerDie;
        EventHandler onRemoveBullet;
        EventHandler onRemoveObject;
        EventHandler onEnemyDie;
        EventHandler onBallAndStripCollision;
        EventHandler onScoreIncrease;
        EventHandler onFirePowerUp;
        EventHandler onlifePowerUp;
        public Game()
        {
            game = new List<GameObject>();
            collisions = new List<CollisionClass>();
        }
        public EventHandler OnAddingGameObject { get => onAddingGameObject; set => onAddingGameObject = value; }
        public void addOject(Image img, ObjectType otype, int top, int left, int height, int width, IMovement iMovement, IFire fire)
        {
            GameObject g = new GameObject(img, otype, top, left, height, width, iMovement, fire);
            game.Add(g);
            OnAddingGameObject?.Invoke(g.Pb, EventArgs.Empty);
        }
        public EventHandler OnPlayerDie { get => onPlayerDie; set => onPlayerDie = value; }
        public EventHandler OnRemoveBullet { get => onRemoveBullet; set => onRemoveBullet = value; }
        public EventHandler OnEnemyDie { get => onEnemyDie; set => onEnemyDie = value; }
        public EventHandler OnBallAndStripCollision { get => onBallAndStripCollision; set => onBallAndStripCollision = value; }
        public EventHandler OnScoreIncrease { get => onScoreIncrease; set => onScoreIncrease = value; }
        public EventHandler OnFirePowerUp { get => onFirePowerUp; set => onFirePowerUp = value; }
        public EventHandler OnlifePowerUp { get => onlifePowerUp; set => onlifePowerUp = value; }
        public EventHandler OnRemoveObject { get => onRemoveObject; set => onRemoveObject = value; }

        public void addOject(Image img, ObjectType otype, int top, int left, IMovement iMovement, IFire fire)
        {
            GameObject g = new GameObject(img, otype, top, left, iMovement, fire);
            game.Add(g);
            OnAddingGameObject?.Invoke(g.Pb, EventArgs.Empty);
        }
        public void update()
        {
            foreach (GameObject g in game)
            {
                g.gameObjectMove();
            }
        }
        public void keyPressed(Keys key)
        {
            foreach (GameObject g in game)
            {
                if (g.IMovement.GetType() == typeof(Keyboard))
                {
                    Keyboard keyboard = (Keyboard)g.IMovement;
                    keyboard.keyPressed(key);
                }
            }
        }
        public void detectCollision()
        {
            for (int i = game.Count - 1; i >= 0; i--)
            {
                for (int j = game.Count - 1; j >= 0; j--)
                {
                    if (game[i].Pb.Bounds.IntersectsWith(game[j].Pb.Bounds))
                    {
                        foreach (CollisionClass c in collisions)
                        {
                            if (game[i].Otype == c.G1 && game[j].Otype == c.G2)
                            {
                                c.Action.action(this, game[i], game[j]);
                                if (c.G2 == ObjectType.playerBullets)
                                    game.RemoveAt(j);
                                if (c.G1 != ObjectType.strip)
                                    game.RemoveAt(i);
                                return;
                            }
                        }
                    }
                }
            }
        }
        public PictureBox getPositionOfStrip()
        {
            PictureBox pic = null;
            foreach (GameObject g in game)
            {
                if (g.Otype == ObjectType.strip)
                {
                    pic = g.Pb;
                }
            }
            return pic;
        }
        public PictureBox getPositionOfBall()
        {
            PictureBox pic = null;
            foreach (GameObject g in game)
            {
                if (g.Otype == ObjectType.ball)
                {
                    pic = g.Pb;
                }
            }
            return pic;
        }
        public void playerFire()
        {
            for (int i = game.Count - 1; i >= 0; i--)
            {
                if (game[i].Otype == ObjectType.player || game[i].Otype == ObjectType.strip)
                {
                    GameObject fires = game[i].CreateFire(game[i].Pb);
                    game.Add(fires);
                    OnAddingGameObject?.Invoke(fires.Pb, EventArgs.Empty);
                }
            }
        }
        public void bringWallsToFront()
        {
            foreach (GameObject go in game)
            {
                if (go.Otype == ObjectType.walls)
                {
                    go.Pb.BringToFront();
                }
            }
        }
        public void EnemyFire()
        {
            for (int i = game.Count - 1; i >= 0; i--)
            {
                if (game[i].Otype == ObjectType.enemy)
                {
                    GameObject fires = game[i].CreateFire(game[i].Pb);
                    game.Add(fires);
                    OnAddingGameObject?.Invoke(fires.Pb, EventArgs.Empty);
                }
            }
        }
        public void addCollision(CollisionClass c)
        {
            collisions.Add(c);
        }
        public void raisePlayerDieEvent(PictureBox pb)
        {
            OnPlayerDie?.Invoke(pb, EventArgs.Empty);
        }
        public void removeObject(Point boundary)
        {
            for (int i = game.Count - 1; i >= 0; i--)
            {
                if (game[i].Pb.Top < 0 || game[i].Pb.Top >= boundary.Y||game[i].Pb.Left<0||game[i].Pb.Right>boundary.X)
                {
                    OnRemoveObject?.Invoke(game[i].Pb, EventArgs.Empty);
                    game.RemoveAt(i);
                    continue;
                }
            }
        }
        public bool gameWon()
        {
            foreach (GameObject go in game)
            {
                if (go.Otype == ObjectType.bricks)
                {
                    return false;
                }
            }
            return true;
        }
        public void raiseEnemyDieEvent(PictureBox bullet, PictureBox enemy)
        {
            onScoreIncrease?.Invoke(null, EventArgs.Empty);
            onRemoveBullet?.Invoke(bullet, EventArgs.Empty);
            OnEnemyDie?.Invoke(enemy, EventArgs.Empty);
        }
        public void raiseEventToReverseDirectionOfBall(GameObject g)
        {
            movementOfBall movementOfBall = g.IMovement as movementOfBall;
            //movementOfBall.IsGoingUp = !movementOfBall.IsGoingUp;
            movementOfBall.IsGoingUp ^= true;
        }
        public void raiseEventToIncreaseScore()
        {
            onScoreIncrease?.Invoke(null, EventArgs.Empty);
        }
        public void raiseEventToUpdateTries()
        {
            onBallAndStripCollision?.Invoke(null, EventArgs.Empty);
        }
        public void raisePowerUpDieEvent(GameObject powerUp)
        {
            if (powerUp.Otype == ObjectType.lifePowerUp)
            {
                OnlifePowerUp?.Invoke(powerUp.Pb, EventArgs.Empty);
            }
            if (powerUp.Otype == ObjectType.firePowerUp)
            {
                OnFirePowerUp?.Invoke(powerUp.Pb, EventArgs.Empty);
            }
        }
    }
}
