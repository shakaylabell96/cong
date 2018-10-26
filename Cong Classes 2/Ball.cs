using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cong
{
    public class Ball
    {
        private int x, y, width, height;
        private int xSpeed, ySpeed;
        private Random randSpeed;


        private Image ballImage;
        private Rectangle ballRec;

        public Rectangle BallRec
        {
            get { return ballRec; }
        }

        public Ball()
        {
            randSpeed = new Random();
            x = 100;
            y = 600;
            width = 30;
            height = 30;

            xSpeed = randSpeed.Next(10, 15); //speed of the ball
            ySpeed = randSpeed.Next(10, 15); //speed of the ball

            ballImage = Cong.Properties.Resources.ball;

            ballRec = new Rectangle(x, y, width, height);
        }

        public void drawBall(Graphics paper)
        {
            paper.DrawImage(ballImage, ballRec);
        }

        public void moveBall()
        {
            ballRec.X += xSpeed;
            ballRec.Y += ySpeed;
        }
        public void collide()
        {
            if (ballRec.X < 0 || ballRec.X > 1500)
            {
                xSpeed *= -1;   //As soon as the ball collides with left or right barrier it will go opposite direction
            }
            if (ballRec.Y < 0)
            {
                ySpeed *= -1;
            }
            if (ballRec.Y > 790)                //bottom barrier
            {
                Environment.Exit(0);            //Window closes as ball trespasses.
                Console.WriteLine("Game Over"); //Displays to the console
            }

        }

        public void hitPaddle(Rectangle paddleRec)
        {
            if (paddleRec.IntersectsWith(ballRec))
            {
                ySpeed *= -1;

            }
        }

        public Boolean hitBrick(Rectangle brickRec)
        {
            if (brickRec.IntersectsWith(ballRec))
            {
                Console.Write("BALL HIT BRICK");//Displays to the console
                ySpeed *= -1;
            }
            return brickRec.IntersectsWith(ballRec);
        }
    }
}
