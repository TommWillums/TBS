using System.Data;
using Dapper;
using TBS.Entities;

namespace TBS.Data.Commands.Courts
{
    public class SaveCourt : ICommand
    {
        private readonly Court _court;

        public SaveCourt(Court court)
        {
            _court = court;
        }

        public void Execute(IDbConnection session)
        {
            if (_court.Id > 0)
            {
                session.Execute("update Courts_Tbl set Name = @Name, ClubId = @ClubId, CourtGroup = @CourtGroup, Active = @Active, Deleted = @Deleted where Id = @Id", 
                    new { _court.Id, _court.Name, _court.ClubId, _court.CourtGroup, _court.Active, _court.Deleted });
                return;
            }

            session.Execute("insert into Courts_Tbl (Name, ClubId, CourtGroup, Active, Deleted) values (@Name, @ClubId, @CourtGroup, @Active, @Deleted)",
                new { _court.Name, _court.ClubId, _court.CourtGroup, _court.Active, _court.Deleted });
        }
    }

}
