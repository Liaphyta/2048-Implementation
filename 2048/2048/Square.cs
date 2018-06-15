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
        public Point pos;
        Color color;
        int value;
        // Site kvadratcinja ke se so 100px strana
        // ova testiram dali mozhe da se kommitne
        public static int side = 100;
        public Square(Point pos, int value, Color color)
        {
            this.pos = pos;
            this.value = value;
            this.color = color;
        }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(color);
            Brush fb = new SolidBrush(Color.White);
            g.FillRectangle(b, pos.X, pos.Y, side, side);
            Font font = new Font("Arial", 20);
            g.DrawString(string.Format("{0}", value), font, fb, pos.X + 35, pos.Y +35);
            b.Dispose();
        }
    }
}
