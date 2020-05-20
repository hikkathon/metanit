using System;

namespace Events_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc = new Account(100);
            acc.Added += new AccountStateHandler(Display);
            acc.Withdrawn += Display;
            acc.Put(100);
            acc.Withdraw(150);
            acc.Withdrawn -= Display;
            acc.Withdraw(150);

            Console.ReadKey(true);
        }

        private static void Display(object sender, AccountEventArgs e)
        {
            Console.WriteLine($"Сумма транзакции: {e.Sum}");
            Console.WriteLine(e.Message);
        }
    }
}
