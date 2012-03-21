using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBank
{
    public class Bank
    {
        private readonly UserRepository _userRepository;

        public Bank()
        {
            _userRepository=new UserRepository();
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
    }
}
