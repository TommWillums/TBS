using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TBS.Data;
using TBS.Domain;
using TBS.Repository;
using TBS.Data.Dapper;

namespace TBS.Test
{
    [TestClass]
    public class CourtRepositoryTests
    {
        const string dummy_court = "TBSX";
        private CourtRepository _repository;

        [TestInitialize]
        public void Init()
        {
            _repository = new CourtRepository(new CQHandler(new Session(new DapperContext(Util.AppSettings.TestDatabaseConnection))));

        }

        [TestMethod]
        public void court_get_1_from_database()
        {
            var court = _repository.Get(1);
            Assert.AreEqual(court.Id, 1);
        }

        [TestMethod]
        public void court_add_to_database()
        {
            TBS_Test_Helper.TestPrepareDBToAddCourt();
            Court item = new Court() { Name = dummy_court, ClubId = 100, Active = true };
            //using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                _repository.Save(item);
                var items = _repository.GetList(100);
                Assert.AreEqual(items.Count(), 9);
            }
        }

        [TestMethod]
        public void court_update_in_database()
        {
            const string court_name = "TBSX claycourt";
            TBS_Test_Helper.TestPrepareDBToUpdateCourt();

            //using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                Court item = _repository.GetList(100).Where(c => c.Name == dummy_court).SingleOrDefault();
                item.Name = court_name;
                item.CourtGroup = 2;
                item.Active = false;
                _repository.Save(item);

                Court item2 = _repository.Get(item.Id);
                Assert.AreEqual(item2.Name, court_name);
                Assert.AreEqual(item2.CourtGroup, 2);
                Assert.AreEqual(item2.Active, false);
            }
        }

        [TestMethod]
        public void court_delete_in_database()
        {
            TBS_Test_Helper.TestPrepareDBToUpdateCourt();

            //using (var uow = new UnitOfWork(Util.AppSettings.TestDatabaseConnection))
            {
                Court item = _repository.GetList(100).Where(c => c.Name == dummy_court).SingleOrDefault();
                item.Deleted = true;
                _repository.Save(item);
                Court item2 = _repository.Get(item.Id);
                Assert.AreEqual(item2, null);
            }
        }

    }
}