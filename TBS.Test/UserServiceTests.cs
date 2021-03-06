using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TBS.Data;
using TBS.Entities;
using TBS.Repository;

namespace TBS.Test
{
    [TestClass]
    public class UserRepositoryTests
    {
        const string dummy_user = "TBSX";
        UserRepository _repository;

        [TestInitialize]
        public void Init()
        {
            //_unitOfWork = new UnitOfWork(Util.AppSettings.TestDatabaseConnection);
            _repository = new UserRepository();
        }

        [TestCleanup]
        public void Cleanup()
        {
            //_unitOfWork.Dispose();
        }

        [TestMethod]
        public void user_test_crud_on_database()
        {
            TBS_Test_Helper.TestPrepareDBForUsers();

            // Create, ReadMany
            var count = _repository.GetUsers(2).Count();
            User item = new User() { Name = dummy_user, ClubId = 2 };
            _repository.Save(item);
            var count2 = _repository.GetUsers(2).Count();
            Assert.AreEqual(count+1, count2);

            // Read 1
            User user2 = _repository.GetUsers(2).SingleOrDefault(c => c.Name == dummy_user);
            Assert.AreEqual(user2.Name, dummy_user);

            // Update
            user2.Name = "TBSX user";
            _repository.Save(user2);
            User user3 = _repository.GetUser(user2.Id);
            Assert.AreEqual(user2.Name, user3.Name);

            // Delete
            user3.Deleted = true;
            _repository.Save(user3);
            User noUser = _repository.GetUser(user3.Id);
            Assert.AreEqual(noUser, null);
        }

    }
}