namespace NewGame
{
    partial class Level1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblLife = new System.Windows.Forms.Label();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.pbTime = new System.Windows.Forms.ProgressBar();
            this.lblTries = new System.Windows.Forms.Label();
            this.lblScores = new System.Windows.Forms.Label();
            this.lblLevel1 = new System.Windows.Forms.Label();
            this.lblFires = new System.Windows.Forms.Label();
            this.timeLeft = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblLife
            // 
            this.lblLife.AutoSize = true;
            this.lblLife.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLife.Location = new System.Drawing.Point(5, 236);
            this.lblLife.Name = "lblLife";
            this.lblLife.Size = new System.Drawing.Size(66, 20);
            this.lblLife.TabIndex = 40;
            this.lblLife.Text = "Lives : 3";
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLeft.Location = new System.Drawing.Point(783, 444);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(70, 16);
            this.lblTimeLeft.TabIndex = 39;
            this.lblTimeLeft.Text = "Time Left : ";
            // 
            // pbTime
            // 
            this.pbTime.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.pbTime.Location = new System.Drawing.Point(786, 410);
            this.pbTime.Name = "pbTime";
            this.pbTime.Size = new System.Drawing.Size(118, 21);
            this.pbTime.Step = 100;
            this.pbTime.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbTime.TabIndex = 38;
            // 
            // lblTries
            // 
            this.lblTries.AutoSize = true;
            this.lblTries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTries.Location = new System.Drawing.Point(3, 195);
            this.lblTries.Name = "lblTries";
            this.lblTries.Size = new System.Drawing.Size(64, 20);
            this.lblTries.TabIndex = 37;
            this.lblTries.Text = "Tries : 0";
            // 
            // lblScores
            // 
            this.lblScores.AutoSize = true;
            this.lblScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScores.Location = new System.Drawing.Point(3, 144);
            this.lblScores.Name = "lblScores";
            this.lblScores.Size = new System.Drawing.Size(80, 20);
            this.lblScores.TabIndex = 36;
            this.lblScores.Text = "Scores : 0";
            // 
            // lblLevel1
            // 
            this.lblLevel1.AutoSize = true;
            this.lblLevel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel1.Location = new System.Drawing.Point(4, 33);
            this.lblLevel1.Name = "lblLevel1";
            this.lblLevel1.Size = new System.Drawing.Size(82, 25);
            this.lblLevel1.TabIndex = 35;
            this.lblLevel1.Text = "Level 1";
            // 
            // lblFires
            // 
            this.lblFires.AutoSize = true;
            this.lblFires.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFires.Location = new System.Drawing.Point(6, 272);
            this.lblFires.Name = "lblFires";
            this.lblFires.Size = new System.Drawing.Size(65, 20);
            this.lblFires.TabIndex = 41;
            this.lblFires.Text = "Fires : 1";
            // 
            // timeLeft
            // 
            this.timeLeft.Enabled = true;
            this.timeLeft.Interval = 1000;
            this.timeLeft.Tick += new System.EventHandler(this.timeLeft_Tick);
            // 
            // Level1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(916, 541);
            this.Controls.Add(this.lblFires);
            this.Controls.Add(this.lblLife);
            this.Controls.Add(this.lblTimeLeft);
            this.Controls.Add(this.pbTime);
            this.Controls.Add(this.lblTries);
            this.Controls.Add(this.lblScores);
            this.Controls.Add(this.lblLevel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Level1";
            this.Text = "Level1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblLife;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.ProgressBar pbTime;
        private System.Windows.Forms.Label lblTries;
        private System.Windows.Forms.Label lblScores;
        private System.Windows.Forms.Label lblLevel1;
        private System.Windows.Forms.Label lblFires;
        private System.Windows.Forms.Timer timeLeft;
    }
}

