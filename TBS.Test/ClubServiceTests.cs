using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TBS.Domain;
using TBS.Repository;

namespace TBS.Test
{
    [TestClass]
    public class ClubRepositoryTests
    {
        const string dummy_name = "TBSX";

        [TestMethod]
        public void club_get_100_from_database()
        {
            var club = new ClubRepository().GetClub(100);
            Assert.AreEqual(club.Id, 100);
        }

        [TestMethod]
        public void club_get_PTK_via_GetClubs()
        {
            var repository = new ClubRepository();
            var items = repository.GetClubs().ToList();
            Club item = items.FirstOrDefault(c => c.ShortName == "PTK");
            Assert.AreEqual(item.ShortName, "PTK");
        }

        [TestMethod]
        public void club_add_in_database()
        {
            TBS_Test_Helper.TestPrepareDBToAddClub();
            Club item = new Club() { ClubName = dummy_name + " club", ShortName = dummy_name, Contact = "contact" };
            using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                var repository = new ClubRepository(uow);
                repository.Save(item);
                var items = repository.GetClubs().Where(c => c.ShortName == dummy_name);
                Assert.AreEqual(items.Count(), 1);
            }
        }

        [TestMethod]
        public void club_update_in_database()
        {
            TBS_Test_Helper.TestPrepareDBToUpdateClub();
            int itemId;
            using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                var repository = new ClubRepository(uow);
                var item = repository.GetClubs().Where(c => c.ShortName == dummy_name).FirstOrDefault();
                itemId = item.Id;
                item.ClubName = dummy_name + " club";
                item.ShortName = dummy_name + " tbsx";
                item.Contact = dummy_name + " contact";
                repository.Save(item);
            }

            using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                var repository = new ClubRepository(uow);
                var item2 = repository.GetClub(itemId);
                Assert.AreEqual(item2.ClubName, dummy_name + " club");
                Assert.AreEqual(item2.ShortName, dummy_name + " tbsx");
                Assert.AreEqual(item2.Contact, dummy_name + " contact");
            }
        }

        [TestMethod]
        public void club_delete_in_database()
        {
            TBS_Test_Helper.TestPrepareDBToUpdateClub();
            using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                var repository = new ClubRepository(uow);
                var item = repository.GetClubs().Where(c => c.ShortName == dummy_name).FirstOrDefault();
                item.Deleted = true;
                repository.Save(item);
                var item2 = repository.GetClub(item.Id);
                Assert.AreEqual(item2, null);
            }
        }
    }
}
