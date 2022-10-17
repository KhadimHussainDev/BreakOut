using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework.Main;
using Framework.Movement;
using Framework.Collision;
using Framework.Fire;
using BreakIT;
namespace NewGame
{
    public partial class Level1 : Form
    {
        Game g;
        Point ballPosition;
        Point stripPosition;
        Point boundary;
        int scores = 0;
        int lives = 3;
        int fires = 3;
        int time = 80;
        int tries = 0;
        Random rand = new Random();
        int randTime1 = 5;
        int randTime2 = 10;
        public Level1()
        {
            InitializeComponent();
            g = new Game();
            boundary = new Point(Width, Height);
            initilizeGameData();
        }
        private void initilizeGameData()
        {
            updateScores();
            updateLives();
            updateFires();
            updateTries();
            pbTime.Maximum = time;
            updateTime();
        }
        private void initilizeEvents()
        {
            g.OnAddingGameObject += OnAddingGameObject;
            g.OnRemoveBullet += onRemoveGameObject;
            g.OnBallAndStripCollision += OnBallAndStripCollision;
            g.OnPlayerDie += onRemoveGameObject;
            g.OnScoreIncrease += OnScoreIncrease;
            g.OnEnemyDie += onRemoveGameObject;
            g.OnFirePowerUp += fireIncreses;
            g.OnlifePowerUp += lifeIncrease;
            g.OnRemoveObject += onRemoveGameObject;
        }

