using BankApp.Exceptions;

namespace BankApp
{
    public class InvestmentAccount : Account
    {
        public InvestmentAccount(int id, decimal opening, decimal rate, decimal fee)
            : base(id, opening, rate, 0m, fee) { }

        public override void CalculateInterest()
        {
            decimal interest = balance * (interestRate / 100m);
            AddInterest(interest);
        }

        public override void Withdraw(decimal amount, bool staff)
        {
            if (amount <= 0)
            {
                last = "Withdrawal must be positive.";
                return;
            }

            if (amount > balance)
            {
                var fee = staff ? failedFee / 2m : failedFee;
                balance -= fee;
                last = $"Failed withdrawal; Fee {fee:0.00}; Balance {balance:0.00}";

                throw new FailedWithdrawalException(accountID, GetType().Name, amount, balance, staff, last);
            }

            base.Withdraw(amount, staff);
        }
    }
}