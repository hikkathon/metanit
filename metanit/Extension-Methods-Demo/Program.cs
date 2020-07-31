using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Methods_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Аниме - этот мир, наполненный, чем-то непонятным, но очень близким.";
            char c = 'о';
            int i = s.CharCount(c);
            Console.WriteLine(i);

            Console.Read();
        }
    }

    public static class StringExtension
    {
        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }
    }
}
