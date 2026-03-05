using System;
using System.Globalization;

namespace BankApp
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Bank Account Manager");
            var cust = new Customer(303, "TestCustomer", "customer@test.com", true);

            var every = new EverydayAccount(12, 500m);
            var invest = new InvestmentAccount(15, 900m, 5m, 15m);
            var omni = new OmniAccount(19, 1100m, 3m, 150m, 10m);

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"User: {cust.GetName()} (Staff: {cust.IsStaff()})");
                Console.WriteLine("Select Account  [E]veryday  [I]nvestment  [O]mni  [0] Exit");
                Console.Write("Choose: ");
                var sel = Console.ReadLine()?.Trim().ToUpper();
                if (sel == "0") break;

                Account acc = sel switch
                {
                    "E" => every,
                    "I" => invest,
                    "O" => omni,
                    _ => every
                };

                Console.WriteLine();
                Console.WriteLine("1 Deposit  |  2 Withdraw  |  3 Add Interest  |  4 Show Info  |  x Back");
                Console.Write("Choose One Option: ");
                var act = Console.ReadLine()?.Trim().ToLower();
                if (act == "x") continue;

                if (act == "1")
                {
                    Console.Write("Enter amount: ");
                    if (decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out var amt))
                        acc.Deposit(amt);
                    Console.WriteLine(acc.Last());
                }
                else if (act == "2")
                {
                    Console.Write("Enter amount: ");
                    if (decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out var amt))
                    {
                        try
                        {
                            acc.Withdraw(amt, cust.IsStaff());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    Console.WriteLine(acc.Last());
                }
                else if (act == "3")
                {
                    acc.CalculateInterest();
                    Console.WriteLine(acc.Last());
                }
                else if (act == "4")
                {
                    Console.WriteLine($"Account {acc.GetAccountID()} has {acc.GetBalance():0.00}");
                }
                else
                {
                    Console.WriteLine("Invalid option. Try again.");
                }
            }

            Console.WriteLine("\nThank you for using the Account Manager.");
        }
    }
}