using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TBS.Data;
using TBS.Domain;
using TBS.Repository;
using TBS.Data.Dapper;

namespace TBS.Test
{
    [TestClass]
    public class ClubRepositoryTests
    {
        const string dummy_name = "TBSX";
        private ClubRepository _repository;

        [TestInitialize]
        public void Init()
        {
            _repository = new ClubRepository(new CQHandler(new Session(new DapperContext(Util.AppSettings.TestDatabaseConnection))));
        }

        [TestMethod]
        public void club_get_100_from_database()
        {
            var club = _repository.Get(100);

            Assert.AreEqual(club.Id, 100);
        }

        [TestMethod]
        public void club_get_PTK_via_GetClubs()
        {
            var items = _repository.GetList().ToList();
            Club item = items.FirstOrDefault(c => c.ShortName == "PTK");
            Assert.AreEqual(item.ShortName, "PTK");
        }

        [TestMethod]
        public void club_add_in_database()
        {
            TBS_Test_Helper.TestPrepareDBToAddClub();
            Club item = new Club() { ClubName = dummy_name + " club", ShortName = dummy_name, Contact = "contact" };
            //using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                _repository.Save(item);
                var items = _repository.GetList().Where(c => c.ShortName == dummy_name);
                Assert.AreEqual(items.Count(), 1);
            }
        }

        [TestMethod]
        public void club_update_in_database()
        {
            TBS_Test_Helper.TestPrepareDBToUpdateClub();
            int itemId;
            //using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                var item = _repository.GetList().Where(c => c.ShortName == dummy_name).FirstOrDefault();
                itemId = item.Id;
                item.ClubName = dummy_name + " club";
                item.ShortName = dummy_name + " tbsx";
                item.Contact = dummy_name + " contact";
                _repository.Save(item);
            }

            //using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                var item2 = _repository.Get(itemId);
                Assert.AreEqual(item2.ClubName, dummy_name + " club");
                Assert.AreEqual(item2.ShortName, dummy_name + " tbsx");
                Assert.AreEqual(item2.Contact, dummy_name + " contact");
            }
        }

        [TestMethod]
        public void club_delete_in_database()
        {
            TBS_Test_Helper.TestPrepareDBToUpdateClub();
            //using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                var item = _repository.GetList().Where(c => c.ShortName == dummy_name).FirstOrDefault();
                item.Deleted = true;
                _repository.Save(item);
                var item2 = _repository.Get(item.Id);
                Assert.AreEqual(item2, null);
            }
        }
    }
}
