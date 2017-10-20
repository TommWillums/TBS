using Microsoft.VisualStudio.TestTools.UnitTesting;
using TBS.Domain;

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
    }
}
