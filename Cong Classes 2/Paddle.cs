using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cong
{
    public class Paddle
    {
        private int x, y, width, height;

       
        private Image paddleImage;
        private Rectangle paddleRec;
        

        public Rectangle PaddleRec
        {
            get { return paddleRec; }
        }
        public Paddle()
        {
           
            x = 100;
            y = 700;
            width = 150;
            height = 60;
            paddleImage = Cong.Properties.Resources.arkanoid;

            paddleRec = new Rectangle(x, y, width, height);

        }
        public void drawPaddle(Graphics paper)
        {
            paper.DrawImage(paddleImage, paddleRec);
        }

        public void movePadle(int mouseX)
        {
            paddleRec.X = mouseX - (paddleRec.Width / 2); 
        }
       
    }
}
