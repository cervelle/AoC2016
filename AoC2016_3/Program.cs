using System.Text.RegularExpressions;

namespace AoC2016_3
{
    class Program
    {
        static void Main()
        {
            var arg = @"C:\Users\Cervelle\Documents\Visual Studio 2013\Projects\AoC2016\AoC2016_3\arg.txt";
            var index = 0;

            foreach (var line in System.IO.File.ReadAllLines(arg))
            {
                Match matches = Regex.Match(line, @"(\d+)");
                var value1 = int.Parse(matches.Groups[1].Value);
                var value2 = int.Parse(matches.Groups[2].Value);
                var value3 = int.Parse(matches.Groups[3].Value);

                if (value1 + value2 > value3)
                    index++;

            }
        }
    }
}
