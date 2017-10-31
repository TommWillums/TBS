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
    public class CourtServiceTests
    {
        const string dummy_court = "TBSX";
        CourtService _service;

        [TestInitialize]
        public void Init()
        {
            var session = new Session(Util.AppSettings.TestDatabaseConnection);
            var database = new Database(session);

            _service = new CourtService(database);
        }

        [TestMethod]
        public void court_get_1_from_database()
        {
            var court = _service.GetCourt(1);
            Assert.AreEqual(court.Id, 1);
        }

        [TestMethod]
        public void court_add_to_database()
        {
            TBS_Test_Helper.TestPrepareDBToAddCourt();
            Court item = new Court() { Name = dummy_court, ClubId = 100, Active = true };
            _service.Save(item);
            var items = _service.GetCourts(100);
            Assert.AreEqual(items.Count(), 9);
        }

        [TestMethod]
        public void court_update_in_database()
        {
            const string court_name = "TBSX claycourt";
            TBS_Test_Helper.TestPrepareDBToUpdateCourt();

            Court item = _service.GetCourts(100).Where(c => c.Name == dummy_court).SingleOrDefault();
            item.Name = court_name;
            item.CourtGroup = 2;
            item.Active = false;
            _service.Save(item);

            Court item2 = _service.GetCourt(item.Id);
            Assert.AreEqual(item2.Name, court_name);
            Assert.AreEqual(item2.CourtGroup, 2);
            Assert.AreEqual(item2.Active, false);
        }

        [TestMethod]
        public void court_delete_in_database()
        {
            TBS_Test_Helper.TestPrepareDBToUpdateCourt();

            Court item = _service.GetCourts(100).Where(c => c.Name == dummy_court).SingleOrDefault();
            item.Deleted = true;
            _service.Save(item);

            Court item2 = _service.GetCourt(item.Id);
            Assert.AreEqual(item2, null);
        }

    }
}