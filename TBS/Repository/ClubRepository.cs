using System.Collections.Generic;
using System.Linq;
using TBS.Data;
using TBS.Data.Commands.Clubs;
using TBS.Data.Queries.Clubs;
using TBS.Entities;

namespace TBS.Repository
{
    public interface IClubRepository
    {
        Club GetClub(int id);
        IEnumerable<Club> GetAllClubs();
        IEnumerable<Club> GetClubs();
        void Save(Club club);
    }

    public class ClubRepository : RepositoryBase, IClubRepository
    {
        public ClubRepository(UnitOfWork unitOfWork = null) : base(unitOfWork)
        {
        }

        public Club GetClub(int id)
        {
            return QueryCmdHandler.Query(new GetClubQuery(id));
        }

        public IEnumerable<Club> GetAllClubs()
        {
            return QueryCmdHandler.Query(new GetAllClubs()).ToList();
        }

        public IEnumerable<Club> GetClubs()
        {
            IEnumerable<Club> list = QueryCmdHandler.Query(new GetAllClubs());
            return list.Where(c => !c.Deleted);
        }

        public void Save(Club club)
        {
            QueryCmdHandler.Execute(new SaveClubCmd(club));
        }
    }
}
