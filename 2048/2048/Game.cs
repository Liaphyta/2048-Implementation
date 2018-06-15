using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2048
{
    class Game
    {
        //Matrica 4x4 sto ke gi reprezentira site kvadratcinja od igrata i od koja posle ke se iscrtuva samata 
        //igra
       public int[,] mat;
        List<Square> squares;
        public Game()
        {
            mat = new int [4, 4];
            squares = new List<Square>();
            addRandom();//igrata pocnuva so dve 2ki na slucajni pozicii vo gridot
            addRandom();
            
        }
        //Funkcija sto dodava 2ka na random mesto vo igrata
      
        public void Draw(Graphics g)
        {
            updateList();
            foreach (Square s in squares)
                s.Draw(g);
        }
        public void updateList()
        {
            squares.Clear();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (mat[i, j] != 0)
                        squares.Add(new Square(new Point(100 * i, 100 * j), mat[i, j], Color.Gray));

        }
        public void addRandom()
        {
            Random rand = new Random();
            List<int> pick = getAvaliablePlaces();
            int index = rand.Next(pick.Count);
            int i = pick.ElementAt(index) / 4;
            int j = pick.ElementAt(index) % 4;
            mat[i, j] = 2;
        }
        public List<int> getAvaliablePlaces() {
            List<int> ret = new List<int>();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (mat[i, j] == 0)
                        ret.Add(i * 4 + j);
            return ret;
        }
    }
}
