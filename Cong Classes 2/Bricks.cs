using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cong
{
    class Brick
    {
        private int x, y, width, height;

        private Image brickImage;
        private Rectangle brickRec;

        Boolean dead = false;


        public Rectangle BrickRec
        {
            get { return brickRec; }
        }

        public Brick(int position)
        {
            width = 150;
            height = 120;

            int row = position / 10; //row 10 bricks                     
            int col = position % 10; //column 10 bricks
            x = 0 + (width * col);  
            y = 0 + (height * row);

            brickImage = Cong.Properties.Resources.brick;

            brickRec = new Rectangle(x, y, width, height);

        }

        public void drawBrick(Graphics paper)
        {
            if (!dead)
            {
                paper.DrawImage(brickImage, brickRec);
            }
        }

        public void kill()
        {
            dead = true;
        }

        public Boolean isDead() 
        {
            return dead;
        }

    }
}