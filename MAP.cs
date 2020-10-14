using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class Map
    {
        public int XSize, YSize, NumberOfMine;
        public List<List<Node>> MAP_ = new List<List<Node>>();
        public Map(int X, int Y, int NumberOfMine)
        {
            this.XSize = X;
            this.YSize = Y;
            this.NumberOfMine = NumberOfMine;
            for (int y = 0; y < YSize + 2; y++)
            {
                MAP_.Add(new List<Node>());
                for (int x = 0; x < XSize + 2; x++)
                {
                    MAP_[y].Add(new Node());
                }
            }
        }
        public void DigMine()
        {
            int i = 0;
            Random rand = new Random();
            while (i < NumberOfMine)
            {
                int X_ = rand.Next(1, XSize + 1);
                int Y_ = rand.Next(1, YSize + 1);
                if (MAP_[Y_][X_].Contents != "*")
                {
                    MAP_[Y_][X_].Contents = "*";
                    i++;
                }
            }
        }
        public void CheckNearBy()
        {
            for (int y = 1; y < YSize + 1; y++)
            {
                for (int x = 1; x < XSize + 1; x++) 
                {
                    if (MAP_[y][x].Contents != "*")
                    {
                        WindowCheck(x, y);
                    }
                }
            }
        }
        public void WindowCheck(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (MAP_[y + i][x + j].Contents == "*")
                    {
                        MAP_[y][x].NearMine += 1;
                    }
                }
            }
        }
        public void Render()
        {
            for (int y = 1; y < YSize + 1; y++)
            {
                for (int x = 1; x < XSize + 1; x++)
                {
                    Console.Write(MAP_[y][x].Contents + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
