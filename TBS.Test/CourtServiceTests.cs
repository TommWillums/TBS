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
            TBS_Test_Helper.TestPrepareDBToAddCourt();
            Court item = new Court() { Name = dummy_court, ClubId = 2, Active = true };
            var repository = new CourtRepository();
            repository.Save(item);
            var items = repository.GetCourts(2);
            Assert.AreEqual(items.Count(), 1);
        }

        [TestMethod]
        public void court_update_in_database()
        {
            const string court_name = "TBSX claycourt";
            TBS_Test_Helper.TestPrepareDBToUpdateCourt();

            var repository = new CourtRepository();

            Court item = repository.GetCourts(2).SingleOrDefault(c => c.Name == dummy_court);
            item.Name = court_name;
            item.CourtGroup = 2;
            item.Active = false;
            repository.Save(item);

            Court item2 = repository.GetCourt(item.Id);
            Assert.AreEqual(item2.Name, court_name);
            Assert.AreEqual(item2.CourtGroup, 2);
            Assert.AreEqual(item2.Active, false);
        }

        [TestMethod]
        public void court_delete_in_database()
        {
            TBS_Test_Helper.TestPrepareDBToUpdateCourt();

            var repository = new CourtRepository();
            Court item = repository.GetCourts(2).SingleOrDefault(c => c.Name == dummy_court);
            item.Deleted = true;
            repository.Save(item);
            Court item2 = repository.GetCourt(item.Id);
            Assert.AreEqual(item2, null);
        }

    }
}