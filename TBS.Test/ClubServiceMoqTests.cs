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

        const string TBSX = "TBSX";

        [TestInitialize]
        public void Init()
        {
            _session = new Mock<ISession>();
            _database = new Database(_session.Object);
        }

        [TestMethod]
        public void club_get_all_moq()
        {
            var entities = new List<Club>
            {
                new Club {Id = 1, ClubName = "TBSX 1 Tennisklubb", ShortName = "TBSX1", Contact = "Tine"},
                new Club {Id = 2, ClubName = "TBSX 2 Tennisklubb", ShortName = "TBSX2", Contact = "Lisa"},
                new Club {Id = 2, ClubName = "TBSX 3 Tennisklubb", ShortName = "TBSX3", Contact = "Rita"}
            };

            _session.Setup(m => m.Query<Club>(It.IsAny<string>(), null)).Returns(entities);

            ClubService service = new ClubService(_database);
            var clubs = service.GetAllClubs();

            Assert.AreEqual(entities.Count, clubs.Count());
        }

        [TestMethod]
        public void club_save_moq()
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
