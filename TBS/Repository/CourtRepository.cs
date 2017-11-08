using System.Collections.Generic;
using System.Linq;
using TBS.Data;
using TBS.Data.Commands.Courts;
using TBS.Data.Queries.Courts;
using TBS.Domain;

namespace TBS.Repository
{
    public class CourtRepository : IRepository<Court>
    {
        private readonly ICQHandler _cqhandler;
        private ICQHandler CQHandler => _cqhandler;
        public ISession Session => _cqhandler.Session;

        public CourtRepository(ICQHandler cqhandler)
        {
            _cqhandler = cqhandler;
        }

        public void JoinUnitOfWork(IUnitOfWork uow, bool saveUncommitted = true)
        {
            if (saveUncommitted)
                _cqhandler.Session.Commit();
            _cqhandler.Session = uow.Session;
            uow.AutoCommit = false;
        }

        public Court Get(int id)
        {
            return CQHandler.Query(new GetCourt(id));
        }

        public IEnumerable<Court> GetList(int id)
        {
            return CQHandler.Query(new GetCourtsByClub(id)).ToList();
        }

        public void Save(Court court)
        {
            CQHandler.Execute(new SaveCourt(court));
        }

        public void Remove(Court entity)
        {
            entity.Deleted = true;
            Save(entity);
        }
    }
}
