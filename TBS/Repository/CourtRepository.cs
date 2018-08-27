using System.Collections.Generic;
using System.Linq;
using TBS.Data;
using TBS.Data.Commands.Courts;
using TBS.Data.Queries.Courts;
using TBS.Entities;

namespace TBS.Repository
{
    public interface ICourtRepository
    {
        Court GetCourt(int id);
        IEnumerable<Court> GetCourts(int clubId);
        void Save(Court court);
    }

    public class CourtRepository : RepositoryBase, ICourtRepository
    {
        public Court GetCourt(int id)
        {
            return QueryCmdHandler.Query(new GetCourt(id));
        }

        public IEnumerable<Court> GetCourts(int clubId)
        {
            return QueryCmdHandler.Query(new GetCourtsByClub(clubId)).ToList();
        }

        public void Save(Court court)
        {
            QueryCmdHandler.Execute(new SaveCourt(court));
        }

    }
}
