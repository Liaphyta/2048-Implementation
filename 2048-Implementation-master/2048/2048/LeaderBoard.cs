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
    public partial class LeaderBoard : Form
    {
        List<int> highscores;
        public LeaderBoard()
        {
            highscores = new List<int>();
            InitializeComponent();
            
        }
        public void getHighScores(List<int> highscores)
        {
            this.highscores = highscores;
            this.highscores.Sort();
            for (int i = 0; i < highscores.Count; i++)
            {
                listBox.Items.Add(i+ ". " + highscores.ElementAt(i));
            }

        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           // listBox.DataSource = highscores;
            
            
        }
    }
}
