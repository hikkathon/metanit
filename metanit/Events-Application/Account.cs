using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_Application
{
    delegate void AccountStateHandler(object sender, AccountEventArgs e);

    class AccountEventArgs : EventArgs
    {
        // Сообщение
        public string Message { get; }
        // Сумма, на которуб изменился счёт
        public int Sum { get; }

        public AccountEventArgs(string mes, int sum)
        {
            Message = mes;
            Sum = sum;
        }
    }

    class Account
    {
        public event AccountStateHandler Added; // Определение события (Past Particle)
        public event AccountStateHandler Adding; // Определение события (ing-form)
        public event AccountStateHandler Withdrawn; // Определение события (Past Particle)

        public Account(int sum)
        {
            Sum = sum;
        }

        // Сумма на счете
        public int Sum { get; set; }

        // Добавление средств на счёт
        public void Put(int sum)
        {
            Adding?.Invoke(this, new AccountEventArgs($"На счет добовляется: {sum}", sum));
            Sum += sum;
            Added?.Invoke(this, new AccountEventArgs($"На счет поступило: {sum}", sum));
        }

        // Списание средств со счёта
        public void Withdraw(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                Withdrawn?.Invoke(this, new AccountEventArgs($"Со счёта снято: {sum}", sum));
            }
            else
            {
                Withdrawn?.Invoke(this, new AccountEventArgs($"Недостаточно денег на счёте. Текущий баланс: {Sum}", 0));
            }
        }
    }
}
