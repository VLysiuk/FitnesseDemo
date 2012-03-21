using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SimpleBank.Specifications.UnitTests
{
    [TestFixture]
    public class UserRepositoryTest
    {
        [Test]
        public void ShouldReturnUserById()
        {
            const string accountName = "super_user";
            var repo = new UserRepository();
            repo.CreateUser("user_name1", "password", "name1", "address", "phone");
            repo.CreateUser(accountName, "password", "name2", "address", "phone");

            var bankUser = repo.GetUserById(1);

            Assert.AreEqual(accountName,bankUser.AccountName);
        }

        [Test]
        public void ShouldCreateNewUserAndReturnHisId()
        {
            var repo = new UserRepository();
            int userId = repo.CreateUser("user_name", "password", "name", "address", "phone");
            var user = repo.GetUserById(userId);

            Assert.IsNotNull(user);
            Assert.AreEqual("user_name",user.AccountName);
        }

        [Test]
        public void ShouldReturnUserByAccountName()
        {
            const string accountName = "user_name";
            var repo = new UserRepository();
            repo.CreateUser(accountName, "password", "name", "address", "phone");

            var user = repo.GetUserByName(accountName);

            Assert.IsNotNull(user);
            Assert.AreEqual(accountName,user.AccountName);
        }

        [Test]
        public void ShouldReturnNullWhenUserDoesntExists()
        {
            var repo = new UserRepository();
            repo.CreateUser("some_name", "password", "name", "address", "phone");

            var user = repo.GetUserByName("other_name");

            Assert.IsNull(user);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldThrowExceptionWhenDuplicateAccountName()
        {
            var repo = new UserRepository();
            repo.CreateUser("some_name", "password", "name", "address", "phone");
            repo.CreateUser("some_name", "123", "Mark", "address", "phone");
        }
    }
}
