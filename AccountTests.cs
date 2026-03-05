using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankApp;
using BankApp.Exceptions;

namespace BankAppTests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void Deposit_positive_adds()
        {
            var a = new EverydayAccount(1, 100m);
            a.Deposit(50m);
            Assert.AreEqual(150m, a.GetBalance());
        }

        [TestMethod]
        public void Deposit_zero_no_change()
        {
            var a = new EverydayAccount(1, 100m);
            a.Deposit(0m);
            Assert.AreEqual(100m, a.GetBalance());
        }

        [TestMethod]
        public void Withdraw_everyday_success()
        {
            var a = new EverydayAccount(1, 100m);
            a.Withdraw(40m, false);
            Assert.AreEqual(60m, a.GetBalance());
        }

        [TestMethod]
        public void Withdraw_everyday_fail_throws()
        {
            var a = new EverydayAccount(1, 100m);

            Assert.ThrowsException<FailedWithdrawalException>(() =>
            {
                a.Withdraw(200m, false);
            });

            Assert.AreEqual(100m, a.GetBalance());
        }

        [TestMethod]
        public void Withdraw_invest_fail_fee_normal()
        {
            var a = new InvestmentAccount(2, 100m, 5m, 15m);

            Assert.ThrowsException<FailedWithdrawalException>(() =>
            {
                a.Withdraw(200m, false);
            });

            Assert.AreEqual(85m, a.GetBalance());
        }

        [TestMethod]
        public void Withdraw_invest_fail_fee_staff_half()
        {
            var a = new InvestmentAccount(2, 100m, 5m, 15m);

            Assert.ThrowsException<FailedWithdrawalException>(() =>
            {
                a.Withdraw(200m, true);
            });

            Assert.AreEqual(92.5m, a.GetBalance());
        }

        [TestMethod]
        public void Withdraw_omni_overdraft_allows()
        {
            var a = new OmniAccount(3, 100m, 3m, 150m, 10m);
            a.Withdraw(200m, false);
            Assert.AreEqual(-100m, a.GetBalance());
        }

        [TestMethod]
        public void Withdraw_omni_fail_throws_and_fee()
        {
            var a = new OmniAccount(3, 100m, 3m, 150m, 10m);

            Assert.ThrowsException<FailedWithdrawalException>(() =>
            {
                a.Withdraw(400m, false);
            });

            Assert.AreEqual(90m, a.GetBalance());
        }

        [TestMethod]
        public void Interest_invest_adds()
        {
            var a = new InvestmentAccount(5, 900m, 5m, 15m);
            a.CalculateInterest();
            Assert.AreEqual(945m, a.GetBalance());
        }

        [TestMethod]
        public void Interest_everyday_zero()
        {
            var a = new EverydayAccount(6, 500m);
            a.CalculateInterest();
            Assert.AreEqual(500m, a.GetBalance());
        }

        [TestMethod]
        public void Customer_set_contact()
        {
            var c = new Customer(10, "A", "old", true);
            c.SetContact("new");
            Assert.AreEqual("new", c.GetContact());
        }
    }
}