using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TBS.Domain;
using TBS.Data;
using TBS.Facade;
using TBS.Data.Dapper;

namespace TBS.Test
{
    [TestClass]
    public class UserFacadeTests
    {
        const string dummy_user = "TBSX";
        UserFacade _facade;

        [TestInitialize]
        public void Init()
        {
            var session = new Session(Util.AppSettings.TestDatabaseConnection);
            var database = new CQHandler(session);

            _facade = new UserFacade(database);
        }

        [TestMethod]
        public void user_test_crud_on_database()
        {
            TBS_Test_Helper.TestPrepareDBForUsers();

            // Create, ReadMany
            var count = _facade.GetUsers(100).Count();
            User item = new User() { Name = dummy_user, ClubId = 100 };
            _facade.Save(item);
            var count2 = _facade.GetUsers(100).Count();
            Assert.AreEqual(count+1, count2);

            // Read 1
            User user2 = _facade.GetUsers(100).Where(c => c.Name == dummy_user).SingleOrDefault();
            Assert.AreEqual(user2.Name, dummy_user);

            // Update
            user2.Name = "TBSX user";
            _facade.Save(user2);
            User user3 = _facade.GetUser(user2.Id);
            Assert.AreEqual(user2.Name, user3.Name);

            // Delete
            user3.Deleted = true;
            _facade.Save(user3);

            User noUser = _facade.GetUser(user3.Id);
            Assert.AreEqual(noUser, null);
        }

    }
}