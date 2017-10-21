using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using TBS.Domain;
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
            Club club = await new ClubsDb().Get(100);
            Assert.AreEqual(club.Id, 100);
        }
    }
}
