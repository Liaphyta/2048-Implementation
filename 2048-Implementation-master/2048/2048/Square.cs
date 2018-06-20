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
        public Dictionary<int,Color> boi;

        // Site kvadratcinja ke se so 100px strana
        // ova testiram dali mozhe da se kommitne
        public static int side = 100;
        public Square(Point pos, int value, Color color)
        {
            this.pos = pos;
            this.value = value;
            this.color = color;
            boi = new Dictionary<int, Color>();
            boi.Add(2,Color.FromArgb(224,224,224));
            boi.Add(4, Color.FromArgb(255, 204, 153));
            boi.Add(8, Color.FromArgb(255, 153, 51));
            boi.Add(16, Color.FromArgb(204, 102, 0));
            boi.Add(32, Color.FromArgb(255, 102, 102));
            boi.Add(64, Color.FromArgb(255, 51, 51));
            if (boi.ContainsKey(value))
                this.color = boi[this.value];
            else
                this.color = Color.FromArgb(255, 255, 120 - (this.value / 64));


        }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(this.color);
            Brush fb;
            if (this.value != 2 && this.value != 4)
                 fb = new SolidBrush(Color.White);
            else
                 fb = new SolidBrush(Color.Black);
            g.FillRectangle(b, pos.X, pos.Y, side, side);
            Font font = new Font("Arial", 20);
            int offset;
            if (this.value < 100)
                offset = 35;
            else
                offset = 25;
            g.DrawString(string.Format("{0}", value), font, fb, pos.X + offset, pos.Y +offset +10);
            b.Dispose();
            fb.Dispose();
        }
    }
}
