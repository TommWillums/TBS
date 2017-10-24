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
    public class TestCourtsRepository
    {
        [TestMethod]
        public async Task Get_Courts_For_Club_100_From_Repository()
        {
            List<Court> courts = await new CourtsQuery().GetAll(100);
            Assert.AreEqual(courts.Count, 8);
        }
    }
}
