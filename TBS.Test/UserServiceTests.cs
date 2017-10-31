using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TBS.Domain;
using TBS.Data;
using TBS.Service;
using TBS.Data.Dapper;

namespace TBS.Test
{
    [TestClass]
    public class UserServiceTests
    {
        const string dummy_user = "TBSX";
        UserService _service;

        [TestInitialize]
        public void Init()
        {
            var session = new Session(Util.AppSettings.TestDatabaseConnection);
            var database = new Database(session);

            _service = new UserService(database);
        }

        [TestMethod]
        public void user_test_crud_on_database()
        {
            TBS_Test_Helper.TestPrepareDBForUsers();

            // Create, ReadMany
            var count = _service.GetUsers(100).Count();
            User item = new User() { Name = dummy_user, ClubId = 100 };
            _service.Save(item);
            var count2 = _service.GetUsers(100).Count();
            Assert.AreEqual(count+1, count2);

            // Read 1
            User user2 = _service.GetUsers(100).Where(c => c.Name == dummy_user).SingleOrDefault();
            Assert.AreEqual(user2.Name, dummy_user);

            // Update
            user2.Name = "TBSX user";
            _service.Save(user2);
            User user3 = _service.GetUser(user2.Id);
            Assert.AreEqual(user2.Name, user3.Name);

            // Delete
            user3.Deleted = true;
            _service.Save(user3);

            User noUser = _service.GetUser(user3.Id);
            Assert.AreEqual(noUser, null);
        }

    }
}