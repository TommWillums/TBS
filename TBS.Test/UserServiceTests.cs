using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TBS.Data;
using TBS.Domain;
using TBS.Repository;
using TBS.Data.Dapper;

namespace TBS.Test
{
    [TestClass]
    public class UserRepositoryTests
    {
        const string dummy_user = "TBSX";
        //UnitOfWork _unitOfWork;
        private UserRepository _repository;

        [TestInitialize]
        public void Init()
        {
            //_unitOfWork = new UnitOfWork(Util.AppSettings.TestDatabaseConnection);
            //_repository = new UserRepository(_unitOfWork);
            _repository = new UserRepository(new CQHandler(new Session(new DapperContext(Util.AppSettings.TestDatabaseConnection))));

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
            var count = _repository.GetList(100).Count();
            User item = new User() { Name = dummy_user, ClubId = 100 };
            _repository.Save(item);
            var count2 = _repository.GetList(100).Count();
            Assert.AreEqual(count+1, count2);

            // Read 1
            User user2 = _repository.GetList(100).Where(c => c.Name == dummy_user).SingleOrDefault();
            Assert.AreEqual(user2.Name, dummy_user);

            // Update
            user2.Name = "TBSX user";
            _repository.Save(user2);
            User user3 = _repository.Get(user2.Id);
            Assert.AreEqual(user2.Name, user3.Name);

            // Delete
            user3.Deleted = true;
            _repository.Save(user3);
            User noUser = _repository.Get(user3.Id);
            Assert.AreEqual(noUser, null);
        }

    }
}