        private void lifeIncrease(object sender, EventArgs e)
        {
            this.Controls.Remove(sender as PictureBox);
            lives++;
            updateLives();
        }
        private void fireIncreses(object sender, EventArgs e)
        {
            this.Controls.Remove(sender as PictureBox);
            fires++;
            updateFires();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            initilizeEvents();
            //
            //Adding Ball And Strip
            //
            int height = 20;
            int width = 150;
            Point boundaryLeftRight = new Point(190, this.Width - 200 - width);
            Point boundaryLeftRight2 = new Point(200, this.Width - 200 - 25);
            Point boundaryUpDown = new Point(this.Height - 200, this.Height - 75);
            Point boundaryUpDown2 = new Point(20, this.Height - 75);
            g.addOject(Properties.Resources.background, ObjectType.strip, this.Height - 100, this.Width / 2 - width / 2, height, width, new Keyboard(20, 10, boundaryLeftRight, boundaryUpDown), new PlayerFire(Properties.Resources.laserBlue03, new Up(15), ObjectType.playerBullets));
            g.addOject(Properties.Resources.ball, ObjectType.ball, this.Height - 110 - height, this.Width / 2 - 20, 25, 25, new movementOfBall(10, true, true, boundaryLeftRight2, boundaryUpDown2), new NoFire());
            ballPosition = new Point(this.Height - 110 - height, this.Width / 2 - 20);
            stripPosition = new Point(this.Height - 100, this.Width / 2 - width / 2);
            //
            //Adding Walls
            //
            g.addOject(Properties.Resources.background, ObjectType.walls, 0, 150, this.Height, 40, new NoMovement(), new NoFire());
            g.addOject(Properties.Resources.background, ObjectType.walls, 0, this.Width - 200, this.Height, 40, new NoMovement(), new NoFire());
            g.addOject(Properties.Resources.background, ObjectType.walls, 0, 150, 15, this.Width - 340, new NoMovement(), new NoFire());
            //
            //Adding Collisions
            //
            g.addCollision(new CollisionClass(ObjectType.strip, ObjectType.ball, new stripAndBall()));
            g.addCollision(new CollisionClass(ObjectType.bricks, ObjectType.ball, new ballAndBrickCollision()));
            g.addCollision(new CollisionClass(ObjectType.bricks, ObjectType.playerBullets, new PlayerBulletCollision()));
            g.addCollision(new CollisionClass(ObjectType.lifePowerUp, ObjectType.strip, new PowerUpCollision()));
            g.addCollision(new CollisionClass(ObjectType.firePowerUp, ObjectType.strip, new PowerUpCollision()));
            //
            //adding Bricks
            //
            addBricks();
            //
            //Walls On Front
            //
            brigWallsToFront();
        }
        private void brigWallsToFront()
        {
            g.bringWallsToFront();
        }
        private void updateTime()
        {
            lblTimeLeft.Text = "Time Left : " + time;
            pbTime.Value = time;
        }
        private void updateTries()
        {
            lblTries.Text = "Tries : " + tries;
        }
        private void updateFires()
        {
            lblFires.Text = "Fires : " + fires;
        }
        private void updateLives()
        {
            lblLife.Text = "Lives : " + lives;
        }
        private void updateScores()
        {
            lblScores.Text = "Scores : " + scores;
        }
        private void addBricks()
        {
            //
            //Adding Bricks
            //
            int top = 18;
            int left = 225;
            int width = 43;
            int height = 16;
            bool even = true;
            int col = 8;
            int count = 1;
            Image img1 = Properties.Resources.ferozi;
            Image img2 = Properties.Resources.yellow;
            Image img3 = Properties.Resources.pink;
            Image img4 = Properties.Resources.light_red;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (count == 1)
                    {
                        count++;
                        g.addOject(img1, ObjectType.bricks, top, left, height, width, new NoMovement(), new NoFire());
                    }
                    else if (count == 2)
                    {
                        g.addOject(img2, ObjectType.bricks, top, left, height, width, new NoMovement(), new NoFire());
                        count++;
                    }
                    else if (count == 3)
                    {
                        g.addOject(img3, ObjectType.bricks, top, left, height, width, new NoMovement(), new NoFire());
                        count++;
                    }
                    else if (count == 4)
                    {
                        g.addOject(img4, ObjectType.bricks, top, left, height, width, new NoMovement(), new NoFire());
                        count = 1;
                    }
                    left += 63;
                }
                if (even)
                {
                    col = 9;
                    left = 198;
                    even = false;
                }
                else
                {
                    col = 8;
                    left = 225;
                    even = true;
                }
                top += 25;
            }
        }
        private void gameWon()
        {
            if (g.gameWon())
            {
                this.Close();
                Image img = Properties.Resources.you_win;
                GameFinished gameFinished = new GameFinished(img);
                gameFinished.Show();
            }
        }
        private void OnScoreIncrease(object sender, EventArgs e)
        {
            scores += 10;
            updateScores();
        }
        private void OnBallAndStripCollision(object sender, EventArgs e)
        {
            tries++;
            updateTries();
        }
        private void onRemoveGameObject(object sender, EventArgs e)
        {
            this.Controls.Remove(sender as PictureBox);
        }
        private void OnAddingGameObject(object sender, EventArgs e)
        {
            this.Controls.Add(sender as PictureBox);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            g.detectCollision();
            g.update();
            g.removeObject(boundary);
            checkBallMovement();
            gameWon();
        }
        private void checkBallMovement()
        {
            PictureBox ball = g.getPositionOfBall();
            if (ball.Bottom >= Height - 55)
            {
                enableTimers(false);
                if (lives > 1)
                {
                    MessageBox.Show("OOPs ! Try Again.");
                    lives--;
                    lblLife.Text = "Lives : " + lives;
                    resetPositions(ball);
                    enableTimers(true);
                }
                else
                {
                    gameOver();
                }
            }
        }
        private void enableTimers(bool v)
        {
            timer1.Enabled = v;
            timeLeft.Enabled = v;
        }

        private void resetPositions(PictureBox ball)
        {
            PictureBox strip = g.getPositionOfStrip();
            ball.Top = ballPosition.X;
            ball.Left = ballPosition.Y;
            strip.Top = stripPosition.X;
            strip.Left = stripPosition.Y;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            g.keyPressed(e.KeyCode);
            if (e.KeyCode == Keys.Space)
            {
                if (fires > 0)
                {
                    fires--;
                    updateFires();
                    g.playerFire();
                }
            }
        }
        private void timeLeft_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
                updateTime();
            }
            else
            {
                enableTimers(false);
                gameOver();
            }
            if (randTime1 == 0)
            {
                randomPowerUpGenerate(Properties.Resources.bulletPowerup, ObjectType.firePowerUp);
                randTime1 = rand.Next(3, 10);
            }
            else
            {
                randTime1--;
            }
            if (randTime2 == 0)
            {
                randomPowerUpGenerate(Properties.Resources.lifePowerUp, ObjectType.lifePowerUp);
                randTime2 = rand.Next(5, 15);
            }
            else
            {
                randTime2--;
            }
        }
        private void randomPowerUpGenerate(Image img, ObjectType otype)
        {
            int top = rand.Next(0, 150);
            int left = rand.Next(200, Width - 250);
            g.addOject(img, otype, top, left, new Down(10, boundary), new NoFire());
        }

        private void gameOver()
        {
            GameFinished gameFinished = new GameFinished(Properties.Resources.game_over);
            Close();
            gameFinished.Show();
        }
        /*   /// <summary>
           /// FrameWork Implementation
           /// </summary>

           Game g;
           Point boundary;
           Random rand = new Random();
           int time = 50;
           public Form1()
           {
               InitializeComponent();
           }

           private void Form1_Load(object sender, EventArgs e)
           {
               g = new Game();
               g.OnAddingGameObject += gameObjectAdded;
               g.OnPlayerDie += removePlayer;
               g.OnRemoveBullet += removeBullet;
               g.OnEnemyDie += enemyDie;
               //
               //Boundary
               //
               boundary = new Point(this.Width, this.Height);
               //
               //add Game Objects
               //
               Point boundaryLeftRight = new Point(190, this.Width - 200 );
               Point boundaryUpDown = new Point(0, this.Height - 75);

               Image img = Properties.Resources.playerShip1_red;
               g.addOject(img, ObjectType.player, this.Height - img.Height - 50, Width / 2, new Keyboard(20, 10, boundaryLeftRight, boundaryUpDown), new PlayerFire(Properties.Resources.laserBlue03, new Up(15), ObjectType.playerBullets));
               g.addOject(Properties.Resources.enemyBlue1, ObjectType.enemy, 0, 0, new Horizontal(15, boundary, "right"), new EnemyFire(Properties.Resources.laserGreen03, new Down(15, boundary), ObjectType.enemyBullets));
               g.addOject(Properties.Resources.enemyRed2, ObjectType.enemy, 0, 0, new Horizontal(5, boundary, "left"), new EnemyFire(Properties.Resources.laserRed03, new Down(15, boundary), ObjectType.enemyBullets));
               //
               //add collision
               //
               CollisionClass c = new CollisionClass(ObjectType.player, ObjectType.enemy, new PlayerCollision());
               g.addCollision(c);
               c = new CollisionClass(ObjectType.enemy, ObjectType.playerBullets, new PlayerBulletCollision());
               g.addCollision(c);
               c = new CollisionClass(ObjectType.player, ObjectType.enemyBullets, new PlayerCollision());
               g.addCollision(c);
               c = new CollisionClass(ObjectType.enemyBullets, ObjectType.playerBullets, new PlayerBulletCollision());
               g.addCollision(c);

           }

           private void enemyDie(object sender, EventArgs e)
           {
               this.Controls.Remove(sender as PictureBox);
           }

           private void removeBullet(object sender, EventArgs e)
           {
               this.Controls.Remove(sender as PictureBox);
           }



           private void removePlayer(object sender, EventArgs e)
           {
               PictureBox pb = sender as PictureBox;
               this.Controls.Remove(pb);
           }
           private void gameObjectAdded(object sender, EventArgs e)
           {
               this.Controls.Add(sender as PictureBox);
           }

           private void timer1_Tick(object sender, EventArgs e)
           {
               g.update();
               g.removeBullets(boundary);
               g.deleteCollision();
               if (time <= 0)
               {
                   g.EnemyFire();
                   time = rand.Next(10, 20);
               }
               else
               {
                   time--;
               }
           }

           private void Form1_KeyDown(object sender, KeyEventArgs e)
           {
               g.keyPressed(e.KeyCode);
               if (e.KeyCode == Keys.Space)
               {
                   g.playerFire();
               }
           }

   */

    }
}