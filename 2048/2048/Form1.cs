using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        private Game game;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            game = new Game();
           
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            game.Draw(e.Graphics);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                
           
            Invalidate(true);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                game.moveUp();
                game.addVertical();
                game.moveUp();
                game.addRandom();
            }
            else if (e.KeyCode == Keys.Left)
            {
                game.moveLeft();
                game.addHorizontal();
                game.moveLeft();
                game.addRandom();
            }
           
            Invalidate(true);
        }
    }
}
