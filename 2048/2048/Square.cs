using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2048
{
    class Square
    {
        Point pos;
        Color color;
        int value;
        // Site kvadratcinja ke se so 50px strana
        // ova testiram dali mozhe da se kommitne
        public static int side = 50;
        public Square(Point pos, int value, Color color)
        {
            this.pos = pos;
            this.value = value;
            this.color = color;
        }
        public void Draw(Graphics g)
        {
            g.FillRectangle;
        }
    }
}
