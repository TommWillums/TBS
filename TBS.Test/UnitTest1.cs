using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using TBS.Domain;
using TBS.Persistence;
using TBS.Repository;

namespace TBS.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task Get_Club_100_From_Db()
        {
            Club club = await ClubsDb.Get(100);
            Assert.AreEqual(club.Id, 100);
        }

        [TestMethod]
        public async Task Get_Courts_For_Club_100_From_Db()
        {
            Club club = await ClubsDb.Get(100);
            List<Court> courts = await CourtsDb.Get(100);
            Assert.AreEqual(courts.Count, 8);
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
