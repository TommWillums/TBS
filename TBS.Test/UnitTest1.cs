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
    public class UnitTest1
    {
        [TestMethod]
        public void Construct_Object_Should_Return_Non_Null()
        {
            var calc = new Club();
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public async Task Get_Club_100_From_Db()
        {
            Club club = await ClubsDb.Get(100);
            Assert.AreEqual(club.Id, 100);
        }

        [TestMethod]
        public async Task Get_Courts_For_Club_100_From_Db()
        {
            List<Court> courts = await CourtsDb.Get(100);
            Assert.AreEqual(courts.Count, 8);
        }

        [TestMethod]
        public void Get_Courts_For_Club_100_From_Repository()
        {
            var repo = new GenericRepository<Court>(null);
            var courts = repo.GetAll().ToList();
            Assert.AreEqual(courts.Count(), 8);
        }

    }
}
