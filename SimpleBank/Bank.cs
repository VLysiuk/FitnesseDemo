using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBank
{
    public class Bank
    {
        //These objects were not injected but created inside Bank class
        //for the sake of simplicity and demonstration purposes
        private readonly UserRepository _userRepository;
        private readonly TransactionService _transactionService;

        public const decimal MinimumBalanceRate = 999;
        private const decimal InterestRatePerYear = 0.1m;
        private const decimal BankWithdrawFee = 0.02m;

        public Bank()
        {
            _userRepository=new UserRepository();
            _transactionService = new TransactionService();
        }

        public int RegisterUser(string username, string password, string name, string address, string phoneNumber)
        {
            return _userRepository.CreateUser(username,password,name,address,phoneNumber);
        }

        public BankUser GetUser(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public bool HasAccess(string userName,string password)
        {
            var user = _userRepository.GetUserByName(userName);
            
            if (user != null && user.Password == password)
                return true;

            return false;
        }

        public void DepositMoney(string userName, decimal money)
        {
            var bankUser = _userRepository.GetUserByName(userName);
            _transactionService.Deposit(bankUser,money);
        }

        public decimal CalculateInterest(string userName,int years)
        {
            var bankUser = _userRepository.GetUserByName(userName);
            return _transactionService.CalculateInterest(bankUser.Balance, MinimumBalanceRate, years,InterestRatePerYear);
        }

        public void WithdrawMoney(string userName, decimal money)
        {
            var bankUser = _userRepository.GetUserByName(userName);
            _transactionService.Withdraw(bankUser, money,BankWithdrawFee);
        }
    }
}
