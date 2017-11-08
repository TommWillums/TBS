using System.Collections.Generic;
using System.Linq;
using TBS.Data;
using TBS.Data.Commands.Courts;
using TBS.Data.Queries.Courts;
using TBS.Domain;

namespace TBS.Repository
{
    public class CourtRepository : RepositoryBase, IRepository<Court>
    {
        public CourtRepository(ICQHandler cqhandler) : base(cqhandler)
        {
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
