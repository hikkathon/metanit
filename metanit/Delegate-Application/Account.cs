using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Application
{
    class Account
    {
        // Объявляем делегат
        public delegate void AccountStateHandler(string message);

        // Создадим переменную делената
        AccountStateHandler _del;

        // Регестрируем делегат
        public void RegisterHandler(AccountStateHandler del)
        {
            _del += del;
        }

        // Отмена регистрации делегата
        public void UnregisterHandler(AccountStateHandler del)
        {
            _del -= del;
        }

        int _sum; 

        public Account(int sum)
        {
            _sum = sum;
        }

        public int CurrentSum
        {
            get { return _sum; }
        }

        public void Put(int sum)
        {
            _sum += sum;
        }

        public void Withdraw(int sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;

                if (_del != null)
                {
                    _del($"Сумма {sum} снята со счёта");
                }
            }
            else
            {
                if (_del != null)
                {
                    _del("Недостаточно денег на счёте");
                }
            }
        }
    }
}
