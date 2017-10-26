using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TBS.Domain;
using TBS.Service;
using TBS.Data;
using Moq;

namespace TBS.Test
{
    [TestClass]
    public class ClubServiceMoqTests
    {
        Mock<ISession> _session;
        Database _database;

        const string LA_CALA = "LA_CALA_TENIS";

        [TestInitialize]
        public void Init()
        {
            _session = new Mock<ISession>();
            _database = new Database(_session.Object);
        }

        [TestMethod]
        public void get_all_clubs()
        {
            var entities = new List<Club>
            {
                new Club {Id = 1, ClubName = "Grønli Tennisklubb", ShortName = "GTK", Contact = "Tomm"},
                new Club {Id = 2, ClubName = "Flåtten Tennisklubb", ShortName = "FTK", Contact = "Ole"},
                new Club {Id = 2, ClubName = "Stridsklev Tennisklubb", ShortName = "STK", Contact = "Rita"}
            };

            _session.Setup(m => m.Query<Club>(It.IsAny<string>(), null)).Returns(entities);

            ClubService service = new ClubService(_database);
            var clubs = service.GetAllClubs();

            Assert.AreEqual(entities.Count, clubs.Count());
        }

        [TestMethod]
        public void save_club()
        {
            var club = new Club
            {
                ClubName = "Javea Tenis Academia",
                ShortName = "JTA",
                Contact = "David Ferrer"
            };

            _session.Setup(m => m.Execute(It.IsAny<string>(), It.IsAny<object>())).Verifiable();

            var service = new ClubService(_database);
            service.Save(club);

            _session.Verify(m => m.Execute(It.IsAny<string>(), It.IsAny<object>()));
        }

    }
}
