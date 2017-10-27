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

    public class CourtService : ServiceBase, ICourtService
    {
        public CourtService(IDatabase database = null) : base(database) { }

        public Court GetCourt(int id)
        {
            return Database.Query(new GetCourt(id));
        }

        public IEnumerable<Court> GetCourts(int clubId)
        {
            return Database.Query(new GetCourtsByClub(clubId)).ToList();
        }

        public void Save(Court court)
        {
            Database.Execute(new SaveCourt(court));
        }

    }
}
