using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using TBS.Domain;
using TBS.Repository;
using TBS.Persistence;

namespace TBS.Test
{
    [TestClass]
    public class TestClubsRepository
    {
        [TestMethod]
        public async Task Get_Club_100_From_Db()
        {
            Club club = await ClubsDb.Get(100);
            Assert.AreEqual(club.Id, 100);
        }

        [TestMethod]
        public async Task Get_Club_100_From_Repository()
        {
            var club = await new ClubsQuery().Get(100);
            Assert.AreEqual(club.Id, 100);
        }

        [TestMethod]
        public async Task Get_Club_PTK_From_Repository_Via_GetAll()
        {
            List<Club> clubs = await new ClubsQuery().GetAll();
            Club club = clubs.Find(c => c.ShortName == "PTK");
            Assert.AreEqual(club.ShortName, "PTK");
        }

    }
}
