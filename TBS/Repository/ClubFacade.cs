using System.Collections.Generic;
using System.Linq;
using TBS.Data;
using TBS.Data.Commands.Clubs;
using TBS.Data.Queries.Clubs;
using TBS.Domain;

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
        public ClubRepository(ICQHandler cqhandler = null) : base(cqhandler) { }

        public Club GetClub(int id)
        {
            return CQHandler.Query(new GetClubQuery(id));
        }

        public IEnumerable<Club> GetAllClubs()
        {
            return CQHandler.Query(new GetAllClubs()).ToList();
        }

        public IEnumerable<Club> GetClubs()
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
