using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2016_2
{
    class Program
    {
        static void Main()
        {
            string[] input = System.IO.File.ReadAllLines(@"C:\Users\Cervelle\Documents\Visual Studio 2013\Projects\AoC2016\AoC2016_2\arg.txt");
            var position = new cordinate(-2,0);

            foreach (var line in input)
            {
                foreach(char c in line)
                {
                    position = MovePosition(position, c);                    
                }
                Console.Write("{0}", matrix(position));
            }

        }

        static char matrix(cordinate c)
        {
            if (c.X == 0 && c.Y == 2)
                return '1';
            if (c.X == -1 && c.Y == 1)
                return '2';
            if (c.X == 0 && c.Y == 1)
                return '3';
            if (c.X == 1 && c.Y == 1)
                return '4';
            if (c.X == -2 && c.Y == 0)
                return '5';
            if (c.X == -1 && c.Y == 0)
                return '6';
            if (c.X == 0 && c.Y == 0)
                return '7';
            if (c.X == 1 && c.Y == 0)
                return '8';
            if (c.X == 2 && c.Y == 0)
                return '9';
            if (c.X == -1 && c.Y == -1)
                return 'A';
            if (c.X == 0 && c.Y == -1)
                return 'B';
            if (c.X == 1 && c.Y == -1)
                return 'C';
            if (c.X == 0 && c.Y == -2)
                return 'D';

            return '0';
        }

        static public cordinate MovePosition(cordinate cordinate, char c)
        {
            switch(c)
            {
                case 'U':
                    cordinate.Y += 1;
                    break;
                case 'D':
                    cordinate.Y -= 1;
                    break;
                case 'L':
                    cordinate.X -= 1;
                    break;
                case 'R':
                    cordinate.X += 1;
                    break;
            }

            return cordinate;
        }

        

    }

    public struct cordinate
    {
        private int _x;
        private int _y;

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                if (Math.Abs(value) <= 2 && (Math.Abs(value) + Math.Abs(_y)) <= 2)
                    _x = value;
            }
        }
        public int Y
        {
            get
            { 
                return _y;
            }
            set
            {
                if (Math.Abs(value) <= 2 && (Math.Abs(value) + Math.Abs(_x)) <= 2)
                    _y = value;
            }
        }     

        public cordinate(int x, int y)
        {
            _x=x;
            _y=y;
        }
    }
}
