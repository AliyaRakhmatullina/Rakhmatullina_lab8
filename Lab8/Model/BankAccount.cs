using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Model
{
    public class BankAccount
    {
        private int number;
        private decimal balance;
        private TypeAccount typeAccount;
        private static int counter = 1;

       
        public BankAccount(decimal balance, TypeAccount typeAccount)
        {
            Balance = balance;
            TypeAccount = typeAccount;
            number = counter;
            Increment();
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public TypeAccount TypeAccount
        {
            get { return typeAccount; }
            set { typeAccount = value; }
        }

        private void Increment()
        {
            counter++;
        }

        public void PutMoney(decimal money)
        {
            balance += money;
        }

        public bool Withdraw(decimal money)
        {
            if (money <= balance)
            {
                balance -= money;
                return true;
            }
            return false;
        }

        public void Transfer(BankAccount bankAccount, decimal money)
        {
            if (bankAccount.Withdraw(money))
            {
                PutMoney(money);
            }
        }
    }
}
