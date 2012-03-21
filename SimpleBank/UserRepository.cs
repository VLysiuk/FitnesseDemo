using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBank
{
    public class UserRepository
    {
        private readonly List<BankUser> _bankUsers;

        public UserRepository()
        {
            _bankUsers = new List<BankUser>();
        }

        public int CreateUser(string accountName, string password, string fullName, string address, string phone)
        {
            if (_bankUsers.Exists(u => u.AccountName == accountName))
                throw new InvalidOperationException("");

            _bankUsers.Add(new BankUser
                               {
                                   AccountName = accountName,
                                   Password = password,
                                   Address = address,
                                   FullName = fullName,
                                   PhoneNumber = phone
                               });
            return _bankUsers.Count - 1;
        }

        public BankUser GetUserById(int userId)
        {
            return _bankUsers[userId];
        }
        
        public BankUser GetUserByName(string accountName)
        {
            return _bankUsers.Where(u => u.AccountName == accountName).FirstOrDefault();
        }
    }
}