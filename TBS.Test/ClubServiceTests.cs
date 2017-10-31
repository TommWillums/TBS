using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TBS.Domain;
using TBS.Service;
using TBS.Data;
using TBS.Data.Dapper;

namespace TBS.Test
{
    [TestClass]
    public class ClubServiceTests
    {
        ClubService _service;
        const string dummy_name = "TBSX";

        [TestInitialize]
        public void Init()
        {
            var session = new Session(Util.AppSettings.TestDatabaseConnection);
            var database = new Database(session);

            _service = new ClubService(database);
        }

        [TestMethod]
        public void club_get_100_from_database()
        {
            var club = _service.GetClub(100);
            Assert.AreEqual(club.Id, 100);
        }

        [TestMethod]
        public void club_get_PTK_via_GetClubs()
        {
            var items = _service.GetClubs().ToList();
            Club item = items.FirstOrDefault(c => c.ShortName == "PTK");
            Assert.AreEqual(item.ShortName, "PTK");
        }

        [TestMethod]
        public void club_add_in_database()
        {
            TBS_Test_Helper.TestPrepareDBToAddClub();
            Club item = new Club() { ClubName = dummy_name + " club", ShortName = dummy_name, Contact = "contact" };
            _service.Save(item);
            var items = _service.GetClubs().Where(c => c.ShortName == dummy_name);
            Assert.AreEqual(items.Count(), 1);
        }

        [TestMethod]
        public void club_update_in_database()
        {
            TBS_Test_Helper.TestPrepareDBToUpdateClub();
            var item = _service.GetClubs().Where(c => c.ShortName == dummy_name).FirstOrDefault();
            item.ClubName  = dummy_name + " club";
            item.ShortName = dummy_name + " tbsx";
            item.Contact   = dummy_name + " contact";
            _service.Save(item);
            var item2 = _service.GetClub(item.Id);
            Assert.AreEqual(item2.ClubName , dummy_name + " club");
            Assert.AreEqual(item2.ShortName, dummy_name + " tbsx");
            Assert.AreEqual(item2.Contact  , dummy_name + " contact");
        }

        [TestMethod]
        public void club_delete_in_database()
        {
            TBS_Test_Helper.TestPrepareDBToUpdateClub();
            var item = _service.GetClubs().Where(c => c.ShortName == dummy_name).FirstOrDefault();
            item.Deleted = true;
            _service.Save(item);
            var item2 = _service.GetClub(item.Id);
            Assert.AreEqual(item2, null);
        }
    }
}
