using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TBS.Domain;
using TBS.Repository;
using TBS.Data;
using Moq;

namespace TBS.Test
{
    [TestClass]
    public class ClubRepositoryMoqTests
    {
        Mock<ISession> _session;
        CQHandler _cqhandler;

        const string TBSX = "TBSX";

        [TestInitialize]
        public void Init()
        {
            _session = new Mock<ISession>();
            _cqhandler = new CQHandler(_session.Object);
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

            ClubRepository repository = new ClubRepository(_cqhandler);
            var clubs = repository.GetAllClubs();

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

            var repository = new ClubRepository(_cqhandler);
            repository.Save(club);

            _session.Verify(m => m.Execute(It.IsAny<string>(), It.IsAny<object>()));
        }

    }
}
