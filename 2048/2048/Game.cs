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
            //  addRandom();//igrata pocnuva so dve 2ki na slucajni pozicii vo gridot
            // addRandom();
            mat[0, 0] = 1;
            mat[3, 1] = 4;
           // mat[3, 2] = 3;
            mat[3, 3] = 4;
           

        }
       
      
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
        //Funkcija sto dodava 2ka na random mesto vo igrata
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
        public Boolean anyRemaining(int[] arr, int i)
        {
            for (int j = i + 1; j < arr.Length;j++)
                if (arr[j] != 0)
                    return true;
            return false;
        }
        public int[] getColumn(int i)
        {
            int[] ret = new int[4];
            for (int j = 0; j < 4; j++)
                ret[j] = mat[i,j];
            return ret;
        }
        public void addHorizontal()
        {
            for(int i=0;i<4;i++)
                for(int j = 0; j < 3; j++)
                {
                    if (mat[i, j] == 0)
                        continue;
                    if (mat[i, j] == mat[i, j + 1]) {
                        mat[i, j] += mat[i, j + 1];
                         mat[i, j + 1] = 0;
                        j++;
                    }
                }
        }
        public void moveUp()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (!anyRemaining(getColumn(i), j))
                        break;
                    if (mat[i, j] != 0)
                        continue;
                    int toSwap = 0;
                    if (getNextNumber(getColumn(i), j, out toSwap))
                        swap(i, j, i, toSwap);
                    else
                        break;
                }
            // addRandom();

        }
        public Boolean getNextNumber(int[] arr,int start, out int next)
        {
            for (int i = start + 1; i < arr.Length; i++)
                if (arr[i] != 0)
                {
                    next = i;
                    return true;
                }
            next = -1;
            return false;
        }
        public void swap(int i1, int j1, int i2, int j2)
        {
            int temp = mat[i1, j1];
            mat[i1, j1] = mat[i2, j2];
            mat[i2, j2] = temp;
           
        }
    }
}
