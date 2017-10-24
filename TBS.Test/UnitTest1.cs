using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using TBS.Domain;
using TBS.Repository;
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
            List<Court> courts = await CourtsDb.Get(100);
            Assert.AreEqual(courts.Count, 8);
        }

        [TestMethod]
<<<<<<< HEAD
        public async Task Get_Club_100_From_Repository()
        {
            var club = await new ClubsQuery().Get(100);
            Assert.AreEqual(club.Id, 100);
        }

        [TestMethod]
        public async Task Get_Club_PTK_From_Repository_Via_GetAll()
        {
            var clubs = await new ClubsQuery().GetAll(c => c.ShortName == "PTK");
            Assert.AreEqual(1, 100);
        }
=======
        public void Get_Courts_For_Club_100_From_Repository()
        {
            var repo = new GenericRepository<Court>(null);
            var courts = repo.GetAll().ToList();
            Assert.AreEqual(courts.Count(), 8);
        }

>>>>>>> 34e4962b0949ca750c54d0ef844137aaa74ed5d1
    }
}
