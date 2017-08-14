using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2016_1
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = System.IO.File.ReadAllLines(@"C:\Users\Cervelle\Documents\Visual Studio 2013\Projects\AoC2016\AoC2016_1\arg.txt");

            var tab = new List<Order>();

            foreach (var item in input[0].Split(',').ToList())
            {
//                var item2 = item.TrimEnd(',');
                
                tab.Add
                    (new Order
                        {
                            Direction = getDirection(item),
                            Distance = getDistance(item)
                        }
                    );
            }

            char dir = 'N';
            int x = 0;
            int y = 0;

            var locationVisited = new List<Tuple<int, int>>();

            //locationVisited.Add(new Tuple<int, int>(x, y));
            CheckCrossAndAdd(locationVisited, 0, 0);

            foreach (var item in tab)
            {
                
                if (dir == 'N')
                {
                    if (item.Direction == 'L')
                    {
                        KeepTrack(locationVisited, x, y, x - item.Distance, y);
                        x -= item.Distance;
                        dir = 'W';
                        continue;
                    }
                    if (item.Direction == 'R')
                    {
                        KeepTrack(locationVisited, x, y, x + item.Distance, y);
                        x += item.Distance;
                        dir = 'E';
                        continue;
                    }
                }

                if (dir == 'S')
                {
                    if (item.Direction == 'L')
                    {
                        KeepTrack(locationVisited, x, y, x + item.Distance, y);
                        x += item.Distance;
                        dir = 'E';
                        continue;
                    }
                    if (item.Direction == 'R')
                    {
                        KeepTrack(locationVisited, x, y, x - item.Distance, y);
                        x -= item.Distance;
                        dir = 'W';
                        continue;
                    }
                }

                if (dir == 'W')
                {
                    if (item.Direction == 'L')
                    {
                        KeepTrack(locationVisited, x, y, x, y - item.Distance);
                        y -= item.Distance;
                        dir = 'S';
                        continue;
                    }
                    if (item.Direction == 'R')
                    {
                        KeepTrack(locationVisited, x, y, x, y + item.Distance);
                        y += item.Distance;
                        dir = 'N';
                        continue;
                    }
                }

                if (dir == 'E')
                {
                    if (item.Direction == 'L')
                    {
                        KeepTrack(locationVisited, x, y, x, y + item.Distance);
                        y += item.Distance;
                        dir = 'N';
                        continue;
                    }
                    
                    if (item.Direction == 'R')
                    {
                        KeepTrack(locationVisited, x, y, x, y - item.Distance);
                        y -= item.Distance;
                        dir = 'S';
                        continue;
                    }
                }
            }

        }

        static public void CheckCrossAndAdd(List<Tuple<int, int>> locationVisited, int x, int y)
        {
            if (locationVisited.Any(v => (v.Item1 == x && v.Item2 == y)))
                Console.WriteLine("Found a cross : ({0},{1})", x, y);
            else
                locationVisited.Add(new Tuple<int, int>(x, y));
        }

        static public void KeepTrack(List<Tuple<int, int>> locationVisited, int x, int y, int newX, int newY)
        {
            if (x==newX)
            {
                if (y>newY)
                    KeepTrackY(locationVisited, x, y, newY, -1);
                if (y < newY)
                    KeepTrackY(locationVisited, x, y, newY, 1);
            }
            else if (y == newY)
            {
                if (x > newX)
                    KeepTrackX(locationVisited, x, y, newX, -1);
                if (x < newX)
                    KeepTrackX(locationVisited, x, y, newX, 1);
            }
        }

        static public void KeepTrackY(List<Tuple<int, int>> locationVisited, int x, int y, int newY, int ratio)
        {
            while (y != newY)
			{
                y += ratio;
                CheckCrossAndAdd(locationVisited,x,y);
			}
        }

        static public void KeepTrackX(List<Tuple<int, int>> locationVisited, int x, int y, int newX, int ratio)
        {
            while (x != newX)
            {
                x += ratio;
                CheckCrossAndAdd(locationVisited, x, y);
            }
        }


        static public int getDistance(string input)
        {

            Match match = Regex.Match(input, @"(\d+)");
            return int.Parse(match.Groups[1].Value);
        }

        static public char getDirection(string input)
        {

            Match match = Regex.Match(input, @"(\S)");
            return char.Parse(match.Groups[1].Value);
        }
    }

    public class Order
    {
        public char Direction;

        public int Distance;


    }
}
