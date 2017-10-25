using System.Collections.Generic;
using System.Linq;
using TBS.Data;
using TBS.Data.Dapper;
using TBS.Data.Commands.Clubs;
using TBS.Data.Queries.Clubs;
using TBS.Domain;

namespace TBS.Service
{
    public interface IClubService
    {
        IEnumerable<Club> GetAllClubs();
        IEnumerable<Club> GetClubs();
        void Save(Club club);
    }

    public class ClubService : IClubService
    {
        private readonly IDatabase _database;

        public ClubService()
        {
            _database = new Database();
        }

        public ClubService(IDatabase database)
        {
            _database = database;
        }

        public Club GetClub(int id)
        {
            return _database.Query(new GetClub(id));
        }

        public IEnumerable<Club> GetAllClubs()
        {
            return _database.Query(new GetAllClubs()).ToList();
        }

        public IEnumerable<Club> GetClubs()
        {
            IEnumerable<Club> list = _database.Query(new GetAllClubs());
            return list.Where(c => !c.Deleted);
        }

        public void Save(Club club)
        {
            _database.Execute(new SaveClub(club));
        }

    }
}
