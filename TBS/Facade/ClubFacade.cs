using System.Collections.Generic;
using System.Linq;
using TBS.Data;
using TBS.Data.Commands.Clubs;
using TBS.Data.Queries.Clubs;
using TBS.Domain;

namespace TBS.Facade
{
    public interface IClubFacade
    {
        Club GetClub(int id);
        IEnumerable<Club> GetAllClubs();
        IEnumerable<Club> GetClubs();
        void Save(Club club);
    }

    public class ClubFacade : FacadeBase, IClubFacade
    {
        public ClubFacade(IDatabase database = null) : base(database) { }

        public Club GetClub(int id)
        {
            return Database.Query(new GetClubQuery(id));
        }

        public IEnumerable<Club> GetAllClubs()
        {
            return Database.Query(new GetAllClubs()).ToList();
        }

        public IEnumerable<Club> GetClubs()
        {
            IEnumerable<Club> list = Database.Query(new GetAllClubs());
            return list.Where(c => !c.Deleted);
        }

        public void Save(Club club)
        {
            Database.Execute(new SaveClubCmd(club));
        }

    }
}
