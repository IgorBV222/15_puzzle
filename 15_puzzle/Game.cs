using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_puzzle
{
    internal class Game
    {
        int size;
        int[,] arr;
        int empty_x;
        int empty_y;
        static Random rand = new Random();  
        public Game(int size) 
        {
            this.size = size;
            arr = new int [size, size];
        }
        public void start()
        {
            for (int x = 0;  x < size; x++) 
            {
                for(int y = 0; y < size; y++)
                {
                    arr[x, y] = coordsToPosition(x, y) + 1;
                }
            }
            empty_x = size - 1;
            empty_y = size - 1;
            arr[empty_x, empty_y] = 0;
        }       
        public int getNumber(int position) 
        {
            int x;
            int y;
            positionToCoords(position, out x, out y);
            if (x < 0 || x >= size)
            {
                return 0;
            }
            if (y < 0 || y >= size)
            {
                return 0;
            }
            return arr[x, y];
        }
        //определяем позицию кнопки (тэг)
        private int coordsToPosition (int x, int y) 
        { 
            if (x < 0)
            {
                x = 0;
            }
            if (x > size - 1)
            {
                x = size - 1;
            }
            if (y < 0)
            {
                y = 0;
            }
            if (y > size - 1)
            {
                y = size - 1;
            }
            return y * size + x;
        }
        //определяем координаты кнопки
        private void positionToCoords(int position, out int x, out int y)
        {
            if (position < 0)
            {
                position = 0;
            }
            if (position > size * size - 1)
            {
                position = size * size - 1;
            }
            x = position % size;
            y = position / size;
        }

        public void mixUpBtn(int position)
        {
            int x;
            int y;
            positionToCoords(position, out x, out y);
            if ((Math.Abs(empty_x - x) + Math.Abs(empty_y - y)) != 1 ) 
            {
                return;
            }
            arr[empty_x, empty_y] = arr[x, y];
            arr[x, y] = 0;
            empty_x = x;
            empty_y = y;
        }
        public void updateFieldRandom()
        {            
            int rn = rand.Next(0, 4);
            int x = empty_x;
            int y = empty_y;
            switch (rn)
            {
                case 0: x--; break;
                case 1: x++; break;
                case 2: y--; break;
                case 3: y++; break;
            }
            mixUpBtn(coordsToPosition(x, y));
        }
        //Проверка условия выигрыша
        public bool checkGame()
        {
            if (!((empty_x == (size - 1)) && (empty_y == (size - 1))))
            {
                return false;
            }
            else
            {
                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        if ((x != (size - 1)) && (y != (size - 1)))
                        {
                            if (arr[x, y] != (coordsToPosition(x, y) + 1))
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
    }    
}
