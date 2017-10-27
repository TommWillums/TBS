using System.Collections.Generic;
using System.Linq;
using TBS.Data;
using TBS.Data.Commands.Courts;
using TBS.Data.Queries.Courts;
using TBS.Domain;

namespace TBS.Service
{
    public interface ICourtService
    {
        Court GetCourt(int id);
        IEnumerable<Court> GetCourts(int clubId);
        void Save(Court court);
    }

    public class CourtService : ICourtService
    {
        private readonly IDatabase _database;

        public CourtService()
        {
            _database = new Database();
        }

        public CourtService(IDatabase database)
        {
            _database = database;
        }

        public Court GetCourt(int id)
        {
            return _database.Query(new GetCourt(id));
        }

        public IEnumerable<Court> GetCourts(int clubId)
        {
            return _database.Query(new GetCourtsByClub(clubId)).ToList();
        }

        public void Save(Court court)
        {
            _database.Execute(new SaveCourt(court));
        }

    }
}
