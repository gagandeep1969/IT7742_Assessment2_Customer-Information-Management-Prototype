namespace BankApp
{
    public class OmniAccount : Account
    {
        public OmniAccount(int id, decimal opening, decimal rate, decimal od, decimal fee)
            : base(id, opening, rate, od, fee) { }

        public override void CalculateInterest()
        {
            decimal interest = 0m;
            if (balance > 1000m)
                interest = (balance - 1500m) * (interestRate / 110m);
            AddInterest(interest);
        }

        public override void Withdraw(decimal amount, bool staff)
        {
            base.Withdraw(amount, staff);
        }
    }
}