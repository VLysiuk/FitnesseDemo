using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBank.Specifications.Fixtures
{
    public class SetUpTestEnvironment
    {
        internal static Bank Bank;

        public SetUpTestEnvironment()
        {
            Bank=new Bank();
        }
    }

    public class RegisterUser
    {
        private string _errorMessage = "no";
        public string Username;
        public string Password;
        public string Name;
        public string Address;
        public string PhoneNumber;

        public int UserId()
        {
            int userId = -1;
            try
            {
                userId=SetUpTestEnvironment.Bank.RegisterUser(Username, Password, Name, Address, PhoneNumber);
            }
            catch (InvalidOperationException)
            {
                userId = -1;
                _errorMessage = "Client with same username already exists";
            }
            return userId;
        }

        public string Error()
        {
            return _errorMessage;
        }
    }

    public class CheckStoredDetails
    {
        public int UserId;

        public string Username()
        {
            var user =SetUpTestEnvironment.Bank.GetUser(UserId);
            return user.AccountName;
        }

        public string Name()
        {
            var user = SetUpTestEnvironment.Bank.GetUser(UserId);
            return user.FullName;
        }

        public string Address()
        {
            var user = SetUpTestEnvironment.Bank.GetUser(UserId);
            return user.Address;
        }

        public string PhoneNumber()
        {
            var user = SetUpTestEnvironment.Bank.GetUser(UserId);
            return user.PhoneNumber;
        }

        public decimal Balance()
        {
            var user = SetUpTestEnvironment.Bank.GetUser(UserId);
            return user.Balance;
        }
    }

    public class CheckLogIn
    {
        public string Username;
        public string Password;

        public string CanLogIn()
        {
            return SetUpTestEnvironment.Bank.HasAccess(Username, Password) ? "yes" : "no";
        }
    }
}
