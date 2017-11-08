using System.Collections.Generic;
using System.Linq;
using TBS.Data;
using TBS.Data.Commands.Clubs;
using TBS.Data.Queries.Clubs;
using TBS.Domain;

namespace TBS.Repository
{
    public class ClubRepository : IRepository<Club>
    {
        private readonly ICQHandler _cqhandler;
        ICQHandler CQHandler => _cqhandler;

        public ClubRepository(ICQHandler cqhandler)
        {
            _cqhandler = cqhandler;
        }

        public Club Get(int id)
        {
            return CQHandler.Query(new GetClubQuery(id));
        }

        public IEnumerable<Club> GetList(int id = -1)
        {
            IEnumerable<Club> list = CQHandler.Query(new GetAllClubs());
            return list.Where(c => !c.Deleted);
        }

        public void Save(Club club)
        {
            CQHandler.Execute(new SaveClubCmd(club));
        }

        public void Remove(Club entity)
        {
            entity.Deleted = true;
            Save(entity);
        }
    }
}
