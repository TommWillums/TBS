using Microsoft.VisualStudio.TestTools.UnitTesting;
using TBS.Data;
using TBS.Repository;

namespace TBS.Test
{
    [TestClass]
    public class ClubRepositoryTests
    {
        [TestMethod]
        public void club_get_1_from_database()
        {
            var club = new ClubRepository().GetClub(1);
            Assert.AreEqual(club.Id, 1);
        }

        [TestMethod]
        public void club_update_in_database()
        {
            using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                int clubId = 2;
                TBS_Test_Helper.AddClub(uow.Session);

                var repository = new ClubRepository(uow);            
                var club = repository.GetClub(clubId);

                Assert.AreEqual(club.ClubName, "TBSX");
                Assert.AreEqual(club.ShortName, "TBSX");
                Assert.AreEqual(club.Contact, "TBSX");
                Assert.AreEqual(club.CustomerId, 9999);

                club.ClubName = "club";
                club.ShortName = "short name";
                club.Contact = "contact";
                club.CustomerId = 1233;

                repository.Save(club);

                var club2 = repository.GetClub(clubId);
                Assert.AreEqual(club2.ClubName, "club");
                Assert.AreEqual(club2.ShortName, "short name");
                Assert.AreEqual(club2.Contact, "contact");
                Assert.AreEqual(club2.CustomerId, 1233);

                uow.Rollback();
            }
        }

    }
}
