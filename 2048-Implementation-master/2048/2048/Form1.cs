﻿using System;
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
        private List<int> highscores;
        int currentScore;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            game = new Game();
            //niza od skorovi i momentalen skor
            highscores = new List<int>();
            currentScore = 0;
            updateScores();

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
            e.Handled = true;
            Invalidate(true);
        }
       

       



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //this.AcceptButton = null;
            e.Handled = true;
           
            if (e.KeyCode == Keys.Up)
            {
                //e.SuppressKeyPress = true;
                game.moveUp();
                game.addVertical();
                game.moveUp();
                game.addRandom();
            }
            else if (e.KeyCode == Keys.Left)
            {
                //e.SuppressKeyPress = true;

                game.moveLeft();
                game.addHorizontal();
                game.moveLeft();
                game.addRandom();
            }
            updateScores();
            Invalidate(true);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void label2_Click(object sender, EventArgs e)
        {
            //game = new Game();
        }
        private void updateScores()
        {
            currScore.Text = currentScore.ToString();
            if (highscores.Count == 0)
                highScore.Text = 0.ToString();
            else
                highScore.Text = highscores.Max().ToString();




        }
        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            highscores.Add(currentScore);
            updateScores();
            currentScore = 0;
            game = new Game();
            Invalidate(true);
        }

        private void label3_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}