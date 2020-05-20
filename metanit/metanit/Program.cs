using System;
using System.Linq;

namespace metanit
{
    class ChrPair
    {
        public int First;
        public int Second;
        public int Midl;

        public ChrPair(int c1, int c2, int c3)
        {
            First = c1;
            Second = c2;
            Midl = c3;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] intenger1 = { 1, 2 };
            int[] intenger2 = { 3, 4 };
            int[] intenger3 = { 5, 6};
            var pairs = from ch1 in intenger1
                        from ch2 in intenger2
                        from ch3 in intenger3
                        select new ChrPair(ch1, ch2, ch3);

            Console.WriteLine("Все сочетания чисел: ");
            foreach (var p in pairs)
            {
                Console.WriteLine($"{p.First}, {p.Second}, {p.Midl}");
            }

            Console.ReadLine();
        }
    }
}
