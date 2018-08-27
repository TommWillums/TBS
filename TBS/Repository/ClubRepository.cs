using TBS.Data.Commands.Clubs;
using TBS.Data.Queries.Clubs;
using TBS.Entities;

namespace TBS.Repository
{
    public interface IClubRepository
    {
        Club GetClub(int id);
        void Save(Club club);
    }

    public class ClubRepository : RepositoryBase, IClubRepository
    {
        public Club GetClub(int id)
        {
            return QueryCmdHandler.Query(new GetClub(id));
        }

        public void Save(Club club)
        {
            QueryCmdHandler.Execute(new SaveClub(club));
        }
    }
}
