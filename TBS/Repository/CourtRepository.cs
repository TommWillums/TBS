using System.Collections.Generic;
using System.Linq;
using TBS.Data;
using TBS.Data.Commands.Courts;
using TBS.Data.Queries.Courts;
using TBS.Domain;

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
        public CourtRepository(UnitOfWork unitOfWork = null) : base(unitOfWork) { }

        public Court GetCourt(int id)
        {
            return CQHandler.Query(new GetCourt(id));
        }

        public IEnumerable<Court> GetCourts(int clubId)
        {
            return CQHandler.Query(new GetCourtsByClub(clubId)).ToList();
        }

        public void Save(Court court)
        {
            CQHandler.Execute(new SaveCourt(court));
        }

    }
}
