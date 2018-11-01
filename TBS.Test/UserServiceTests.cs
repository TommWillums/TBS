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
        int clubId2 = 2;
        string dummy_user = "dummy user";

        [TestMethod]
        public void user_create_user_in_db()
        {
            using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                TBS_Test_Helper.AddClub(uow.Session);
                UserRepository _repository = new UserRepository(uow);

                User user1 = new User() { Name = dummy_user, ClubId = clubId2 };
                _repository.Save(user1);

                int usercount = _repository.GetUsers(clubId2).Count();
                Assert.AreEqual(usercount, 1);

                uow.Rollback();
            }
        }

        [TestMethod]
        public void user_read_user_by_name_in_db()
        {
            using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                TBS_Test_Helper.AddClub(uow.Session);
                UserRepository _repository = new UserRepository(uow);

                var user = _repository.GetUsers(clubId: 1).SingleOrDefault(c => c.Name == "Urban");
                Assert.AreEqual(user.Name, "Urban");

                uow.Rollback();
            }
        }

        [TestMethod]
        public void user_read_all_club1_users_in_db()
        {
            UserRepository _repository = new UserRepository();
            int usercount = _repository.GetUsers(clubId: 1).Count();
            Assert.IsTrue(usercount > 1);
        }

        [TestMethod]
        public void user_update_user_by_id_in_db()
        {
            string new_user_name = "new user name";

            using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                UserRepository _repository = new UserRepository(uow);

                var user = _repository.GetUser(10002);
                Assert.AreNotEqual(user.Name, new_user_name);
                user.Name = new_user_name;
                _repository.Save(user);

                var user2 = _repository.GetUser(user.Id);
                Assert.AreEqual(user2.Name, new_user_name);

                uow.Rollback();
            }
        }

        [TestMethod]
        public void user_delete_user_by_id_in_db()
        {
            using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                TBS_Test_Helper.AddClub(uow.Session);
                TBS_Test_Helper.AddUser(uow.Session);
                UserRepository _repository = new UserRepository(uow);

                var users = _repository.GetUsers(clubId2).ToList();
                Assert.AreEqual(users.Count, 1);
                User user = users[0];
                user.Deleted = true;
                _repository.Save(user);

                var noUser = _repository.GetUser(user.Id);
                Assert.AreEqual(noUser, null);

                uow.Rollback();
            }
        }
    }
}