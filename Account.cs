using System.Globalization;
using BankApp.Exceptions;

namespace BankApp
{
    public abstract class Account
    {
        protected int accountID;
        protected decimal balance;
        protected decimal interestRate;
        protected decimal overdraftLimit;
        protected decimal failedFee;
        protected string last = "";

        protected Account(int id, decimal opening, decimal rate, decimal od, decimal fee)
        {
            accountID = id;
            balance = opening;
            interestRate = rate;
            overdraftLimit = od;
            failedFee = fee;
        }

        public int GetAccountID() => accountID;
        public decimal GetBalance() => balance;
        public string Last() => last;

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                last = "Deposit must be positive.";
                return;
            }
            balance += amount;
            last = $"Deposited {amount:0.00}; Balance {balance:0.00}";
        }

        public virtual void Withdraw(decimal amount, bool staff)
        {
            if (amount <= 0)
            {
                last = "Withdrawal must be positive.";
                return;
            }

            var limit = balance + overdraftLimit;

            if (amount > limit)
            {
                var fee = staff ? failedFee / 2m : failedFee;
                balance -= fee;
                last = $"Failed withdrawal; Fee {fee:0.00}; Balance {balance:0.00}";

                throw new FailedWithdrawalException(accountID, GetType().Name, amount, limit, staff, last);
            }

            balance -= amount;
            last = $"Withdrawn {amount:0.00}; Balance {balance:0.00}";
        }

        public abstract void CalculateInterest();

        protected void AddInterest(decimal value)
        {
            balance += value;
            last = $"Interest added {value:0.00}; Balance {balance:0.00}";
        }
    }
}