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
        IEnumerable<Club> GetClubs();
        void Save(Club club);
    }

    public class ClubRepository : RepositoryBase, IClubRepository
    {
        public ClubRepository(UnitOfWork unitOfWork = null) : base(unitOfWork) { }

        public Club GetClub(int id)
        {
            return QueryCmdHandler.Query(new GetClub(id));
        }

        public IEnumerable<Club> GetClubs()
        {
            return QueryCmdHandler.Query(new GetClubs());
        }

        public void Save(Club club)
        {
            QueryCmdHandler.Execute(new SaveClub(club));
        }
    }
}
