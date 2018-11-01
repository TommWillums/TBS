using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TBS.Data;
using TBS.Entities;
using TBS.Repository;

namespace TBS.Test
{
    [TestClass]
    public class CourtRepositoryTests
    {
        const string dummy_court = "TBSX";
        const string court8 = "Bane 4 Ute";

        [TestMethod]
        public void court_get_1_from_database()
        {
            var repository = new CourtRepository();
            var court = repository.GetCourt(1);
            Assert.AreEqual(court.Id, 1);
        }

        [TestMethod]
        public void court_add_to_database()
        {
            using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                TBS_Test_Helper.AddClub(uow.Session);

                Court item = new Court() { Name = dummy_court, ClubId = 2, Active = true };

                var repository = new CourtRepository(uow);
                repository.Save(item);
                var items = repository.GetCourts(2);
                Assert.AreEqual(items.Count(), 1);

                uow.Rollback();
            }
        }

        [TestMethod]
        public void court_update_in_database()
        {
            const string court_name = "TBSX claycourt";

            using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                TBS_Test_Helper.AddClub(uow.Session);
                TBS_Test_Helper.AddCourt(uow.Session);

                var repository = new CourtRepository(uow);

                var court = repository.GetCourts(2).SingleOrDefault(c => c.Name == dummy_court);
                court.Name = court_name;
                court.CourtGroup = 2;
                court.Active = false;
                repository.Save(court);

                var court2 = repository.GetCourt(court.Id);
                Assert.AreEqual(court2.Name, court_name);
                Assert.AreEqual(court2.CourtGroup, 2);
                Assert.AreEqual(court2.Active, false);

                uow.Rollback();
            }
        }

        [TestMethod]
        public void court_delete_in_database()
        {
            using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                var repository = new CourtRepository(uow);
                var court = repository.GetCourts(1).SingleOrDefault(c => c.Name == court8);
                court.Deleted = true;
                repository.Save(court);

                var court2 = repository.GetCourt(court.Id);
                Assert.AreEqual(court2, null);

                uow.Rollback();
            }
        }

    }
}