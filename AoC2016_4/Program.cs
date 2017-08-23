using System.Text.RegularExpressions;
using System;
using System.Linq;
using System.Collections.Generic;


namespace AoC2016_4
{
    public class Program
    {
        public static void Main()
        {
            //var total = 0;
            const string arg = @"C:\Users\Cervelle\Documents\Visual Studio 2013\Projects\AoC2016\AoC2016_4\arg.txt";
            const string pattern = @"(?<name>.+)-(?<id>\d+)\[(?<check>.+)\]$";
            //

            foreach (var line in System.IO.File.ReadAllLines(arg))
            {
                var m = Regex.Match(line,pattern);

                string encrypted= new string(m.Groups["name"].Value.Where(x=>char.IsLetterOrDigit(x)).ToArray());
                var id = int.Parse(m.Groups["id"].Value);


                if (Decrypt(encrypted, id % 26).Contains("north"))
                    Console.WriteLine("{0}",id);

                    


                //total += check ? id : 0;

//                Console.WriteLine(m.Groups["id"].Value);

            }
        }

        static internal bool CheckValidity(string raw, string result) 
        {
            var dico= new Dictionary<char,int>();
            foreach (char c in raw)
            {
                if (dico.ContainsKey(c))
                    ++dico[c];
                else dico.Add(c, 1);
            }

            var toto = dico.OrderBy(k => k.Key).OrderByDescending(x => x.Value).ToDictionary(a=>a.Key,b=>b.Value).Keys.ToList();
            //var tata = toto.Keys;

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != toto[i])
                    return false;
            }

            
            return true;
        }

        static string Decrypt(string value, int shift)
        {
            char[] buffer = value.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                // Letter.
                char letter = buffer[i];
                // Add shift to all.
                letter = (char)(letter + shift);
                // Subtract 26 on overflow.
                // Add 26 on underflow.
                if (letter > 'z')
                {
                    letter = (char)(letter - 26);
                }
                else if (letter < 'a')
                {
                    letter = (char)(letter + 26);
                }
                // Store.
                buffer[i] = letter;
            }
            return new string(buffer);
        }
    }
}
