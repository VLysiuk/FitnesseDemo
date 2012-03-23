using System;

namespace SimpleBank
{
    public  class TransactionService
    {


        public void Deposit(BankUser bankUser, decimal money)
        {
            bankUser.Balance = money;
            bankUser.LastTransactionTime = DateTime.Now;
        }

        public decimal CalculateInterest(decimal currentBalance, 
                                            decimal minimumBalanceRate, 
                                            int years, decimal interestRatePerYear)
        {
            if (currentBalance < minimumBalanceRate)
                return 0;

            return currentBalance*interestRatePerYear*years;
        }

        public void Withdraw(BankUser bankUser, decimal money,decimal bankWithdrawFeeRate)
        {
            bankUser.Balance -= (money+money*bankWithdrawFeeRate);
            bankUser.LastTransactionTime = DateTime.Now;
        }
    }
}
