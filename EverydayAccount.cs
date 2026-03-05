namespace BankApp
{
    public class EverydayAccount : Account
    {
        public EverydayAccount(int id, decimal opening)
            : base(id, opening, 0m, 0m, 0m) { }

        public override void CalculateInterest()
        {
            AddInterest(0m);
        }
    }
}