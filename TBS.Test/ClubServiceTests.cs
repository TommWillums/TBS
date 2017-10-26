using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TBS.Domain;
using TBS.Service;
using TBS.Data;
using TBS.Util;

namespace TBS.Test
{
    [TestClass]
    public class ClubServiceTests
    {
        ClubService _service;
        const string LA_TENIS = "LA_TENIS";

        [TestInitialize]
        public void Init()
        {
            // session = new Mock<ISession>();
            // database = new Database(session.Object);
            var session = new Session(AppSettings.TestDatabaseConnection);
            var database = new Database(session);

            _service = new ClubService(database);
        }

        [TestMethod]
        public void get_club_100_from_database()
        {
            var club = _service.GetClub(100);
            Assert.AreEqual(club.Id, 100);
        }

        [TestMethod]
        public void get_club_PTK_via_GetClubs()
        {
            var clubs = _service.GetClubs().ToList();
            Club club = clubs.FirstOrDefault(c => c.ShortName == "PTK");
            Assert.AreEqual(club.ShortName, "PTK");
        }

        [TestMethod]
        public void add_club_to_database()
        {
            TBS_Test_Helper.TestPrepareDBToAddClub();
            Club club = new Club() { ClubName = "Mijas Club de Tenis", ShortName = LA_TENIS, Contact = "José" };
            _service.Save(club);
            var clubs = _service.GetClubs().Where(c => c.ShortName == LA_TENIS);
            Assert.AreEqual(clubs.Count(), 1);
        }

        [TestMethod]
        public void delete_club_from_database()
        {
            TBS_Test_Helper.TestPrepareDBToDeleteClub();
            var club = _service.GetClubs().Where(c => c.ShortName == LA_TENIS).FirstOrDefault();
            club.Deleted = true;
            _service.Save(club);
            var club2 = _service.GetClubs().Where(c => c.ShortName == LA_TENIS).FirstOrDefault();
            Assert.AreEqual(1, 1);
        }
    }
}
