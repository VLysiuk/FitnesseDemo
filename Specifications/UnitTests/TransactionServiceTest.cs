using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SimpleBank.Specifications.UnitTests
{
    [TestFixture]
    public class TransactionServiceTest
    {
        [Test]
        public void ShouldIncreaseUserBalanceWhenDepositMoney()
        {
            var transactionService = new TransactionService();
            var bankUser = new BankUser();
            transactionService.Deposit(bankUser, 100);

            Assert.AreEqual(100,bankUser.Balance);
        }

        [Test]
        public void ShouldUpdateLastTransactionTimeWhenDepositMoney()
        {
            var transactionService = new TransactionService();
            var defaultTransactionTime = DateTime.MinValue;
            var bankUser = new BankUser(){LastTransactionTime =defaultTransactionTime};
            transactionService.Deposit(bankUser, 100);

            Assert.IsTrue(bankUser.LastTransactionTime>defaultTransactionTime);
        }

        [Test]
        public void ShouldCalculateInterestWhenBalanceIsAboveMinimum()
        {
            var transactionService = new TransactionService();
            
            var interest = transactionService.CalculateInterest(2000,1000,1,0.1m);

            Assert.AreEqual(200, interest);
        }

        [Test]
        public void ShouldNotCalculateInterestWhenBalanceIsBelovMinimum()
        {
            var transactionService = new TransactionService();

            var interest = transactionService.CalculateInterest(100, 1000, 1,0.1m);

            Assert.AreEqual(0,interest);
        }

        [Test]
        public void ShouldDecreaseUserBalanceWhenWithdrawMoney()
        {
            var transactionService = new TransactionService();
            var bankUser = new BankUser(){Balance = 500};
            transactionService.Withdraw(bankUser, 100,0.02m);

            Assert.AreEqual(398, bankUser.Balance);
        }

        [Test]
        public void ShouldUpdateLastTransactionTimeWhenWithdrawMoney()
        {
            var transactionService = new TransactionService();
            var defaultTransactionTime = DateTime.MinValue;
            var bankUser = new BankUser() {Balance = 300, LastTransactionTime = defaultTransactionTime };
            transactionService.Withdraw(bankUser, 100,0.02m);

            Assert.IsTrue(bankUser.LastTransactionTime > defaultTransactionTime);
        }
    }
}
