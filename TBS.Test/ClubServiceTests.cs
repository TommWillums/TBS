using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TBS.Data;
using TBS.Entities;
using TBS.Repository;

namespace TBS.Test
{
    [TestClass]
    public class ClubRepositoryTests
    {
        const string dummy_name = "TBSX";

        [TestMethod]
        public void club_get_2_from_database()
        {
            var club = new ClubRepository().GetClub(2);
            Assert.AreEqual(club.Id, 2);
        }

        [TestMethod]
        public void club_update_in_database()
        {
            TBS_Test_Helper.TestPrepareDBAddClub2();
            int itemId;
            using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                var repository = new ClubRepository(uow);
                var item = repository.GetClub(2);
                itemId = item.Id;
                item.ClubName = dummy_name + " club";
                item.ShortName = dummy_name + " tbsx";
                item.Contact = dummy_name + " contact";
                item.CustomerId = 1234;
                repository.Save(item);
            }

            using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                var repository = new ClubRepository(uow);
                var item2 = repository.GetClub(itemId);
                Assert.AreEqual(item2.ClubName, dummy_name + " club");
                Assert.AreEqual(item2.ShortName, dummy_name + " tbsx");
                Assert.AreEqual(item2.Contact, dummy_name + " contact");
                Assert.AreEqual(item2.CustomerId, 1234);
            }
        }

    }
}
