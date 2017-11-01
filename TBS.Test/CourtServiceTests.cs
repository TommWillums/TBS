using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TBS.Domain;
using TBS.Data;
using TBS.Repository;
using TBS.Data.Dapper;

namespace TBS.Test
{
    [TestClass]
    public class CourtRepositoryTests
    {
        const string dummy_court = "TBSX";
        CourtRepository _repository;

        [TestInitialize]
        public void Init()
        {
            var session = new Session(Util.AppSettings.TestDatabaseConnection);
            var database = new CQHandler(session);

            _repository = new CourtRepository(database);
        }

        [TestMethod]
        public void court_get_1_from_database()
        {
            var court = _repository.GetCourt(1);
            Assert.AreEqual(court.Id, 1);
        }

        [TestMethod]
        public void court_add_to_database()
        {
            TBS_Test_Helper.TestPrepareDBToAddCourt();
            Court item = new Court() { Name = dummy_court, ClubId = 100, Active = true };
            _repository.Save(item);
            var items = _repository.GetCourts(100);
            Assert.AreEqual(items.Count(), 9);
        }

        [TestMethod]
        public void court_update_in_database()
        {
            const string court_name = "TBSX claycourt";
            TBS_Test_Helper.TestPrepareDBToUpdateCourt();

            Court item = _repository.GetCourts(100).Where(c => c.Name == dummy_court).SingleOrDefault();
            item.Name = court_name;
            item.CourtGroup = 2;
            item.Active = false;
            _repository.Save(item);

            Court item2 = _repository.GetCourt(item.Id);
            Assert.AreEqual(item2.Name, court_name);
            Assert.AreEqual(item2.CourtGroup, 2);
            Assert.AreEqual(item2.Active, false);
        }

        [TestMethod]
        public void court_delete_in_database()
        {
            TBS_Test_Helper.TestPrepareDBToUpdateCourt();

            Court item = _repository.GetCourts(100).Where(c => c.Name == dummy_court).SingleOrDefault();
            item.Deleted = true;
            _repository.Save(item);

            Court item2 = _repository.GetCourt(item.Id);
            Assert.AreEqual(item2, null);
        }

    }
}