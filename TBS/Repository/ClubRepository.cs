using System.Collections.Generic;
using System.Linq;
using TBS.Data;
using TBS.Data.Commands.Clubs;
using TBS.Data.Queries.Clubs;
using TBS.Domain;

namespace TBS.Repository
{
    public class ClubRepository : RepositoryBase, IRepository<Club>
    {
        public ClubRepository(UnitOfWork unitOfWork = null) : base(unitOfWork)
        {
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
    }
}
