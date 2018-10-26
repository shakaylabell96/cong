using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cong
{

    public partial class Form1 : Form
    {
        Graphics paper;
        Paddle paddle = new Paddle();
        Ball ball = new Ball();
        List<Brick> bricks = new List<Brick>();

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 20; i++) 
            {
                Brick brick = new Brick(i);
                bricks.Add(brick);
            }

            this.Bounds = Screen.PrimaryScreen.Bounds; //Makes the screen full screen

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            paddle.drawPaddle(paper);
            ball.drawBall(paper);
            bricks.ForEach((Brick obj) => obj.drawBrick(paper));
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            paddle.movePadle(e.X);
            this.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ball.moveBall();                  //Ballmoves 
            ball.collide();                   //Collision
            ball.hitPaddle(paddle.PaddleRec); //In order to hit the paddle
            bricks.ForEach((Brick brick) =>
            {
                if (!brick.isDead())
                {
                    if (ball.hitBrick(brick.BrickRec))
                    {
                        brick.kill();
                    }
                }
            });

            this.Invalidate();
            this.Update();
            this.Refresh();
        }
    }
}
