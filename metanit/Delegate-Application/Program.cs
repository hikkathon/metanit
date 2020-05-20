using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создадим банковский счёт
            Account account = new Account(200);
            Account.AccountStateHandler colorDelegate = new Account.AccountStateHandler(Color_Message);

            // Добавим в делегат ссылку на метод Show_Message
            // а сам делегат передаётся в качестве параметра метода RegisterHandker
            account.RegisterHandler(new Account.AccountStateHandler(Show_message));
            account.RegisterHandler(colorDelegate);

            // Два раза подряд пытаемся снять деньги
            account.Withdraw(100);
            account.Withdraw(150);

            // Удаляем делегат
            account.UnregisterHandler(colorDelegate);
            account.Withdraw(50);

            Console.ReadLine();
        }

        private static void Color_Message(string message)
        {
            // Устанавлеваем красный цвет символов
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            // Сбрасываем настройки цвета
            Console.ResetColor();
        }

        private static void Show_message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
