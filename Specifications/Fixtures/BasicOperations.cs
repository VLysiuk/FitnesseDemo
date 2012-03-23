using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBank.Specifications.Fixtures
{
    public class CalculateInterest : BasicOperations
    {
        public CalculateInterest(int currentUserId) : base(currentUserId)
        {
        }

        public bool UserCanHaveInterest(string userName)
        {
            decimal interest = SetUpTestEnvironment.Bank.CalculateInterest(userName, 1);
            return interest == 0 ? false : true;
        }

        public decimal UserInterestInOneYear(string userName)
        {
            return SetUpTestEnvironment.Bank.CalculateInterest(userName, 1);
        }
    }

    public class WithdrawMoney : BasicOperations
    {
        public WithdrawMoney(int currentUserId) : base(currentUserId)
        {
        }

        public void UserWithdrawsMoneyFromHisAccount(string userName, decimal money)
        {
            SetUpTestEnvironment.Bank.WithdrawMoney(userName,money);
        }
    }

    public class BasicOperations
    {
        private readonly BalanceInfo _balanceInfo;

        public BasicOperations(int currentUserId)
        {
            _balanceInfo = new BalanceInfo(currentUserId);
        }

        public void UserDepositsMoneyToHisAccount (string userName,decimal money)
        {
            SetUpTestEnvironment.Bank.DepositMoney(userName, money);
        }

        public decimal ShowBalance()
        {
            return _balanceInfo.ShowBalance();
        }

        public DateTime LastTransactionTime()
        {
            return _balanceInfo.LastTransactionTime();
        }
    }

    public class BalanceInfo
    {
        //used to demonstrate how to pass parameters to constructor 
        //from Fitnesse tables
        private readonly int _currentUserId;

        public BalanceInfo(int currentUserId)
        {
            _currentUserId = currentUserId;
        }

        public decimal ShowBalance()
        {
            var currentUser = SetUpTestEnvironment.Bank.GetUser(_currentUserId);
            return currentUser.Balance;
        }

        public DateTime LastTransactionTime()
        {
            var currentUser = SetUpTestEnvironment.Bank.GetUser(_currentUserId);
            return currentUser.LastTransactionTime;
        }
    }
}
